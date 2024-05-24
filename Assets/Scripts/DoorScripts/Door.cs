using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    public string GetDescription()
    {
        return "����� [E] ����� <color=green>�����������</color> �� ������ �������";
    }

    public void Interact()
    {
        int randomScene = Random.Range(3, 5);
        SceneManager.LoadScene(randomScene);
    }
}