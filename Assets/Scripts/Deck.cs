using System.Collections.Generic;
using UnityEngine;

public class Deck {
    public List<CardData> CardDatas = new List<CardData>();

    public void GenerateDeck() {
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("ovoshBase"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("ovoshBase"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("ovoshBase"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("ovoshRare"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("myacoBase"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("myacoBase"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("myacoBase"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("myacoRare"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("fryingPanBase"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("fryingPanBase"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("fryingPanBase"));
    }
}