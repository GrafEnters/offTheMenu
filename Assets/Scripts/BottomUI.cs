using UnityEngine;

public class BottomUI : MonoBehaviour {
    [SerializeField]
    private HandView _handView;

    public HandView HandView => _handView;

    [SerializeField]
    private EnergyView _energyView;

    public EnergyView EnergyView => _energyView;

    [SerializeField]
    private DeckView _deckView;

    public DeckView DeckView => _deckView;

    public void SetData(PlayingDeck playingDeck, int hasEnergy, int allEnergy) {
        _deckView.SetData(playingDeck);
        _energyView.SetData(hasEnergy, allEnergy);
    }

    public void EndOfRound() {
        Game.Instance.GameManager.EndOfRound();
    }
}