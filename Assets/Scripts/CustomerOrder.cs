using UnityEngine;

public class CustomerOrder : MonoBehaviour {
    [SerializeField]
    private OrderView _basicOrder;

    [SerializeField]
    private OrderView _qualityOrder;

    [SerializeField]
    private GameObject _backOneLine, _backTwoLines;

    public void SetData(OrderData basic, OrderData quality = null) {
        _backOneLine.SetActive(quality == null);
        _backTwoLines.SetActive(quality != null);
        _basicOrder.SetData(basic);
        if (quality != null) {
            _qualityOrder.SetData(quality);
            _qualityOrder.gameObject.SetActive(true);
        } else {
            _qualityOrder.gameObject.SetActive(false);
        }
    }
}