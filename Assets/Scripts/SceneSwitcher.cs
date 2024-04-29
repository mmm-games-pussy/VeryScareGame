using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    void Update()
    {
        // Проверяем, была ли нажата кнопка Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Получаем индекс текущей сцены
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Проверяем, что это не первая сцена в списке
            if (currentSceneIndex > 0)
            {
                // Загружаем предыдущую сцену
                SceneManager.LoadScene(currentSceneIndex - 1);
            }
        }

        // Проверяем, была ли нажата кнопка E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Получаем индекс текущей сцены
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Проверяем, что следующая сцена существует
            if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
            {
                // Загружаем следующую сцену
                SceneManager.LoadScene(currentSceneIndex + 1);
            }
        }
    }
}