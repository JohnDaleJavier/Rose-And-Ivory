using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelightManager : MonoBehaviour
{
    //Components
    public SystemPref systempPref;
    public GameObject[] lightTarg;
    public GameObject lanternLight;
    public Image Timer;
    public AudioClip lightClick;    
    AudioSource audi;


    //values
    public float timerDuration = .5f;
    float timerNum;
    int currentTarg;

    //bools
    bool randomized = false;
    bool inTarget = false;

    void Start(){
        audi = GetComponent<AudioSource>();
    }
    void Update()
    {
        if(timerNum >= lightTarg[currentTarg].GetComponent<TargetValue>().targetMin && timerNum <= lightTarg[currentTarg].GetComponent<TargetValue>().targetMax){
            inTarget = true;
        }
        else if(timerNum <= lightTarg[currentTarg].GetComponent<TargetValue>().targetMin || timerNum >= lightTarg[currentTarg].GetComponent<TargetValue>().targetMax){
            inTarget = false;
        }
        if(Input.GetButtonUp("Fire2")){
            randomized = false;
            lightTarg[currentTarg].SetActive(false);
            if(inTarget){
                audi.PlayOneShot(lightClick);
                lanternLight.SetActive(true);
            }
        }        
        if(Input.GetButtonDown("Fire2") && randomized == false){
            randomized = true;
            inTarget = false;
            currentTarg = Random.Range(0,lightTarg.Length);
            lightTarg[currentTarg].SetActive(true);

        }
        if(Input.GetButton("Fire2")){
            Timer.fillAmount += Time.deltaTime * timerDuration;
            timerNum = Timer.fillAmount;
        }


    }
}
