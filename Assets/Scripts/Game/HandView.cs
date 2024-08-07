using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HandView : MonoBehaviour {
    private List<CardView> _cardViews = new List<CardView>();

    [SerializeField]
    private Transform _cardHolder;

    [SerializeField]
    private Transform _handCenterPoint, _farthestLeftCard;

    [SerializeField]
    private CardTarget _dropTarget;
    
    [SerializeField]
    private float _handRadius, _handAngle;

    private void Awake() {
        _dropTarget.Init(CanEndDragInHand,OnEndDragInHand);
    }

    public void AddCard(CardData data) {
        CardView newCard = CardFactory.Instance.GetCard(data);
        AddCardView(newCard);
    }

    public void DrawCards(List<CardData> cards) {
        foreach (var VARIABLE in cards) {
            AddCard(VARIABLE);
        }
    }

    private bool CanEndDragInHand(CardView card) {
        return !_cardViews.Contains(card);
    }

    private void OnEndDragInHand(CardView card) {
        AddCardView(card);
    }

    private void AddCardView(CardView card) {
        _cardViews.Add(card);
        card.transform.SetParent(_cardHolder);
        card.OnMoved += RemoveCard;
        card.OnDestroyed += RemoveCard;
    }

    public void StashAllCards() {
        int count = _cardViews.Count;
        for (int i = 0; i < count; i++) {
            _cardViews.First().StashCard();
        }
        _cardViews.Clear();
    }

    private void RemoveCard(CardView card) {
        if (_cardViews.Contains(card)) {
            _cardViews.Remove(card);
        }

        card.OnMoved -= RemoveCard;
        card.OnDestroyed -= RemoveCard;
    }

    private void LateUpdate() {
        UpdatePoses();
    }

    private void UpdatePoses() {
        int nextIndex = _cardViews.Count;
        float angle = _handAngle / _cardViews.Count;

        float radius = _farthestLeftCard.transform.localPosition.x;
        bool isEven = _cardViews.Count % 2 == 0;
        for (int index = 0; index < _cardViews.Count; index++) {
            CardView card = _cardViews[index];
            if (CardDragManager.DraggingCard == card) {
                continue;
            }

            Vector3 newPos = Vector3.zero;
            int half = _cardViews.Count / 2;

            if (isEven) {
                if (index < half) {
                    newPos.x = -radius * 2 * (-0.5f + half - index) / _cardViews.Count;
                } else {
                    newPos.x = radius * 2 * (0.5f + index - half) / _cardViews.Count;
                }
            } else {
                if (index == half) { } else if (index < half) {
                    newPos.x = -radius * 2 * (0.5f + half - index) / _cardViews.Count;
                } else {
                    newPos.x = radius * 2 * (0.5f + index - half) / _cardViews.Count;
                }
            }

            float percent = _cardViews.Count > 1 ? Mathf.Max(0, 0f + index) / (_cardViews.Count - 1) : 0.5f;
            newPos.y += Mathf.Sin(Mathf.PI * percent) * _handRadius;
            card.RectTransform.localPosition = newPos;
            card.RectTransform.up = card.RectTransform.position - _handCenterPoint.position;
        }
    }
}