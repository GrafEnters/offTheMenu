using System;
using UnityEngine;

public class Game : MonoBehaviour {
    public static Game Instance;

    public GameManager GameManager;

    public HandView HandView;
    public BottomUI BottomUI;
    public TopUI TopUI;
    public CustomerPanel CustomerPanel;

    private void Awake() {
        Instance = this;
        GameManager = new GameManager();
    }

    private void Start() {
        GameManager.InitNewGame();
    }
}