using System.Collections.Generic;
using UnityEngine;

public class CoinsView : MonoBehaviour {
    [SerializeField]
    private Transform _hpHolder;

    [SerializeField]
    private GameObject _coinPrefab;

    private List<GameObject> _coins = new List<GameObject>();

    public void SetData(int amount) {
        int added = amount - _coins.Count;
        for (int i = 0; i < added; i++) {
            _coins.Add(Instantiate(_coinPrefab, _hpHolder));
        }

        for (int i = 0; i < _coins.Count; i++) {
            _coins[i].SetActive(i < amount);
        }
    }
}
