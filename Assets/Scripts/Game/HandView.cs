using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class HandView : MonoBehaviour {
    private List<CardView> _cardViews = new List<CardView>();

    [SerializeField]
    private Transform _cardHolder;

    [SerializeField]
    private Transform _handCenterPoint, _middleCardPoint, _farthestLeftCard;

    [SerializeField]
    private float _handRadius, _handAngle;

    public void AddRandomCard() {
        CardData data = new CardData();
        data.Name = "Ovosh#" + Random.Range(0, 99);
        AddCard(data);
    }

    public void AddCard(CardData data) {
        CardView newCard = CardFactory.Instance.GetCard(data);
        _cardViews.Add(newCard);

        //TODO newcard must be held in hand
        newCard.transform.SetParent(_cardHolder);
    }

    public void RemoveFirstCard() {
        CardView c = _cardViews.First();
        _cardViews.Remove(c);
        c.DestroyCard();
    }

    private void Update() {
        UpdatePoses();
    }

    private void UpdatePoses() {
        int nextIndex = _cardViews.Count;
        float angle = _handAngle / _cardViews.Count;

        float radius = _farthestLeftCard.transform.localPosition.x;
        bool isEven = _cardViews.Count % 2 == 0;
        for (int index = 0; index < _cardViews.Count; index++) {
            CardView VARIABLE = _cardViews[index];

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
            VARIABLE.RectTransform.localPosition = newPos;
            VARIABLE.RectTransform.up = VARIABLE.RectTransform.position - _handCenterPoint.position;
        }
    }
}