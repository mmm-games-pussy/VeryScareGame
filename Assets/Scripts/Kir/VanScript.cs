using UnityEngine;
using UnityEngine.SceneManagement;

public class VanScript : MonoBehaviour, IInteractable
{
    public string GetDescription()
    {
        return "����� [E] ����� <color=green>������</color> �����";
    }

    public void Interact()
    {
        if (StaticInfo.CapturedImages.Count >= 5)
            SceneManager.LoadScene(2);

    }
}