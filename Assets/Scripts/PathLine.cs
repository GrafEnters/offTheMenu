using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathLine : MonoBehaviour {
    [SerializeField]
    private List<PathButton> _pathButtons;

    private List<PathButton> _enabledButtons;
    
    public void GenerateEntryLine(PathData data) {
        DisableButtons();
        _enabledButtons = new List<PathButton>();
        PathButton b = _pathButtons[2];
        b.SetAsEntryDay(DaysFactory.Instance.GetDayByUid(data.GeneratedDaysUids.First().First()));
        _enabledButtons.Add(b);
    }

    public void SetBossLine(List<string> uids) {
        DisableButtons();
        _enabledButtons = new List<PathButton>();
        PathButton b = _pathButtons[2];

        DayConfig d = DaysFactory.Instance.GetDayByUid(uids.First());
        b.Init(d);
        _enabledButtons.Add(b);
    }

    public void SetLineView(List<string> uids) {
        DisableButtons();
        
        int amountToDisable = _pathButtons.Count - uids.Count;
        _enabledButtons = new List<PathButton>(_pathButtons);
        for (int i = 0; i < amountToDisable; i++) {
            PathButton b = _enabledButtons[Random.Range(0, _enabledButtons.Count)];
            _enabledButtons.Remove(b);
        }

        for (int index = 0; index < _enabledButtons.Count; index++) {
            PathButton b = _enabledButtons[index];
            DayConfig d = DaysFactory.Instance.GetDayByUid(uids[index]);
            b.Init(d);
        }
    }

    private void DisableButtons() {
        foreach (PathButton pathButton in _pathButtons) {
            pathButton.gameObject.SetActive(false);
        }
    }
}