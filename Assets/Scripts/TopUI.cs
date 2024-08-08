using UnityEngine;

public class TopUI : MonoBehaviour {
    [SerializeField]
    private HpView _hpView;

    public HpView HpView => _hpView;

    [SerializeField]
    private DayView _dayView;

    public DayView DayView => _dayView;

    [SerializeField]
    private CoinsView _coinsView;

    public CoinsView CoinsView => _coinsView;
}