using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class CardFactory : MonoBehaviour {
    public static CardFactory Instance;

    [SerializeField]
    private CardView _cardView;

    [SerializeField]
    private List<CardConfig> _cardsTable;

    private void Awake() {
        Instance = this;
    }

    public CardView GetCard(CardData data) {
        //TODO Add pooling
        CardView card = Instantiate(_cardView);
        card.SetData(data);
        return card;
    }

    //TODO create configs for this
    public static CardData GetPrefabricatedCardData(string cardUid) {
        CardConfig found = Instance._cardsTable.FirstOrDefault(c => c.Uid == cardUid);
        if (found != null) {
            return found.GetCardData();
        }

        switch (cardUid) {
            case "ovoshBase":
                return new CardData() {
                    Name = "Ovosh#" + Random.Range(1, 99),
                    Delicious = 1,
                    CardTypes = { CardType.Food },
                };
            case "ovoshRare":
                return new CardData() {
                    Name = "Rare Ovosh#" + Random.Range(1, 99),
                    Delicious = 2,
                    CardTypes = { CardType.Food },
                };
            case "myacoBase":
                return new CardData() {
                    Name = "Myaco #" + Random.Range(1, 99),
                    Delicious = 1,
                    CardTypes = { CardType.Food },
                    CardTags = { CardTag.Raw }
                };
            case "myacoRare":
                return new CardData() {
                    Name = "Rare Myaco#" + Random.Range(1, 99),
                    Delicious = 2,
                    CardTypes = { CardType.Food },
                    CardTags = { CardTag.Raw }
                };
            case "fryingPanBase":
                return new CookingToolCardData() {
                    Name = "Pan#" + Random.Range(1, 99),
                    CardTypes = { CardType.Tool },
                    CookSteps = {
                        new ReplaceTagCookStep(CardTag.Raw, CardTag.Fried),
                        new MultiplyCookStep(2, CardTag.Fried)
                    }
                };
        }

        throw new Exception("NotFoundPrefabricatedCard " + cardUid);
    }
}