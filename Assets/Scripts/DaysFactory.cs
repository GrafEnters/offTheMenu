using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DaysFactory : MonoBehaviour {
    [SerializeField]
    private List<DayConfig> _dayConfigs;

    public static DaysFactory Instance;

    private void Awake() {
        Instance = this;
    }

    public CookingDayConfig GetCookingDay(string uid) {
        return _dayConfigs.FirstOrDefault(d => d.Uid == uid) as CookingDayConfig;
    }
}