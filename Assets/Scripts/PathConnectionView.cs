using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class PathConnectionView : MonoBehaviour {
    [SerializeField]
    private RectTransform _uiLine;

    public void Init(PathButton from, PathButton to) {
        Vector3 fromP = from.transform.position;
        Vector3 toP = to.transform.position;
        _uiLine.transform.position = fromP;
        _uiLine.sizeDelta = new Vector2(_uiLine.sizeDelta.x, (fromP - toP).magnitude);
        _uiLine.transform.up = toP - fromP;
    }
}