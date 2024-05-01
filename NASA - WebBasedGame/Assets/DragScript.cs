using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;
//using UnityEditor.Overlays;

// DragScript handles dragging inventory items 
public class DragScript : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
{
    // Public variables for UI elements
    // Image displays item sprite
    public Image anImage;

    // UI prefabs for displaying item name and description 
    public GameObject textItemPrefab;
    public GameObject descItemPrefab;

    // Helper variables
    // Canvas is root of UI
    [HideInInspector] public Transform overallCanvas;

    // Last parent transform before drag started
    [HideInInspector] public Transform lastParent;

    // Name and description text objects
    [HideInInspector] public GameObject newTitle;
    [HideInInspector] public GameObject newDescription;

    // Reference to inventory system
    private InventorySystem aSystem;

    void Start()
    {
        // Get reference to inventory system during the start of the script
        aSystem = FindObjectOfType<InventorySystem>();
        if (aSystem == null)
        {
            Debug.LogError("Inventory system not found in scene!");
        }
    }

    // When drag starts, set up drag visuals
    public void OnBeginDrag(PointerEventData eventData)
    {
        // Store last parent for reparenting later
        lastParent = transform.parent;

        // Make image appear above other UI elements
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();

        // Ignore raycasts so image doesn't block drops
        anImage.raycastTarget = false;
    }

    // Update position during drag
    public void OnDrag(PointerEventData eventData)
    {
        // Update the position of the dragged item based on the mouse position
        transform.position = Input.mousePosition;
    }

    // When drag ends, clean up
    public void OnEndDrag(PointerEventData eventData)
    {
        // Reparent back to original parent
        transform.SetParent(lastParent);

        // Re-enable raycasts
        anImage.raycastTarget = true;
    }

    // When pointer enters, show name and description 
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Instantiate UI elements for displaying item name and description
        overallCanvas = transform.parent.transform.parent.transform.parent;
        newTitle = Instantiate(textItemPrefab, overallCanvas);
        newDescription = Instantiate(descItemPrefab, overallCanvas);

        // Position and populate text 
        newTitle.transform.position.Set(730, 330, 0);
        TextMeshProUGUI titleText = newTitle.GetComponent<TextMeshProUGUI>();
        titleText.text = transform.name;
        newTitle.SetActive(true);

        TextMeshProUGUI descText = newDescription.GetComponent<TextMeshProUGUI>();
        descText.text = aSystem.descriptions[transform.name];
        newDescription.SetActive(true);
    }

    // When pointer exits, destroy name and description
    public void OnPointerExit(PointerEventData eventData)
    {
        // Hide and destroy the displayed name and description UI elements
        newTitle.SetActive(false);
        newDescription.SetActive(false);
        Destroy(newTitle.gameObject);
        Destroy(newDescription.gameObject);
    }
}
