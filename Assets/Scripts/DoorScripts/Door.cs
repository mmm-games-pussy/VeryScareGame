using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, IInteractable
{

    public string GetDescription()
    {
        return "����� [E] ����� <color=green>�����������</color> �� �������";
    }

    public void Interact()
    {
        int randomScene = Random.Range(1, 3);
        SceneManager.LoadScene(randomScene);
    }
}