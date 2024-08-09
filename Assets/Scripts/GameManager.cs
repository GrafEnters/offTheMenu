using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager {
    public PlayerInventory PlayerInventory;
    public PlayingDeck PlayingDeck;
    public CustomersFactory CustomersFactory;
    public int Energy, MaxEnergy;
    public int Hp;

    private bool _isEndingRound;

    public static bool IsGameInited = false;

    public void InitNewGame() {
        PlayerInventory = new PlayerInventory();
        PlayerInventory.Deck.GenerateDeck();
        Hp = 3;
    }

    public void InitNewDay() {
        PlayingDeck = new PlayingDeck(PlayerInventory.Deck);

        MaxEnergy = 3;
        Energy = MaxEnergy;

        CustomersFactory = new CustomersFactory();
        CookingDayConfig config = DaysFactory.Instance.GetCookingDay(PathManager.NextLevelUid);
        Game.Instance.CustomerPanel.QueueCustomers(config.CustomerDatas);

        Game.Instance.TopUI.HpView.SetData(Hp);
        Game.Instance.TopUI.DayView.SetData("Первый день");
        Game.Instance.BottomUI.SetData(PlayingDeck, Energy, MaxEnergy);
    }

    public void EndOfRound() {
        if (_isEndingRound) {
            return;
        }

        Game.Instance.StartCoroutine(EndOfRoundCoroutine());
    }

    private IEnumerator EndOfRoundCoroutine() {
        _isEndingRound = true;
        
        
        yield return Game.Instance.CustomerPanel.StartCoroutine( Game.Instance.CustomerPanel.LoseCustomersPatience());
        
        
        Game.Instance.HandView.StashAllCards();
        Game.Instance.BottomUI.DeckView.SetData(PlayingDeck);
        yield return new WaitForSeconds(0.5f);
        List<CardData> cards = PlayingDeck.DrawCards(5);
        Game.Instance.HandView.DrawCards(cards);
        Energy = MaxEnergy;
        Game.Instance.BottomUI.SetData(PlayingDeck, Energy, MaxEnergy);
        _isEndingRound = false;
    }

    public void LoseEnergy(int amount = 1) {
        Energy -= amount;
        Game.Instance.BottomUI.EnergyView.SetData(Energy, MaxEnergy);
    }

    public void LoseHp(int amount = 1) {
        Hp -= amount;
        Game.Instance.TopUI.HpView.SetData(Hp);
        if (Hp <= 0) {
            Debug.Log("Вы проиграли!!!");
        }
    }

    public void AddCoins(int amount = 1) {
        PlayerInventory.Coins += amount;
        Game.Instance.TopUI.CoinsView.SetData(PlayerInventory.Coins);
    }
}