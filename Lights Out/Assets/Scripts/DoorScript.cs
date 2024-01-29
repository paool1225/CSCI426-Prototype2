using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    void Start()
    {
        // Disable collision with the door initially
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
