using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyShortcuts : MonoBehaviour
{
    private ButtonAction buttonActions;
    private InventoryUI inventoryUI;
    // Start is called before the first frame update
    private void Start()
    {
        buttonActions = FindObjectOfType<ButtonAction>(true);
        if (buttonActions == null)
        {
            Debug.LogError("Button Actions not found in the scene!");
        }

        inventoryUI = FindObjectOfType<InventoryUI>(true);
        if (inventoryUI == null)
        {
            Debug.LogError("Inventory GUI not found in the scene!");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (buttonActions.PausePanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                buttonActions.Resume();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                buttonActions.Pause();
            }
        }
    }
}
