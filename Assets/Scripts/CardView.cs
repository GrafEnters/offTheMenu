using TMPro;
using UnityEngine;

public class CardView : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI _cardName;

    public void SetData(CardData data) {
        _cardName.text = data.Name;
    }
}