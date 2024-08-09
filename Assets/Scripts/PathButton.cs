using UnityEngine;
using UnityEngine.UI;

public class PathButton : MonoBehaviour {
    [SerializeField]
    private Button _button;

    private string _uid;

    public void Init(string uid) {
        _uid = uid;
        _button.onClick.AddListener(OnSelected);
    }

    public void OnSelected() {
        PathManager.Instance.SelectLevel(_uid);
    }
}