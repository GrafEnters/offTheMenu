using System.Collections.Generic;

public class Deck {
    public List<CardData> CardDatas = new List<CardData>();

    public void GenerateDeck() {
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("veggie0"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("veggie0"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("veggie0"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("veggie1"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("meat0"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("meat0"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("meat0"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("meat1"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("pan0"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("pan0"));
        CardDatas.Add(CardFactory.GetPrefabricatedCardData("pan0"));
    }
}