using TMPro;
using UnityEngine;

public class DayView : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI _text;


    public void SetData(string dayName) {
        _text.text = dayName;
    }
}