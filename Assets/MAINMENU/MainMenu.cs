using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("LobbyScene");
    }

    public void OpenSettings()
    {
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
