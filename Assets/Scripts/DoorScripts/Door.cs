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
        SceneManager.LoadScene(4);
    }
}