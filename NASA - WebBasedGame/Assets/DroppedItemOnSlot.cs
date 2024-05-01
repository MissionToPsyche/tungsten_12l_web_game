using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEngine.Rendering.VirtualTexturing;

// DroppedItemOnSlot handles the dropping of items onto inventory slots
public class DroppedItemOnSlot : MonoBehaviour, IDropHandler
{
    // Reference to the inventory system
    private InventorySystem aSystem;

    // The current prefab or template to generate new items. Mainly used for testing purposes,
    // needs to be replaced with a system that allows for different kinds of items
    public GameObject itemPrefab;

    public GameObject satFab;
    public GameObject solarElecFab;
    public GameObject gamFab;
    public GameObject missionFab;

    void Start()
    {
        // Get reference to the inventory system during the start of the script
        aSystem = FindObjectOfType<InventorySystem>();
        if (aSystem == null)
        {
            Debug.LogError("Inventory system not found in the scene!");
        }
    }

    void Update()
    {
        // Update reference to the inventory system during every frame
        aSystem = FindObjectOfType<InventorySystem>();
        if (aSystem == null)
        {
            Debug.LogError("Inventory system not found in the scene!");
        }
    }

    // Check whether two items are combinable or not
    // If they are, mark them for the combination process
    // If not, return the dragged item to its original slot
    public bool IsCombinable(GameObject firstItemToCheck, GameObject secondItemToCheck)
    {
        // Checking whether the items' names are in the dictionaries of either item, no matter the order
        if (aSystem.combinableItems[firstItemToCheck.name] == secondItemToCheck.name)
        {
            return true;
        }
        else if (aSystem.combinableItems[secondItemToCheck.name] == firstItemToCheck.name)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    // Event handler for when an item gets dropped
    public void OnDrop(PointerEventData eventData)
    {
        GameObject draggedItem = eventData.pointerDrag;
        DragScript droppedItem = draggedItem.GetComponent<DragScript>();

        // If the inventory slot is empty, allow the drop 
        if (transform.childCount == 0)
        {
            droppedItem.lastParent = transform;
        }

        // If the inventory slot isn't empty but the item found in the slot is combinable
        // with the currently being held item in the mouse pointer, then the combination
        // process will take effect
        else if (IsCombinable(transform.GetChild(0).gameObject, draggedItem.gameObject) && GameObject.Find("TitleText(Clone)") != null)
        {
            // The item in the slot
            DragScript originalItem = transform.GetChild(0).GetComponent<DragScript>();

            string originalName = originalItem.name;
            string droppedName = droppedItem.name;

            if (originalName == "Density" || originalName == "Rotation Period" || originalName == "Orbital Period")
            {
                if (aSystem.findItemC("Density") && aSystem.findItemC("Rotation Period") && aSystem.findItemC("Orbital Period"))
                {
                    // The item being held by the cursor is marked to drop in the slot
                    droppedItem.lastParent = transform;

                    // Removing each of the parents (two combinable items) from the backend inventory list
                    foreach (GameObject item in aSystem.items)
                    {
                        if (item.name == "Density")
                        {
                            aSystem.items.Remove(item);
                            break;
                        }
                    }
                    foreach (GameObject item in aSystem.items)
                    {
                        if (item.name == "Rotation Period")
                        {
                            aSystem.items.Remove(item);
                            break;
                        }
                    }
                    foreach (GameObject item in aSystem.items)
                    {
                        if (item.name == "Orbital Period")
                        {
                            aSystem.items.Remove(item);
                            break;
                        }
                    }

                    // Removing the combined items' displayed name and description
                    originalItem.newTitle.SetActive(false);
                    originalItem.newDescription.SetActive(false);
                    Destroy(originalItem.newTitle.gameObject);
                    Destroy(originalItem.newDescription.gameObject);
                    Destroy(droppedItem.newTitle.gameObject);
                    Destroy(droppedItem.newDescription.gameObject);

                    // Deleting all of the old inventory items
                    Destroy(GameObject.Find("Rotation Period").gameObject);
                    Destroy(GameObject.Find("Orbital Period").gameObject);
                    Destroy(GameObject.Find("Density").gameObject);

                    
                    GameObject newItem = Instantiate(missionFab, transform);
                    newItem.name = "The Mission to Psyche";
                    newItem.transform.name = "The Mission to Psyche";

                    // Adding the new item to the list of inventory in the backend list
                    aSystem.AddItem(newItem);
                    
                }
            }
            else
            {
                // The item being held by the cursor is marked to drop in the slot
                droppedItem.lastParent = transform;

                // Removing each of the parents (two combinable items) from the backend inventory list
                foreach (GameObject item in aSystem.items)
                {
                    if (item.name == originalItem.name)
                    {
                        aSystem.items.Remove(item);
                        break;
                    }
                }
                foreach (GameObject item in aSystem.items)
                {
                    if (item.name == draggedItem.name)
                    {
                        aSystem.items.Remove(item);
                        break;
                    }
                }

                // Removing the combined items' displayed name and description
                originalItem.newTitle.SetActive(false);
                originalItem.newDescription.SetActive(false);
                Destroy(originalItem.newTitle.gameObject);
                Destroy(originalItem.newDescription.gameObject);
                Destroy(droppedItem.newTitle.gameObject);
                Destroy(droppedItem.newDescription.gameObject);

                // Deleting both of the old inventory items
                Destroy(draggedItem.gameObject);
                Destroy(transform.GetChild(0).gameObject);

                // Creating a new combined item.
                // NOTE: This is just for testing; needs to be altered to accommodate rest of the game
                //       i.e. Needs change in the creation of the object to allow different objects to be created
                //            using dictionaries of combinable objects, correct names, etc.

                if ((originalName == "Solar Panels" && droppedName == "Electromagnetic Fields") ||
                    (originalName == "Electromagnetic Fields" && droppedName == "Solar Panels"))
                {
                    GameObject newItem = Instantiate(solarElecFab, transform);
                    newItem.name = "Solar Electric Propulsion";
                    newItem.transform.name = "Solar Electric Propulsion";

                    // Adding the new item to the list of inventory in the backend list
                    aSystem.AddItem(newItem);
                }
                else if ((originalName == "Neutron Spectrometer" && droppedName == "Cosmic Rays") ||
                    (originalName == "Cosmic Rays" && droppedName == "Neutron Spectrometer"))
                {
                    GameObject newItem = Instantiate(gamFab, transform);
                    newItem.name = "Gamma Ray Spectrometer";
                    newItem.transform.name = "Gamma Ray Spectrometer";

                    // Adding the new item to the list of inventory in the backend list
                    aSystem.AddItem(newItem);
                }
                else
                {
                    GameObject newItem = Instantiate(itemPrefab, transform);
                    newItem.name = "TestItem4";
                    newItem.transform.name = "TestItem4";

                    // Adding the new item to the list of inventory in the backend list
                    aSystem.AddItem(newItem);
                }

            }
        }
    }
}