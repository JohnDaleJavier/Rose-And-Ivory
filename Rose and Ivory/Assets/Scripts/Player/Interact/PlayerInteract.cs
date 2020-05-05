using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
{
    //Components
    RelightManager relight;

    public float pickUpTime;
    float pickUpTimeHold;

    void Start()
    {
        relight = GetComponent<RelightManager>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Interactable"){
            other.gameObject.GetComponent<InteractableObj>().Highlighted(true);
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if(other.gameObject.tag == "Interactable"){
            if(Input.GetButton("Fire4")){
                print("fuk");
                other.gameObject.GetComponent<InteractableObj>().interacting = true;
            }
            else{
                other.gameObject.GetComponent<InteractableObj>().interacting = false;
            }
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if(other.gameObject.tag == "Interactable"){
            other.gameObject.GetComponent<InteractableObj>().interactFill = 0;
            other.gameObject.GetComponent<InteractableObj>().Highlighted(false);

        }
    }
}
