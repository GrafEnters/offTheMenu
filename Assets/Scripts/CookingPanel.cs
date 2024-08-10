using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CookingPanel : MonoBehaviour {
    [SerializeField]
    private CardHolder _card1, _card2, _cookingTool;

    [SerializeField]
    private Transform _resultCardHolder, _cookPanel, _resultPanel;

    [SerializeField]
    private Button _combineButton;

    private void Awake() {
        _card1.InitHolder((c) => c.CardData.CheckType(CardType.Food));
        _card2.InitHolder((c) => c.CardData.CheckType(CardType.Food));
        _cookingTool.InitHolder((c) => c.CardData.CheckType(CardType.Tool));
    }

    private void Update() {
        _combineButton.interactable = CheckCanCombine();
    }

    private bool CheckCanCombine() {
        int cards = (_card1.CardView != null ? 1 : 0) + (_card2.CardView != null ? 1 : 0) + (_cookingTool.CardView != null ? 1 : 0);
        return cards >= 2;
    }

    public void Combine() {
        if (Game.Instance.GameManager.PlayerInventory.Energy == 0) {
            Debug.Log("No energy!");
            return;
        }
        
        
        Game.Instance.GameManager.LoseEnergy();
        int combinedDelicious = (_card1.CardView != null ? _card1.CardView.CardData.Delicious : 0) +
                                (_card2.CardView != null ? _card2.CardView.CardData.Delicious : 0);
        List<CardTag> combinedTags = new List<CardTag>();
        if (_card1.CardView != null) {
            combinedTags.AddRange(_card1.CardView.CardData.CardTags);
        }
        
        if (_card2.CardView != null) {
            combinedTags.AddRange(_card2.CardView.CardData.CardTags);
        }
        CardData combinedFood = new CardData() {
            Name = "CombinedFood#" + Random.Range(9, 99),
            CardTypes = { CardType.Food, CardType.CookedFood},
            CardTags = combinedTags,
            Delicious = combinedDelicious
        };
        combinedFood.CardTags = TagsManager.RearrangeTagsAfterCooking(combinedFood.CardTags);

        if (_cookingTool.CardView != null) {
            CookingToolCardData cookingToolCardData = _cookingTool.CardView.CardData as CookingToolCardData;

            foreach (ICookStep variable in cookingToolCardData.CookSteps) {
                combinedFood = variable.CookFoodCard(combinedFood);
            }
        }

        string uid = "salad0";
        if (combinedFood.CheckTag(CardTag.Fried)) {
            uid = "grilled0";
        }

        combinedFood.Uid = uid;
        combinedFood.Name = CardFactory.GetPrefabricatedCardData(uid).Name;
        
        //cooked foods burn after being ate
        combinedFood.CardMechanics.Add(CardMechanics.BurnAfterAte);
        

        if (_card1.CardView != null) {
            _card1.CardView.StashCard();
        }

        if (_card2.CardView != null) {
            _card2.CardView.StashCard();
        }

        if (_cookingTool.CardView != null) {
            _cookingTool.CardView.StashCard();
        }

        _cookPanel.gameObject.SetActive(false);

        CardView newCard = CardFactory.Instance.GetCard(combinedFood);
        newCard.transform.SetParent(_resultCardHolder);
        newCard.transform.localPosition = Vector3.zero;
        newCard.transform.rotation = Quaternion.identity;
        newCard.OnMoved += OnResultCardRemoved;
        newCard.OnDestroyed += OnResultCardRemoved;
        _resultPanel.gameObject.SetActive(true);
    }

    private void OnResultCardRemoved(CardView cardView) {
        cardView.OnMoved -= OnResultCardRemoved;
        cardView.OnDestroyed -= OnResultCardRemoved;
        _cookPanel.gameObject.SetActive(true);
        _resultPanel.gameObject.SetActive(false);
    }
}