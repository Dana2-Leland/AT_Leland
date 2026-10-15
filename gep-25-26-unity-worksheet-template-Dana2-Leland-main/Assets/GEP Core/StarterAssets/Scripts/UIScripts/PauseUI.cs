using UnityEngine;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    public Button pauseButton;
    public State state;

    public void OnPauseMenuButtonUI()
    {
        state.switchState();
    }
    public void OnQuitButton() {
        Application.Quit();
    }
}
