using TMPro;
using UnityEngine;

public class EnergyView : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI _hasText, _allText;

    public void SetData(int has, int all) {
        _hasText.text = has.ToString();
        _allText.text = all.ToString();
    }
}
