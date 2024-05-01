using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ItemPickup handles the pickup of items by the player
public class ItemPickup : MonoBehaviour
{
    // Called when another collider enters the trigger area of the current object
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object has the "Player" tag
        if (collision.gameObject.CompareTag("Player"))
        {
            // Call the PickupItem function, passing the player object as an argument
            PickupItem(collision.gameObject);
        }
    }

    // Handles the pickup logic when the player interacts with the item
    private void PickupItem(GameObject player)
    {
        // Find the InventorySystem in the scene
        InventorySystem inventory = FindObjectOfType<InventorySystem>();

        // Check if an InventorySystem is found
        if (inventory != null)
        {
            // Add the current item (gameObject) to the player's inventory
            inventory.AddItem(gameObject);
        }
        // Deactivate the current item, assuming it has been picked up
        gameObject.SetActive(false);
    }

}
