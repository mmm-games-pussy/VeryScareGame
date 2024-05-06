using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{
    public bool isOpen;

    public string GetDescription()
    {
        return "Нажми [E] чтобы <color=green>отправиться</color> на вылазку";
    }

    public void Interact()
    {
        isOpen = !isOpen;
        int randomScene = Random.Range(1, 2);
        SceneManager.LoadScene(randomScene);
    }
}