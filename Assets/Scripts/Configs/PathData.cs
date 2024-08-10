using System;
using System.Collections.Generic;

[Serializable]
public class PathData {
    public int Stage;
    public List<List<string>> GeneratedDaysUids = new List<List<string>>();
    public List<Connection> Connections = new List<Connection>();
}

[Serializable]
public class Connection {
    public string From;
    public string To;
}
