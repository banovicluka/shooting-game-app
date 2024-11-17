using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDisapearLogger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool wasKilled = false; // Tracks if the NPC was killed

    public void MarkAsKilled()
    {
        wasKilled = true; // Mark this NPC as killed
    }

    private void OnDestroy()
    {
        if (!wasKilled)
        {
            KillTracker killTracker = GameObject.FindObjectOfType<KillTracker>();
            if (killTracker != null)
            {
                killTracker.LogDissapearance(gameObject.tag);
            }
        }
    }
}
