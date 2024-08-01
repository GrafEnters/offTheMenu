using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenuDialog : MonoBehaviour {
    public void Toggle() {
        gameObject.SetActive(!gameObject.activeSelf);
    }

    public void GoToMenu() {
        SceneManager.LoadScene("MenuScene");
    }

    public void StartAgain() {
        SceneManager.LoadScene("GameScene");
    }
}