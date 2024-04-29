using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Update()
    {
        // ���������, ���� �� ������ ������ Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // �������� ������ ������� �����
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // ���������, ��� ��� �� ������ ����� � ������
            if (currentSceneIndex > 0)
            {
                // ��������� ���������� �����
                SceneManager.LoadScene(currentSceneIndex - 1);
            }
        }

        // ���������, ���� �� ������ ������ E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // �������� ������ ������� �����
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // ���������, ��� ��������� ����� ����������
            if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                // ��������� ��������� �����
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }
    }
}