using System;
using System.Collections.Generic;

public class CardData {
    public string Uid;
    public string Name;
    public List<CardType> CardTypes = new List<CardType>();
    public List<CardTag> CardTags = new List<CardTag>();
    public List<CardMechanics> CardMechanics = new List<CardMechanics>();
    public bool CheckType(CardType type) => CardTypes.Contains(type);
    public bool CheckTag(CardTag tag) => CardTags.Contains(tag);
    public bool CheckMechanics(CardMechanics mech) => CardMechanics.Contains(mech);

    public int Delicious = 0;
}
[Serializable]
public enum CardType {
    Food,
    CookedFood,
    Tool,
    Buff,
    Other
}

[Serializable]
public enum CardTag {
    None = 0,
    Raw,
    Fried,
    Baked,
    Boiled,
    Meaty,
    Sweet
}
[Serializable]
public enum CardMechanics {
    None = 0,
    Burn ,
    BurnAfterAte
}