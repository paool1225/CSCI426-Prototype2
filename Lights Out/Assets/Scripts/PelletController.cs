using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PelletController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider){
        InputController.instance.Recharge();
        Destroy(gameObject);
    }
}
