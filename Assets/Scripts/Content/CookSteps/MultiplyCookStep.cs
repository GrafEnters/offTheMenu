public class MultiplyCookStep : ICookStep {

    private int _multiplier;
    private CardTag _conditionTag;
    public MultiplyCookStep(int multiplier, CardTag conditionTag = CardTag.None) {
        _multiplier = multiplier;
        _conditionTag = conditionTag;
    }
    public CardData CookFoodCard(CardData combinedFood) {
        if (_conditionTag != CardTag.None) {
            if (!combinedFood.CheckTag(_conditionTag)) {
                return combinedFood;
            }
        }
        combinedFood.Delicious *= _multiplier;
        return combinedFood;
    }
}
