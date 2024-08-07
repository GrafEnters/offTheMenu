using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {
    public PlayerInventory PlayerInventory;
    public PlayingDeck PlayingDeck;
    public int Energy, MaxEnergy;

    private bool _isEndingRound;

    public void InitNewGame() {
        PlayerInventory = new PlayerInventory();
        PlayerInventory.Deck.GenerateDeck();
        PlayingDeck = new PlayingDeck(PlayerInventory.Deck);
        MaxEnergy = 3;
        Energy = MaxEnergy;
    }

    public void EndOfRound() {
        if (_isEndingRound) {
            return;
        }
        Game.Instance.StartCoroutine(EndOfRoundCoroutine());
    }

    private IEnumerator EndOfRoundCoroutine() {
        _isEndingRound = true;
        Game.Instance.HandView.StashAllCards();
        Game.Instance.BottomUI.DeckView.SetData(PlayingDeck);
        yield return new WaitForSeconds(0.5f);
        List<CardData> cards = PlayingDeck.DrawCards(5);
        Game.Instance.HandView.DrawCards(cards);
        Energy = MaxEnergy;
        Game.Instance.BottomUI.SetData(PlayingDeck, Energy, MaxEnergy);
        _isEndingRound = false;
    }
}