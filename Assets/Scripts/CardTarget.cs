using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardTarget : MonoBehaviour {
    protected Func<CardView, bool> _canEndDragOnTarget;
    protected Action<CardView> _onEndDragOnTarget;

    [SerializeField]
    private EventTrigger _eventTrigger;

    protected void Awake() {
        EventTrigger.Entry enterEvent = new EventTrigger.Entry() {
            eventID = EventTriggerType.PointerEnter
        };
        enterEvent.callback.AddListener(OnMouseEnterTarget);
        _eventTrigger.triggers.Add(enterEvent);

        EventTrigger.Entry exitEvent = new EventTrigger.Entry() {
            eventID = EventTriggerType.PointerExit
        };
        exitEvent.callback.AddListener(OnMouseExitTarget);
        _eventTrigger.triggers.Add(exitEvent);
    }

    public void Init(Func<CardView, bool> canEndDragOnTarget, Action<CardView> onEndDragOnTarget) {
        _canEndDragOnTarget = canEndDragOnTarget;
        _onEndDragOnTarget = onEndDragOnTarget;
    }

    protected virtual void OnMouseEnterTarget(BaseEventData data) {
        CardDragManager.Instance.CanEndDragOnTarget += _canEndDragOnTarget;
        CardDragManager.Instance.OnEndDragOnTarget += _onEndDragOnTarget;
    }

    protected virtual void OnMouseExitTarget(BaseEventData data) {
        CardDragManager.Instance.CanEndDragOnTarget -= _canEndDragOnTarget;
        CardDragManager.Instance.OnEndDragOnTarget -= _onEndDragOnTarget;
    }

    private void OnDisable() {
        OnMouseExitTarget(null);
    }
}