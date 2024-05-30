using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    [SerializeField] private FirstPersonController _fpController;

    public GameObject pauseMenuPanel;
    public GameObject settingsPanel;
    public Button continueButton;
    public Button mainMenuButton;
    public Button lobbyButton;
    public Button settingsButton;
    public Button backButton;

    private bool isPaused = false;

    void Start()
    {
        continueButton.onClick.AddListener(ContinueGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        lobbyButton.onClick.AddListener(ReturnToLobby);
        settingsButton.onClick.AddListener(OpenSettings);
        backButton.onClick.AddListener(CloseSettings);

        pauseMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        isPaused = true;
        pauseMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _fpController.cameraCanMove = false;
    }

    public void ContinueGame()
    {
        isPaused = false;
        pauseMenuPanel.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _fpController.cameraCanMove = true;
    }

    void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    void ReturnToLobby()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LobbyScene");
    }

    void OpenSettings()
    {
        pauseMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    void CloseSettings()
    {
        pauseMenuPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}