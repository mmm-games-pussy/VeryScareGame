using UnityEngine;
using UnityEngine.SceneManagement;

public class Door1 : MonoBehaviour, IInteractable
{
    public string GetDescription()
    {
        return "����� [E] ����� <color=green>�����������</color> �� ��������� �������";
    }

    public void Interact()
    {
        SceneManager.LoadScene(5);
    }
}