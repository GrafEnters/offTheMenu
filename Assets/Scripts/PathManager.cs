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
        data.GeneratedDaysUids.Add(new List<string>());

        int minHardness = stage * PathConfig.LinesAmount;

        for (int i = 1; i < PathConfig.LinesAmount - 1; i++) {
            data.GeneratedDaysUids.Add(GenerateLine(minHardness + i));
        }

        GenerateBossLine(stage * PathConfig.LinesAmount);
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

    private void SetView(PathData data) {
        _pathLine[0].GenerateEntryLine();
        for (int i = 1; i < data.GeneratedDaysUids.Count - 1; i++) {
            _pathLine[i].SetLineView(data.GeneratedDaysUids[i]);
        }

        _pathLine[^1].SetBossLine(data.GeneratedDaysUids.Last());
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