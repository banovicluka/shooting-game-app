using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DisableChildColliders : MonoBehaviour
{
   
    void Start() {
        // Remove colliders from all child objects
        RemoveCollidersRecursively(transform);
    }

    void RemoveCollidersRecursively(Transform parentTransform) {
        // Loop through all child objects of the parent
        foreach (Transform child in parentTransform) {
            // Find the collider component on the child object
            Collider childCollider = child.GetComponent<Collider>();
            if (childCollider != null) {
                // Disable the collider (you can also destroy it if needed)
                childCollider.enabled = false;
            }

            // Recursively call this function to go deeper into the hierarchy
            RemoveCollidersRecursively(child);
        }
    }
}


