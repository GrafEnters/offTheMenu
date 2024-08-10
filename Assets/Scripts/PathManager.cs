using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class PathManager : MonoBehaviour {
    public static PathConfig PathConfig => ConfigsTable.Instance.PathConfig;

    [SerializeField]
    private List<PathLine> _pathLine = new List<PathLine>();

    [SerializeField]
    private PathConnectionView _connectionPrefab;

    [SerializeField]
    private Transform _connectionsHolder;

    public static PathManager Instance;
    public static string NextLevelUid;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        SetView(OffTheMenuSaveLoadManager.Profile.PathData);
    }

    public static PathData GeneratePath(int stage) {
        PathData data = new PathData();
        data.Stage = stage;
        data.GeneratedDaysUids = new List<List<string>>();
        data.GeneratedDaysUids.Add(new List<string>(){DaysFactory.Instance.GetEntryDay(stage * PathConfig.LinesAmount).Uid});

        int minHardness = stage * PathConfig.LinesAmount;

        for (int i = 1; i < PathConfig.LinesAmount - 1; i++) {
            data.GeneratedDaysUids.Add(GenerateLine(minHardness + i));
        }

        data.GeneratedDaysUids.Add(GenerateBossLine(stage * PathConfig.LinesAmount));
        List<Connection> connections = new List<Connection>();  
        for (int i = 0; i < data.GeneratedDaysUids.Count - 1; i++) {
            connections.AddRange(GenerateConnections(data.GeneratedDaysUids[i], data.GeneratedDaysUids[i + 1]));
        }

        data.Connections = connections;
        return data;
    }

    private static List<string> GenerateLine(int hardness) {
        float buttonsAmountChance = Random.Range(0, 1f);
        int buttonsAmount;
        if (buttonsAmountChance <= PathConfig.LineOfThreePercent) {
            buttonsAmount = 3;
        } else if (buttonsAmountChance <= PathConfig.LineOfFourPercent) {
            buttonsAmount = 4;
        } else {
            buttonsAmount = 5;
        }

        List<string> days = new List<string>();
        for (int i = 0; i < buttonsAmount; i++) {
            DayConfig d = DaysFactory.Instance.GetDayByHardness(hardness);
            days.Add(d.Uid);
        }

        return days;
    }

    private static List<string> GenerateBossLine(int hardness) {
        return new List<string>() { DaysFactory.Instance.GetBossDayByHardness(hardness).Uid };
    }

    private static List<Connection> GenerateConnections(List<string> from, List<string> to) {
        List<Connection> connections = new List<Connection>();
        foreach (var from1 in from) {
            string to1 = to[Random.Range(0, to.Count)];
            connections.Add(new Connection() {
                From = from1, To = to1
            });
            
            /*if (to.Count > 1) {
                if (Random.Range(0, 1f) < PathConfig.ChanceOfSecondPath) {
                    string to2 = to[Random.Range(0, to.Count)];
                    while (to2 != to1) {
                        to2 = to[Random.Range(0, to.Count)];
                    }

                    connections.Add(new Connection() {
                        From = VARIABLE, To = to2
                    });
                }
            }*/
        }
        
        foreach (var to1 in to) {
            if (connections.All(c => c.To != to1)) {
                string from1 = from[Random.Range(0, from.Count)];
                connections.Add(new Connection() {
                    From = from1, To = to1
                }); 
            }
        }

        return connections;
    }

    private void SetView(PathData data) {
        _pathLine[0].GenerateEntryLine(data);
        for (int i = 1; i < data.GeneratedDaysUids.Count - 1; i++) {
            _pathLine[i].SetLineView(data.GeneratedDaysUids[i]);
        }

        _pathLine[^1].SetBossLine(data.GeneratedDaysUids.Last());

        CreateConnections(data);
    }

    private void CreateConnections(PathData data) {
        PathButton[] btns = FindObjectsByType<PathButton>(FindObjectsSortMode.None);
        foreach (var VARIABLE in data.Connections) {
            PathConnectionView c = Instantiate(_connectionPrefab, _connectionsHolder);
            c.Init(btns.First(b => b.Uid == VARIABLE.From), btns.First(b => b.Uid == VARIABLE.To));
        }
    }

    public void SelectLevel(DayConfig config) {
        if (config.DayType == DayType.Fight || config.DayType == DayType.Elite || config.DayType == DayType.Boss) {
            StartFightDay(config);
        } else {
            Debug.Log("lol kek");
        }
    }

    private static void StartFightDay(DayConfig config) {
        NextLevelUid = config.Uid;
        SceneManager.LoadScene("GameScene");
    }
}