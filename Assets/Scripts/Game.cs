using System;
using UnityEngine;

public class Game : MonoBehaviour {
    public static Game Instance;

    public GameManager GameManager;

    private void Awake() {
        Instance = this;
        GameManager = new GameManager();
    }
}