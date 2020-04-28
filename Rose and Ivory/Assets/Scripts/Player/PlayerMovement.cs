using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Gathered Scripts
    SpriteRenderer sprite;
    Animator anim;
    Rigidbody2D body;
    AudioSource audi;
    public AudioClip[] footStep;

    //Movement Vars
    Vector2 direction;
    public bool canMove;

    public float playerHorizSpeed;
    float playerHorizSpeedHold;
    public float playerVertSpeed;
    float playerVertSpeedHold;

    //Sound Val
    int randNum;
    int randNumHold;


    void Start()
    {
        canMove = true;

        //Calling Componenets
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        audi = GetComponent<AudioSource>();

        //Value Holds
        playerHorizSpeedHold = playerHorizSpeed;
        playerVertSpeedHold = playerVertSpeed;
    }

    
    void Update()
    {
        // Movement
        if(canMove){
            direction.y = Input.GetAxisRaw("Vertical");
            direction.x = Input.GetAxisRaw("Horizontal");
            if(direction.x > 0){
                sprite.flipX = false;
            }
            else if (direction.x < 0)
            {
                sprite.flipX = true;
            }
        }
    }
    void FixedUpdate(){
        if (canMove)
        {
            //Improved Movement with Interpolation/Speed Smoothing
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                body.velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal")* playerHorizSpeed, 0.8f), Mathf.Lerp(0, Input.GetAxis("Vertical")* (playerVertSpeed*.8f), 0.8f));
                //FootStepSound
                if(audi.isPlaying == false){
                    randNumHold = randNum;
                    randNum = Random.Range(0,footStep.Length);
                    if(randNum != randNumHold){
                        audi.PlayOneShot(footStep[randNum]);
                    }
                    else{
                        randNum += 1;
                        if(randNum == footStep.Length){
                            randNum = 0;
                        }
                        audi.PlayOneShot(footStep[randNum]);
                    }
                    
                }
            }
            else{
                body.velocity = new Vector2(Mathf.Lerp(body.velocity.x, 0,.2f),Mathf.Lerp(body.velocity.y, 0,.2f));
            }
        }
        else{
            body.velocity = new Vector2(0f,0f);
        }
    }
}
