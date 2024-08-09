using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CookingDayConfig", menuName = "Scriptable Objects/CookingDayConfig")]
public class CookingDayConfig : DayConfig {
    [SerializeField]
    private List<CustomerData> _customers;
    public List<CustomerData> CustomerDatas => _customers;
}