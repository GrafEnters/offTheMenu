using System;
using System.Collections.Generic;

[Serializable]
public class PathData {
    public int Stage;
    public List<List<string>> GeneratedDaysUids = new List<List<string>>();
}
