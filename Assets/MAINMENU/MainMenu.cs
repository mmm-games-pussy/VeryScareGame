using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject settingsPanel;

    public void PlayGame()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void Exit()
    {
        settingsPanel.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
