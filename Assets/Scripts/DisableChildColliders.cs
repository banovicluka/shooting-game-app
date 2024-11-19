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
        foreach (Transform child in parentTransform) {
            Collider childCollider = child.GetComponent<Collider>();
            if (childCollider != null) {
                childCollider.enabled = false;
            }

            // Recursively call this function to go deeper into the hierarchy
            RemoveCollidersRecursively(child);
        }
    }
}


