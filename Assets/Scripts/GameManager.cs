using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {
    public PlayerInventory PlayerInventory => OffTheMenuSaveLoadManager.Profile.PlayerInventory;
    public PlayingDeck PlayingDeck;
    public CustomersFactory CustomersFactory;

    private bool _isEndingRound;

    public static bool IsGameInited = false;

    public void InitNewGame() {
        OffTheMenuSaveLoadManager.Profile.PlayerInventory = new PlayerInventory();
        OffTheMenuSaveLoadManager.Profile.PlayerInventory.Deck.GenerateDeck();
        DaysFactory.Instance.RefillUniqueDays();
        PlayerInventory.Hp = 3;
        PlayerInventory.MaxEnergy = 3;
    }

    public void InitNewDay() {
        PlayingDeck = new PlayingDeck(PlayerInventory.Deck);
        PlayerInventory.Energy = PlayerInventory.MaxEnergy;

        CustomersFactory = new CustomersFactory();
        CookingDayConfig config = DaysFactory.Instance.GetCookingDay(OffTheMenuSaveLoadManager.Profile.PathData.CurrentPlace);
        Game.Instance.CustomerPanel.QueueCustomers(config.CustomerDatas);

        Game.Instance.TopUI.HpView.SetData(PlayerInventory.Hp);
        Game.Instance.TopUI.DayView.SetData("Первый день");
        Game.Instance.BottomUI.SetData(PlayingDeck, PlayerInventory.Energy, PlayerInventory.MaxEnergy);
    }

    public void EndOfRound() {
        if (_isEndingRound) {
            return;
        }

        Game.Instance.StartCoroutine(EndOfRoundCoroutine());
    }

    private IEnumerator EndOfRoundCoroutine() {
        _isEndingRound = true;

        yield return Game.Instance.CustomerPanel.StartCoroutine(Game.Instance.CustomerPanel.LoseCustomersPatience());

        Game.Instance.HandView.StashAllCards();
        Game.Instance.BottomUI.DeckView.SetData(PlayingDeck);
        yield return new WaitForSeconds(0.5f);
        List<CardData> cards = PlayingDeck.DrawCards(5);
        Game.Instance.HandView.DrawCards(cards);
        PlayerInventory.Energy = PlayerInventory.MaxEnergy;
        Game.Instance.BottomUI.SetData(PlayingDeck, PlayerInventory.Energy, PlayerInventory.MaxEnergy);
        _isEndingRound = false;
    }

    public void LoseEnergy(int amount = 1) {
        PlayerInventory.Energy -= amount;
        Game.Instance.BottomUI.EnergyView.SetData(PlayerInventory.Energy, PlayerInventory.MaxEnergy);
    }

    public void LoseHp(int amount = 1) {
        PlayerInventory.Hp -= amount;
        Game.Instance.TopUI.HpView.SetData(PlayerInventory.Hp);
        if (PlayerInventory.Hp <= 0) {
            Debug.Log("Вы проиграли!!!");
        }
    }

    public void AddCoins(int amount = 1) {
        PlayerInventory.Coins += amount;
        Game.Instance.TopUI.CoinsView.SetData(PlayerInventory.Coins);
    }
}