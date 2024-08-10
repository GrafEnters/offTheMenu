using UnityEngine;

public class ConfigsTable : Singleton<ConfigsTable> {
    [SerializeField]
    private PathConfig _pathConfig;

    public PathConfig PathConfig => _pathConfig;
    
}