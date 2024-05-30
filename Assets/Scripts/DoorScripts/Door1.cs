using UnityEngine;
using UnityEngine.SceneManagement;

public class Door1 : MonoBehaviour, IInteractable
{
    public string GetDescription()
    {
        return "Нажми [E] чтобы <color=green>отправиться</color> на последнюю вылазку";
    }

    public void Interact()
    {
        SceneManager.LoadScene(5);
    }
}