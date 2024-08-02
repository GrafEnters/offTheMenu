using System;
using UnityEngine;

public class CardFactory : MonoBehaviour {
    public static CardFactory Instance;

    [SerializeField]
    private CardView _cardView;

    private void Awake() {
        Instance = this;
    }

    public CardView GetCard(CardData data) {
        //TODO Add pooling
        CardView card = Instantiate(_cardView);
        card.SetData(data);
        return card;
    }
}