using System;
using UnityEngine;

public class CardDragManager : MonoBehaviour {
    public static CardDragManager Instance;
    public static CardView DraggingCard;

    [SerializeField]
    private Transform _draggingPanel, _dropHandPanel;

    private Transform _parent;
    private int _siblingIndex;
    private Vector3 _pos;
    private Quaternion _rotation;

    public Func<CardView,bool> CanEndDragOnTarget;
    public Action<CardView> OnEndDragOnTarget;

    private void Awake() {
        Instance = this;
    }

    public void StartDrag(CardView card) {
        DraggingCard = card;
        _parent = card.transform.parent;
        _siblingIndex = card.transform.GetSiblingIndex();
        _pos = card.transform.position;
        _rotation = card.transform.rotation;
        DraggingCard.transform.SetParent(_draggingPanel);
        DraggingCard.OnDestroyed += OnDestroyDraggingCard;
    }

    private void OnDestroyDraggingCard(CardView card) {
        DraggingCard = null;
        card.OnDestroyed -= OnDestroyDraggingCard;
    }

    private void Drag() {
        DraggingCard.RectTransform.position = Input.mousePosition;
        DraggingCard.RectTransform.rotation = Quaternion.identity;
    }

    private void Update() {
        if (DraggingCard == null) {
            _dropHandPanel.gameObject.SetActive(false);
            return;
        }
        _dropHandPanel.gameObject.SetActive(true);
        Drag();
    }

    public bool CheckEndDrag() {
        return CanEndDragOnTarget?.Invoke(DraggingCard) ?? false;
    }
    
    public void EndDrag(bool isForceRevertToPreviousPos = false) {
        bool res = CanEndDragOnTarget?.Invoke(DraggingCard) ?? false;

        if (res) {
            OnEndDragOnTarget?.Invoke(DraggingCard);
        }
        
        if (!res || isForceRevertToPreviousPos) {
            DraggingCard.transform.SetParent(_parent);
            DraggingCard.transform.SetSiblingIndex(_siblingIndex);
            DraggingCard.transform.position = _pos;
            DraggingCard.transform.rotation = _rotation;
        }

        DraggingCard = null;
    }
}