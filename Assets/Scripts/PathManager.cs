using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PathManager : MonoBehaviour {
    [SerializeField]
    private PathButton _button1, _button2, _button3;

    public static PathManager Instance;
    public static string NextLevelUid;
    private void Awake() {
        Instance = this;
    }

    private void Start() {
        GeneratePath();
    }

    private void GeneratePath() {
        _button1.Init("0");
        _button2.Init("1");
        _button3.Init("2");
    }

    public void SelectLevel(string uid) {
        NextLevelUid = uid;
        SceneManager.LoadScene("GameScene");
    }
}