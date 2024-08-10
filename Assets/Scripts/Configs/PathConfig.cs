using UnityEngine;

[CreateAssetMenu(fileName = "PathConfig", menuName = "Scriptable Objects/PathConfig")]

public class PathConfig : ScriptableObject {
    public int LinesAmount = 5;
    public float LineOfThreePercent = 0.3f;
    public float LineOfFourPercent = 0.75f;
    public float ChanceOfSecondPath = 0.3f;

    public float MaxPathButtonViewShift = 1f;
    
    public int MaxShops = 3;
    public int MaxQuestions = 10;
    public int MaxElites = 3;
    public int MaxRewards = 0;
    
}
