using UnityEngine;
using UnityEngine.SceneManagement;

public class VanScript : MonoBehaviour, IInteractable
{
    public string GetDescription()
    {
        return "Нажми [E] чтобы <color=green>уехать</color> домой";
    }

    public void Interact()
    {
        if (StaticInfo.CapturedImages.Count >= 5)
            SceneManager.LoadScene(2);

    }
}