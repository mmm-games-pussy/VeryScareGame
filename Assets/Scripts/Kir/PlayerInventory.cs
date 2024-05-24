using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private List<GameObject> _playerInventory;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            foreach (GameObject obj in _playerInventory)
            {
                obj.SetActive(false);
            }

            _playerInventory[0].SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            foreach (GameObject obj in _playerInventory)
            {
                obj.SetActive(false);
            }

            _playerInventory[1].SetActive(true);
        }

    }
}