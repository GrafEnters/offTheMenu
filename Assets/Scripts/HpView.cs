using System.Collections.Generic;
using UnityEngine;

public class HpView : MonoBehaviour {
    [SerializeField]
    private Transform _hpHolder;

    [SerializeField]
    private GameObject _hpPrefab;

    private List<GameObject> _hps = new List<GameObject>();

    public void SetData(int amount) {
        int added = amount - _hps.Count;
        for (int i = 0; i < added; i++) {
            _hps.Add(Instantiate(_hpPrefab, _hpHolder));
        }

        for (int i = 0; i < _hps.Count; i++) {
            _hps[i].SetActive(i < amount);
        }
    }
}