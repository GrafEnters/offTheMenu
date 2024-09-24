using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DaysListConfig", menuName = "Scriptable Objects/DaysListConfig")]
public class DaysListConfig : ScriptableObject {
    public List<DayConfig> DaysList;

    public List<string> DaysNames = new List<string>();
}