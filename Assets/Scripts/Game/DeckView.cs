using TMPro;
using UnityEngine;

public class DeckView : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI _leftInDeckCards;

    [SerializeField]
    private TextMeshProUGUI _stashedCards;

    public void SetData(PlayingDeck playingDeck) {
        _leftInDeckCards.text = playingDeck.LeftCards.Count.ToString();
        _stashedCards.text = playingDeck.StashedCards.Count.ToString();
    }
}