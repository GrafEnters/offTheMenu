using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public void StartGame() {
        GameManager.IsGameInited = false;
        SceneManager.LoadScene("PathScene");
    }
}