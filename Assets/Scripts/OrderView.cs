using TMPro;
using UnityEngine;

public class OrderView : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI _deliciousText;

    [SerializeField]
    private Transform _greenHolder, _redHolder;

    public void SetData(OrderData data) {
        _deliciousText.text = data.MinDelicious + "+";
        for (int i = 0; i < _greenHolder.childCount; i++) {
            Destroy(_greenHolder.GetChild(0).gameObject);
        }

        for (int i = 0; i < _redHolder.childCount; i++) {
            Destroy(_redHolder.GetChild(0).gameObject);
        }

        if (data.GreenTags.Count == 0) {
            _greenHolder.gameObject.SetActive(false);
        } else {
            _greenHolder.gameObject.SetActive(true);
            foreach (var tagData in data.GreenTags) {
                TagView tag = TagFactory.Instance.GetTagView(tagData);
                tag.transform.SetParent(_greenHolder);
            }
        }

        if (data.RedTags.Count == 0) {
            _redHolder.gameObject.SetActive(false);
        } else {
            _redHolder.gameObject.SetActive(true);
            foreach (var tagData in data.RedTags) {
                TagView tag = TagFactory.Instance.GetTagView(tagData);
                tag.transform.SetParent(_redHolder);
            }
        }
    }
}