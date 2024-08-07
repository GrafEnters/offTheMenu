using System;
using UnityEngine;

public class CardHolder : CardTarget {
    private CardView _cardView;

    public CardView CardView => _cardView;

    public void InitHolder(Func<CardView, bool> canEndDragOnTarget) {
        Init(canEndDragOnTarget, onEndDragOnHolder);
    }

    private void onEndDragOnHolder(CardView cardView) {
        _cardView = cardView;
        _cardView.transform.SetParent(transform);
        _cardView.transform.localPosition = Vector3.zero;
        _cardView.transform.rotation = Quaternion.identity;
        _cardView.OnMoved += ClearHolder;
        _cardView.OnDestroyed += ClearHolder;
    }

    private void ClearHolder(CardView card) {
        _cardView.OnMoved -= ClearHolder;
        _cardView.OnDestroyed -= ClearHolder;
        _cardView = null;
    }
}