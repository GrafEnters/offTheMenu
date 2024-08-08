using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdminPanel : MonoBehaviour {
    [SerializeField]
    private HandView _hand;
    [SerializeField]
    private BottomUI _bottomUI;

    public void DrawCards(int amount) {
        List<CardData> cards = Game.Instance.GameManager.PlayingDeck.DrawCards(amount);
        foreach (var card in cards) {
            _hand.AddCard(card);
        }
    }

    public void StashHand() {
        Game.Instance.GameManager.PlayingDeck.StashHand();
        _hand.StashAllCards();
    }

    public void RedrawHand() {
        StashHand();
        DrawCards(5);
    }

    public void ReloadScene() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}