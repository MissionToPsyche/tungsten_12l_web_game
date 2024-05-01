using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;
//using UnityEditorInternal.Profiling.Memory.Experimental;

public class InventoryUI : MonoBehaviour
{
    // Prefab for generating objects to fill visual inventory
    // Testing purposes, mainly
    public GameObject itemPrefab;
    public GameObject asuFab;
    public GameObject notesFab;
    public GameObject fieldsFab;
    public GameObject panelsFab;
    public GameObject falconFab;
    public GameObject specFab;
    public GameObject cosmicFab;
    public GameObject magnetFab;
    public GameObject xbandFab;
    public GameObject densityFab;
    public GameObject rotationFab;
    public GameObject orbitalFab;
    public GameObject psyAstFab;

    // The main inventory panel housing the 9 slots
    public Transform inventoryPanel;

    // The nine inventory slots. Avoided using an array,
    // as it got tricky trying to make it work
    public Transform inventorySlot1;
    public Transform inventorySlot2;
    public Transform inventorySlot3;
    public Transform inventorySlot4;
    public Transform inventorySlot5;
    public Transform inventorySlot6;
    public Transform inventorySlot7;
    public Transform inventorySlot8;
    public Transform inventorySlot9;
    public Transform inventorySlot10;
    public Transform inventorySlot11;
    public Transform inventorySlot12;
    public Transform inventorySlot13;
    public Transform inventorySlot14;
    public Transform inventorySlot15;

    // The backend inventory variable
    public InventorySystem inventory;

    // Toggler variable to turn inventory screen on and off
    private bool isInventoryVisible = false;

    void Start()
    {
        inventory = FindObjectOfType<InventorySystem>();
        if (!inventory)
        {
            Debug.LogError("Inventory system not found in the scene!");
        }
        UpdateInventoryUI();
    }

    // Method to change between screens, regular and inventory
    public void ToggleInventory()
    {
        isInventoryVisible = !isInventoryVisible;
        gameObject.SetActive(isInventoryVisible);
        UpdateInventoryUI();
    }

    // Method to search for if an item is already in the frontend inventory
    private bool isFound(String strName)
    {
        foreach (Transform child in inventorySlot1)
        {
            if (child.name == strName) 
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot2)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot3)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot4)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot5)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot6)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot7)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot8)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot9)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot10)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot11)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot12)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot13)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot14)
        {
            if (child.name == strName)
            {
                return true;
            }
        }
        foreach (Transform child in inventorySlot15)
        {
            if (child.name == strName)
            {
                return true;
            }
        }

        return false;
    }

    // Updating InventoryUI or frontend inventory every time it is summoned
    private void UpdateInventoryUI()
    {
        // Local function to find the next available slot
        // Currently limited to 9 slots
        // Need potential limiting of items or prevent pickup,
        // as overload will occur on 9th slot
        Transform getOpenSlot()
        {
            if (inventorySlot1.childCount == 0)
            {
                return inventorySlot1;
            }
            else if (inventorySlot2.childCount == 0) 
            {
                return inventorySlot2;
            }
            else if (inventorySlot3.childCount == 0)
            {
                return inventorySlot3;
            }
            else if (inventorySlot4.childCount == 0)
            {
                return inventorySlot4;
            }
            else if (inventorySlot5.childCount == 0)
            {
                return inventorySlot5;
            }
            else if (inventorySlot6.childCount == 0)
            {
                return inventorySlot6;
            }
            else if (inventorySlot7.childCount == 0)
            {
                return inventorySlot7;
            }
            else if (inventorySlot8.childCount == 0)
            {
                return inventorySlot8;
            }
            else if (inventorySlot9.childCount == 0)
            {
                return inventorySlot9;
            }
            else if (inventorySlot10.childCount == 0)
            {
                return inventorySlot10;
            }
            else if (inventorySlot11.childCount == 0)
            {
                return inventorySlot11;
            }
            else if (inventorySlot12.childCount == 0)
            {
                return inventorySlot12;
            }
            else if (inventorySlot13.childCount == 0)
            {
                return inventorySlot13;
            }
            else if (inventorySlot14.childCount == 0)
            {
                return inventorySlot14;
            }
            /*else if (inventorySlot15.childCount == 0)
            {
                return inventorySlot15;
            }*/
            else
            {
                return inventorySlot15;
            }
            
        }

        // Create a new UI element for each item
        try
        {
            for (int i = 0; i < inventory.items.Count; i++)
            {
                //Debug.Log("Check " + i + "a");
                if (!isFound(inventory.items[i].name))
                {
                    var item = inventory.items[i];

                    if (item.name == "Notes")
                    {
                        GameObject newItem = Instantiate(notesFab, getOpenSlot());
                        newItem.name = item.name;
                    }
                    else if (item.name == "Arizona State University")
                    {
                        GameObject newItem = Instantiate(asuFab, getOpenSlot());
                        newItem.name = item.name;
                    }
                    else if (item.name == "Electromagnetic Fields")
                    {
                        GameObject newItem = Instantiate(fieldsFab, getOpenSlot());
                        newItem.name = item.name;
                    }
                    else if (item.name == "Solar Panels")
                    {
                        GameObject newItem = Instantiate(panelsFab, getOpenSlot());
                        newItem.name = item.name;
                    }
                    else if (item.name == "Falcon Heavy Rocket")
                    {
                        GameObject newItem = Instantiate(falconFab, getOpenSlot());
                        newItem.name = item.name;
                    }
                    else if (item.name == "Magnetometer")
                    {
                        GameObject newItem = Instantiate(magnetFab, getOpenSlot());
                        newItem.name = item.name;
                    }
                    else if (item.name == "Cosmic Rays")
                    {
                        GameObject newItem = Instantiate(cosmicFab, getOpenSlot());
                        newItem.name = item.name;
                    }
                    else if (item.name == "X-Band Radio Frequency")
                    {
                        GameObject newItem = Instantiate(xbandFab, getOpenSlot());
                        newItem.name = item.name;
                    }
                    else if (item.name == "Neutron Spectrometer")
                    {
                        GameObject newItem = Instantiate(specFab, getOpenSlot());
                        newItem.name = item.name;
                    }
                    else if (item.name == "Density")
                    {
                        GameObject newItem = Instantiate(densityFab, getOpenSlot());
                        newItem.name = item.name;
                    }
                    else if (item.name == "Orbital Period")
                    {
                        GameObject newItem = Instantiate(orbitalFab, getOpenSlot());
                        newItem.name = item.name;
                    }
                    else if (item.name == "Rotation Period")
                    {
                        GameObject newItem = Instantiate(rotationFab, getOpenSlot());
                        newItem.name = item.name;
                    }
                    else if (item.name == "Psyche Asteroid")
                    {
                        GameObject newItem = Instantiate(psyAstFab, getOpenSlot());
                        newItem.name = item.name;
                    }
                    else
                    {
                        GameObject newItem = Instantiate(itemPrefab, getOpenSlot());
                        newItem.name = item.name;
                    }
                    //GameObject newItem = Instantiate(itemPrefab, getOpenSlot());
                    //GameObject newItem = Instantiate(inventory.items[i], getOpenSlot());
                    //Image itemSprite = newItem.GetComponent<Image>();
                }
            }
        }
        // Currently unsure why this exception is being thrown, but didn't affect gameplay
        // from what could be determined. Catching it so that it is separated from other errors
        catch (NullReferenceException)
        {
            Debug.Log("Null reference thrown");
        }
    }

}
