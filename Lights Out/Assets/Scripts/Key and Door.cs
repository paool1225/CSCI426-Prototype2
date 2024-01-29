using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyScript : MonoBehaviour
{
    private int keysCollected = 0;
    public int keysRequired = 3;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Key"))
        {
            Destroy(other.gameObject); // Destroy the collected key
            keysCollected++;
            if (keysCollected >= keysRequired)
            {
                // Enable collision with the door
                GameObject.FindGameObjectWithTag("Door").GetComponent<BoxCollider2D>().enabled = true;
            }
        }
        else if (other.CompareTag("Door"))
        {
            SceneManager.LoadScene("GameWin"); // Load the GameWin scene
        }
    }
}
