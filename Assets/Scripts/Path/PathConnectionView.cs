using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class PathConnectionView : MonoBehaviour {
    [SerializeField]
    private RectTransform _uiLine;

    [SerializeField]
    private Image _image;

    private string _from, _to;
    public string From => _from;
    public string To => _to;
    
    public void Init(PathButton from, PathButton to) {
        _from = from.Uid;
        _to = to.Uid;
        Vector3 fromP = from.transform.position;
        Vector3 toP = to.transform.position;
        _uiLine.transform.position = fromP;
        _uiLine.sizeDelta = new Vector2(_uiLine.sizeDelta.x, (fromP - toP).magnitude);
        _uiLine.transform.up = toP - fromP;
    }

    public void SetAttention(bool isOn) {
        Color tmp = _image.color;
        tmp.a = isOn ? 1 : 0.45f;
        _image.color = tmp;
    }
}