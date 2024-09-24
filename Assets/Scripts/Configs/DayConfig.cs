using System;
using UnityEngine;

[CreateAssetMenu(fileName = "DayConfig", menuName = "Scriptable Objects/DayConfig")]
public class DayConfig : ScriptableObject {
    public string Uid;
    public string DayName = "";
    public DayType DayType;
    [Min(0)]
    public int MinHardness, MaxHardness;

    public bool IsBoss;
}

[Serializable]
public enum DayType {
    Entry,
    Fight,
    Elite,
    Boss,
    Question,
    Shop
}