using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedYPosition : MonoBehaviour
{
    public float fixedY = -2.9f; // The Y coordinate you want to fix the GameObject at

    /*void Update()
    {
        Vector3 currentPosition = transform.position;

        // Check if the current Y position is different from the fixed Y position
        if (currentPosition.y != fixedY)
        {
            // If so, update the Y position while keeping X and Z the same
            transform.position = new Vector3(currentPosition.x, fixedY, currentPosition.z);
        }
    }*/
}
