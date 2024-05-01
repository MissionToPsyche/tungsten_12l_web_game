using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// MoveToMouse allows the object to move towards the mouse position when clicked
public class MoveToMouse : MonoBehaviour
{
    // Movement speed of the object
    public float speed = 5f;

    // Target position for movement
    private Vector3 target;

    // Flag indicating whether the object is currently moving
    private bool isMoving = false;

    // The fixed Y-coordinate when touching the floor
    private float fixedY = -2.33f;

    private Animator playerAnim;

    void Awake()
    {
        playerAnim = GetComponent<Animator>();
    }
        
    // Called when the script is first run
    void Start()
    {
        // Set the initial target to the current position
        target = transform.position;

        // Set the initial Y-coordinate of the object to the fixed floor Y-coordinate
        transform.position = new Vector3(transform.position.x, fixedY, transform.position.z);
    }

    // Called once per frame
    void Update()
    {
        // Check if the mouse is over a UI element
        if (EventSystem.current.IsPointerOverGameObject())
        {
            // If the mouse is over a UI element, return and don't process further
            return;
        }

        // Check if the left mouse button is pressed
        if (Input.GetMouseButtonDown(0))
        {
            // Set the target position to the mouse position in the world space
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Set the Y-coordinate to the fixed floor Y-coordinate
            target.y = fixedY;

            // Keep the original Z-coordinate
            target.z = transform.position.z;

            // Set the direction of the player
            if (transform.position.x > target.x)
            {
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
            }
            else
            {
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                }
            }

            // Set the isMoving flag to true
            isMoving = true;
            playerAnim.SetBool("play_Walk", true);
        }

        // Check if the object is currently moving
        if (isMoving)
        {
            
            // Move the object towards the target position
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            // Check if the object has reached the target with a small tolerance
            if (Vector3.Distance(transform.position, target) < 0.01f)
            {
                playerAnim.SetBool("play_Walk", false);
                // Snap directly to the target position
                transform.position = target;

                // Set the isMoving flag to false
                //playerAnim.SetBool("play_Walk", false);
                isMoving = false;
            }
        }
    }

    // Called when a 2D collision occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        // Log the name of the collided object
        Debug.Log("Collided with: " + collision.gameObject.name);

        // Check if the collided object has the "Floor" tag
        if (collision.gameObject.CompareTag("Floor"))
        {
            // Set the current position as the target
            target = transform.position;

            // Set the isMoving flag to false
            isMoving = false;
        }
    }
}
