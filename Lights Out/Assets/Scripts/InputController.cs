using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public Light myIllumination;
    public static InputController instance;
    private Rigidbody2D myRigid;
    private const float FADE_SPEED = 0.1f;
    private const float MOVE_SPEED = 10f;
    private Vector2 destination;
    private float illuminationLevel = 5f;
    private bool flashed = false;
    private bool counting = false;
    private int direction = 1;
    private bool dead;
    // Start is called before the first frame update
    void Start()
    {
        myRigid = gameObject.GetComponent<Rigidbody2D>();
        instance = this;
        myIllumination.intensity = illuminationLevel = direction = 1;
        counting = flashed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!dead){
            float horizontalInput = Input.GetAxis("Horizontal")*MOVE_SPEED*Time.fixedDeltaTime;
            float verticalInput = Input.GetAxis("Vertical")*MOVE_SPEED*Time.fixedDeltaTime;
            destination = myRigid.position + Vector2.up*verticalInput + Vector2.right*horizontalInput;
        }
    }
    void FixedUpdate(){
        if(illuminationLevel > 0.5f || dead){
            illuminationLevel -= FADE_SPEED*Time.fixedDeltaTime;
        }else{
            if(!counting){
                counting = true;
                flashed = false;
                StartCoroutine(Countdown());
            }
            if(!flashed){
                illuminationLevel -= direction*FADE_SPEED*2*Time.deltaTime;
                if(illuminationLevel < 0.25f){direction = -1;}
                if(illuminationLevel > 0.5f){direction = 1;}
            }
        }
        myIllumination.intensity = illuminationLevel;
        myRigid.MovePosition(destination);
    }
    public void Recharge(){
        illuminationLevel += 0.3f;
    }
    IEnumerator Countdown(){
        yield return new WaitForSeconds(3f);
        flashed = true;
        direction = 1;
        if(illuminationLevel < 0.5f){
            dead = true;
        }    
        counting = false;
    }
}
