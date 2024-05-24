using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public Button continueButton;
    public Button mainMenuButton;
    public Button lobbyButton;

    private bool isPaused = false;

    void Start()
    {
        // ������������� �� ������� ������
        continueButton.onClick.AddListener(ContinueGame);
        mainMenuButton.onClick.AddListener(ReturnToMainMenu);
        lobbyButton.onClick.AddListener(ReturnToLobby);

        // ���������� �������� ���� �����
        pauseMenuPanel.SetActive(false);
    }

    void Update()
    {
        // ��������/�������� ���� ����� �� ������� ESC
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
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ContinueGame()
    {
        isPaused = false;
        pauseMenuPanel.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void ReturnToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu"); // �������� �� �������� ����� ����� �������� ����
    }

    void ReturnToLobby()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LobbyScene"); // �������� �� �������� ����� ����� �����
    }
}