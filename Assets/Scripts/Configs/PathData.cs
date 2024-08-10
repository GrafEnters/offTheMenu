using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PathData {
    public int Stage;
    public string CurrentPlace;
    public List<List<string>> GeneratedDaysUids = new List<List<string>>();
    public List<Connection> Connections = new List<Connection>();
    public Dictionary<string, Vector3> ViewPoses = new Dictionary<string, Vector3>();
}

[Serializable]
public class Connection {
    public string From;
    public string To;
}
