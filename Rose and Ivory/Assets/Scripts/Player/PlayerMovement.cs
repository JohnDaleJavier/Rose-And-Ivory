using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Gathered Scripts
    SpriteRenderer sprite;
    Animator anim;
    Rigidbody2D body;

    //Movement Vars
    Vector2 direction;
    public bool canMove;

    public float playerHorizSpeed;
    float playerHorizSpeedHold;
    public float playerVertSpeed;
    float playerVertSpeedHold;


    void Start()
    {
        canMove = true;

        //Calling Componenets
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();

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
            else if (direction.x <= 0)
            {
                sprite.flipX = true;
            }
        }
    }
    void FixedUpdate(){
        if (canMove)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                body.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * playerHorizSpeed, Input.GetAxisRaw("Vertical") * playerVertSpeed);
            }
            else{
                body.velocity = new Vector2(0f,0f);
            }
        }
        else{
            body.velocity = new Vector2(0f,0f);
        }
    }
}
