using UnityEngine;

public class GameMenuManager : MonoBehaviour {
    [SerializeField]
    private GameMenuDialog _menuDialog;

    [SerializeField]
    private KeyCode _keyToToggleMenu;

    private void Update() {
        if (Input.GetKeyDown(_keyToToggleMenu)) {
            _menuDialog.Toggle();
        }
    }
}