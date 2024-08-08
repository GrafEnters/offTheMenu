using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CardConfig", menuName = "Scriptable Objects/CardConfig")]
public class CardConfig : ScriptableObject {
    public string Uid;
    public string CardName;
    public int Delicious;
    public List<CardType> CardTypes = new List<CardType>();
    public List<CardTag> CardTags = new List<CardTag>();
    public List<CardMechanics> CardMechanics = new List<CardMechanics>();

    public virtual CardData GetCardData() {
        return new CardData() {
            Name = CardName,
            Delicious = Delicious,
            CardTypes = new List<CardType>(CardTypes),
            CardTags = new List<CardTag>(CardTags)
        };
    }
}
