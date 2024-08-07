using System.Collections.Generic;
using UnityEngine;

public class PlayingDeck {
    public List<CardData> CardDatas = new List<CardData>();
    public List<CardData> AddedCardDatas = new List<CardData>();
    public Queue<CardData> LeftCards = new Queue<CardData>();
    public List<CardData> HandCards = new List<CardData>();
    public Queue<CardData> StashedCards = new Queue<CardData>();
    public Queue<CardData> BurnedCards = new Queue<CardData>();

    public PlayingDeck(Deck deck) {
        CardDatas = new List<CardData>(deck.CardDatas);
        LeftCards = new Queue<CardData>(CardDatas);
    }

    public List<CardData> DrawCards(int amount) {
        List<CardData> drawnCards = new List<CardData>();
        int leftCards = LeftCards.Count;
        if (leftCards < amount) {
            for (int i = 0; i < leftCards; i++) {
                CardData c = LeftCards.Dequeue();
                HandCards.Add(c);
                drawnCards.Add(c);
            }

            amount -= leftCards;
            EmptyStash();
            leftCards = LeftCards.Count;
        }
        
        for (int i = 0; i < Mathf.Min(amount, leftCards); i++) {
            CardData c = LeftCards.Dequeue();
            HandCards.Add(c);
            drawnCards.Add(c);
        }

        return drawnCards;
    }

    public void StashCard(CardData data) {
        HandCards.Remove(data);
        StashedCards.Enqueue(data);
    }

    public void BurnCard(CardData data) {
        HandCards.Remove(data);
        BurnedCards.Enqueue(data);
    }

    public void StashHand() {
        foreach (var VARIABLE in HandCards) {
            StashedCards.Enqueue(VARIABLE);
        }

        HandCards.Clear();
    }

    private void EmptyStash() {
        int stashedCards = StashedCards.Count;
        for (int i = 0; i < stashedCards; i++) {
            LeftCards.Enqueue(StashedCards.Dequeue());
        }
    }
}