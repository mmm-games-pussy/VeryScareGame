using UnityEngine;
using UnityEngine.SceneManagement;

public class ObjectInteraction : MonoBehaviour
{
    public string interactableTag = "Interactable";
    public string targetTag = "Target";
    public string lobbySceneName = "Lobby";
    public KeyCode pickUpKey = KeyCode.E;
    public KeyCode interactKey = KeyCode.E;

    private GameObject pickedObject;
    private bool isHoldingObject = false;

    void Update()
    {
        if (Input.GetKeyDown(pickUpKey))
        {
            CheckForPickUp();
        }

        if (isHoldingObject && Input.GetKeyDown(interactKey))
        {
            CheckForInteraction();
        }
    }

    void CheckForPickUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                pickedObject = hit.collider.gameObject;
                pickedObject.SetActive(false); // Убираем объект с экрана
                isHoldingObject = true;
                Debug.Log("Picked up " + pickedObject.name);
            }
        }
    }

    void CheckForInteraction()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f))
        {
            if (hit.collider.CompareTag(targetTag))
            {
                Debug.Log("Interacted with " + hit.collider.name);
                SceneManager.LoadScene("LobbyScene") ;
            }
        }
    }
}