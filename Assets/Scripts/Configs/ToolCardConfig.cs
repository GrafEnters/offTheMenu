using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ToolCardConfig", menuName = "Scriptable Objects/ToolCardConfig")]
public class ToolCardConfig : CardConfig {
    public override CardData GetCardData() {
        return new CookingToolCardData() {
            Name = CardName,
            Delicious = Delicious,
            CardTypes = new List<CardType>(CardTypes),
            CardTags = new List<CardTag>(CardTags),
            CookSteps = {
                
                //TODO remade via parser
                new ReplaceTagCookStep(CardTag.Raw, CardTag.Fried),
                new MultiplyCookStep(2, CardTag.Fried)
            }
        };
    }
}