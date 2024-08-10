using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CardView : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI _cardName, _cardDeliciousText;

    [SerializeField]
    private GameObject _cardDeliciousHolder;
    [SerializeField]
    private Image _icon;
    
    public RectTransform RectTransform;

    public Action<CardView> OnDestroyed;
    public Action<CardView> OnMoved;

    private CardData _cardData;
    private Transform _previousParent;

    private bool _isDestroyed;

    public CardData CardData => _cardData;
    
    public void SetData(CardData data) {
        _cardData = data;
        _cardName.text = data.Name;
        _icon.sprite = CardFactory.GetIconByUid(data.Uid);
        
        _cardDeliciousHolder.SetActive(data.CardTypes.Contains(CardType.Food));
        _cardDeliciousText.text = data.Delicious.ToString();
    }

    public void OnStartDrag() {
        _previousParent = transform.parent;
        CardDragManager.Instance.StartDrag(this);
    }
    
    public void OnEndDrag() {
        if (CardDragManager.DraggingCard != this) {
            return;
        }

        bool checkEndDrag = CardDragManager.Instance.CheckEndDrag();
        if (checkEndDrag) {
            OnMoved?.Invoke(this);
        }
        CardDragManager.Instance.EndDrag();
       
    }

    public void BurnCard() {
        DestroyView();
        Game.Instance.GameManager.PlayingDeck.BurnCard(_cardData);
        Destroy(gameObject);
    }

    public void StashCard() {
        DestroyView();
        Game.Instance.GameManager.PlayingDeck.StashCard(_cardData);
        Destroy(gameObject);
    }

    private void DestroyView() {
        _isDestroyed = true;
        OnDestroyed?.Invoke(this);
    }
}