using System;
using UnityEngine;

public class Game : MonoBehaviour {
    public static Game Instance;

    public GameManager GameManager;

    public HandView HandView;
    public BottomUI BottomUI;

    private void Awake() {
        Instance = this;
        GameManager = new GameManager();
        GameManager.InitNewGame();
    }
}