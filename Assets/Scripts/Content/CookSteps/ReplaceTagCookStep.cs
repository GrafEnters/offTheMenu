public class ReplaceTagCookStep : ICookStep {
    private CardTag _from, _to;

    public ReplaceTagCookStep(CardTag from, CardTag to = CardTag.None) {
        _from = from;
        _to = to;
    }

    public CardData CookFoodCard(CardData combinedFood) {
        if (combinedFood.CheckTag(_from)) {
            combinedFood.CardTags.Remove(_from);
            if (_to != CardTag.None) {
                combinedFood.CardTags.Add(_to);
            }
        }

        return combinedFood;
    }
}