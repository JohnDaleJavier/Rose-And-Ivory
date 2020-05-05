using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractableObj : MonoBehaviour
{
    //Componenets
    public Image[] interactionUI;
    public RelightManager relight;
    
    //values
    public float interactFill;
    public bool interacting;
    public float pickUpDelay;
    float pickUpDelayHold;
    //0 Gas
    public int objectID;

    void Start(){
        interactionUI[0].enabled = false;
    }
    void Update(){
        if(interacting){
            print("yesr");
            interactionUI[1].fillAmount += Time.deltaTime *pickUpDelay; 
        }
        else{
            interactionUI[1].fillAmount = 0;
        }
        if(interactionUI[1].fillAmount == 1){
            PickedUp();
        }

    }
    public void Highlighted(bool Active){
        if(Active){
            interactionUI[0].enabled = true;

        }
        else{
            interactionUI[0].enabled = false;
            interactionUI[1].fillAmount = 0;

        }
    }
    void PickedUp(){
        if(objectID == 1){
            relight.TakeGas(30f);
            Destroy(this.gameObject);
        }
        if(objectID == 2){
            relight.canUseLantern = true;
            relight.LanternActive(true);
            Destroy(this.gameObject);
        }
    }

}
