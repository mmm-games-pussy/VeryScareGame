using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    public string GetDescription()
    {
        return "Нажми [E] чтобы <color=green>отправиться</color> на первую вылазку";
    }

    public void Interact()
    {
        SceneManager.LoadScene(4);
    }
}