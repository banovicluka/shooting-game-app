using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Destroy the bullet after 3 seconds if it doesn't hit anything
        Destroy(gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision) {
        // Check if the bullet hit an enemy or ally, and update the score accordingly.
        GameObject parentObject = collision.transform.root.gameObject;
        var whois = parentObject.tag;
        var hit = "";
        if(whois == "Enemy") { // If the bullet hits an enemy, add 1 to the score.
            Scoring(1);
            hit = "Enemy";
        } else if (whois == "Ally") { // If the bullet hits an ally, subtract 1 to the score.
            Scoring(-1);
            hit = "Ally";
        } else { // If the bullet hits anything else, log it.
            Debug.Log("Unknown object: " + whois);
            hit = "Unknown object";
        }    
        KillTracker killTracker = GameObject.FindObjectOfType<KillTracker>();
        killTracker.LogKill(hit); 
        NPCDisapearLogger logger = collision.gameObject.GetComponent<NPCDisapearLogger>();
        if (logger != null)
        {
            logger.MarkAsKilled();
        }
        // Destroy the bullet and the object it hit.   
        Destroy(parentObject);
        Destroy(gameObject);
    }

    void Scoring(int score) {
        // Update the global score and print it in the UI.
        NPCController.POINTS+=score;
        // Find the game object with an UI tag, access to its text component and update the content.
        GameObject.FindWithTag("UI").GetComponent<Text>().text = "Points: " + (NPCController.POINTS);
    }

}
