using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RelightManager : MonoBehaviour
{
    //Components
    public SystemPref systempPref;
    public Animator anim;
    public GameObject[] lightTarg;
    public GameObject lanternLight;
    public Image Timer;
    public Image[] GasMeter;
    public AudioClip[] lightClick;    
    AudioSource audi;
    public AudioSource lanternAudi;


    //values
    public float gasAmount = 100;
    float gasAmountHold;
    public float gasUseRatio = .3f;
    public float relightDelay = .1f;
    public float timerDuration = .5f;
    float timerNum;
    float randomVar;
    int currentTarg;

    //bools
    bool randomized = false;
    bool inTarget = false;
    bool lanternOff = true;
    bool canRelight = true;
    bool relighting = false;
    public bool canUseLantern = false;
    void Start(){
        audi = GetComponent<AudioSource>();
        GasMeter[0].enabled = false;
        gasAmountHold = gasAmount;
        lanternLight.SetActive(false);
        if(!lanternOff){
            LanternActive(true);
        }
    }
    void Update()
    {
        //LightMiniGame
        if(canUseLantern){
            if(lanternOff && canRelight){
                if(timerNum >= lightTarg[currentTarg].GetComponent<TargetValue>().targetMin && timerNum <= lightTarg[currentTarg].GetComponent<TargetValue>().targetMax){
                    inTarget = true;
                }
                else if(timerNum <= lightTarg[currentTarg].GetComponent<TargetValue>().targetMin || timerNum >= lightTarg[currentTarg].GetComponent<TargetValue>().targetMax){
                    inTarget = false;
                }
                if(Input.GetButtonUp("Fire2") && lanternOff && relighting){
                    randomized = false;
                    relighting = false;
                    lightTarg[currentTarg].SetActive(false);
                    Timer.fillAmount = 0 ;
                    if(inTarget){
                        LanternActive(true);
                    }
                    else{
                        GasMeter[0].enabled = false;
                        GasMeter[1].fillAmount = 0;
                        audi.PlayOneShot(lightClick[1]);                
                    }
                }
                if(Input.GetButtonDown("Fire2") && randomized == false && gasAmount >0){
                    randomVar = Random.Range(3f,5f);      
                    print(randomVar.ToString());          
                    GasMeter[0].enabled = true;
                    GasMeter[1].fillAmount = gasAmount/100;
                    randomized = true;
                    relighting = true;
                    inTarget = false;
                    currentTarg = Random.Range(0,lightTarg.Length);
                    lightTarg[currentTarg].SetActive(true);
                }            
                if(Input.GetButton("Fire2") && relighting){
                    Timer.fillAmount += Time.deltaTime * timerDuration* randomVar;
                    timerNum = Timer.fillAmount;
                }                

                else if(Input.GetButtonDown("Fire2") && gasAmount <=0){
                    StartCoroutine(InsufficentGas());
                }

            }
            if(!lanternOff){
                gasAmount -= Time.deltaTime * gasUseRatio;
                GasMeter[1].fillAmount = gasAmount/100f;            
                if(Input.GetButtonDown("Fire2")){
                    canRelight = false;                  
                    LanternActive(false);
                }            
            }            
        }


        //Gas Management
        if(gasAmount <0){
            LanternActive(false);            
            gasAmount =0;

        }

    }
    public void LanternActive(bool Active){
        if(Active){
            if(lanternAudi.isPlaying){
                lanternAudi.Play();
            }
            GasMeter[0].enabled = true;
            anim.SetBool("lanternOn",true);
            audi.PlayOneShot(lightClick[0]);
            lanternLight.SetActive(true); 
            lanternOff = false;           
        }
        else{
            lanternAudi.Stop();
            GasMeter[0].enabled = false;
            GasMeter[1].fillAmount = 0;
            StartCoroutine(RelightTimer());            
        }

    }
    private IEnumerator RelightTimer(){
        anim.SetBool("lanternOn",false);
        audi.PlayOneShot(lightClick[0]);
        lanternLight.SetActive(false);         
        lanternOff = true;          
        yield return new WaitForSeconds(relightDelay);
        canRelight = true;
    }
    public void TakeGas(float gasIncome){
        gasAmount += gasIncome;
        if(gasAmount >= gasAmountHold){
            gasAmount = gasAmountHold;
        }
    }
    IEnumerator InsufficentGas(){
        GasMeter[0].enabled = true;
        GasMeter[0].color = new Color32(255,0,0,80);
        yield return new WaitForSeconds(1f);
        GasMeter[0].color = new Color32(255,255,255,80);
        GasMeter[0].enabled = false;
    }
}
