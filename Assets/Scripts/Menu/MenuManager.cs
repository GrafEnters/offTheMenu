using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
    public void StartGame() {
        GameManager.IsGameInited = false;
        DaysFactory.Instance.RefillUniqueDays();
        OffTheMenuSaveLoadManager.Profile.PathData = PathManager.GeneratePath(0);
        SceneManager.LoadScene("PathScene");
    }
}