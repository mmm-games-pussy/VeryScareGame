using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ObjectInteraction : MonoBehaviour
{
    public string interactableTag = "Interactable";
    public string targetTag = "Target";
    public string lobbySceneName = "Lobby";
    public KeyCode pickUpKey = KeyCode.E;
    public KeyCode interactKey = KeyCode.E;
    public TMP_Text messageText; // TextMeshPro Text элемент для сообщений

    private GameObject pickedObject;
    private bool isHoldingObject = false;

    void Start()
    {
    }

    //void Update()
    //{
    //    if (Input.GetKeyDown(pickUpKey))
    //    {
    //        CheckForPickUp();
    //    }

    //    if (isHoldingObject && Input.GetKeyDown(interactKey))
    //    {
    //        CheckForInteraction();
    //    }
    //}

    //void CheckForPickUp()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f))
    //    {
    //        if (hit.collider.CompareTag(interactableTag))
    //        {
    //            pickedObject = hit.collider.gameObject;
    //            pickedObject.SetActive(false); // Убираем объект с экрана
    //            isHoldingObject = true;
    //            messageText.text = "Возвращайся в машину";
    //        }
    //    }
    //}

    //void CheckForInteraction()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 2f))
    //    {
    //        if (hit.collider.CompareTag(targetTag))
    //        {
    //            SceneManager.LoadScene(lobbySceneName);
    //        }
    //    }
    //}
}