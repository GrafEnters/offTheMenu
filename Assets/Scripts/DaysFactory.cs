using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DaysFactory : Singleton<DaysFactory> {
    [SerializeField]
    private DaysListConfig _daysList;

    private List<DayConfig> _uniqueDays;

    public void RefillUniqueDays() {
        _uniqueDays = new List<DayConfig>(_daysList.DaysList);
    }

    public DayConfig GetDayByHardness(int hardness) {
        DayConfig d = _uniqueDays.FirstOrDefault(d => d.MinHardness <= hardness && d.MaxHardness >= hardness);
        _uniqueDays.Remove(d);
        if (d == null) {
            Debug.LogError("no day for hardness " + hardness);
        }

        return d;
    }

    public DayConfig GetBossDayByHardness(int hardness) {
        DayConfig d = _uniqueDays.FirstOrDefault(d => d.MinHardness <= hardness && d.MaxHardness >= hardness && d.IsBoss);
        _uniqueDays.Remove(d);
        return d;
    }

    public CookingDayConfig GetCookingDay(string uid) {
        return _daysList.DaysList.FirstOrDefault(d => d.Uid == uid) as CookingDayConfig;
    }

    public DayConfig GetDayByUid(string uid) => _daysList.DaysList.FirstOrDefault(d => d.Uid == uid);
}