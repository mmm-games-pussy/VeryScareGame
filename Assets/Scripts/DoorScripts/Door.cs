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
<<<<<<< HEAD
        int randomScene = Random.Range(3, 5);
        SceneManager.LoadScene(randomScene);
=======
        SceneManager.LoadScene(3);
>>>>>>> 0420d3232d163e49a3697b0fb656abec0ecdd2f9
    }
}