using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomerPatience : MonoBehaviour {
    [SerializeField]
    private Gradient _colorGradient;

    [SerializeField]
    private Image _fill;

    [SerializeField]
    private TextMeshProUGUI _text;

    public void SetPercent(int left, int max) {
        _text.text = left.ToString();
        float percent = (left + 0f) / max;

        _fill.fillAmount = percent;

        _fill.color = _colorGradient.Evaluate(percent);
    }
}