using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathLine : MonoBehaviour {
    [SerializeField]
    private List<PathButton> _pathButtons;

    private List<PathButton> _enabledButtons;
    
    public void SetEntryLine(PathData data) {
        DisableButtons();
        _enabledButtons = new List<PathButton>();
        PathButton b = _pathButtons[2];
        var config = DaysFactory.Instance.GetDayByUid(data.GeneratedDaysUids.First().First());
        b.SetAsEntryDay(config);
        _enabledButtons.Add(b);
        SetButtonPosition(b,data, config);
    }

    private static void SetButtonPosition( PathButton b,PathData data, DayConfig config) {
        if (data.ViewPoses.ContainsKey(config.Uid)) {
            b.transform.position = data.ViewPoses[config.Uid];
        } else {
            b.transform.position += Random.insideUnitSphere * Random.Range(0, 1f) * PathManager.PathConfig.MaxPathButtonViewShift;
            data.ViewPoses.Add(config.Uid, b.transform.position);
        }
    }

    public void SetBossLine(PathData data, List<string> uids) {
        DisableButtons();
        _enabledButtons = new List<PathButton>();
        PathButton b = _pathButtons[2];

        DayConfig config = DaysFactory.Instance.GetDayByUid(uids.First());
        b.Init(config);
        _enabledButtons.Add(b);
        SetButtonPosition(b, data, config);
    }

    public void SetLineView(PathData data, List<string> uids) {
        DisableButtons();
        
        int amountToDisable = _pathButtons.Count - uids.Count;
        _enabledButtons = new List<PathButton>(_pathButtons);
        for (int i = 0; i < amountToDisable; i++) {
            PathButton b = _enabledButtons[Random.Range(0, _enabledButtons.Count)];
            _enabledButtons.Remove(b);
        }

        for (int index = 0; index < _enabledButtons.Count; index++) {
            PathButton b = _enabledButtons[index];
            DayConfig config = DaysFactory.Instance.GetDayByUid(uids[index]);
            b.Init(config);
            SetButtonPosition(b, data, config);
        }
    }

    private void DisableButtons() {
        foreach (PathButton pathButton in _pathButtons) {
            pathButton.gameObject.SetActive(false);
        }
    }
}