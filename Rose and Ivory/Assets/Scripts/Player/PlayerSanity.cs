using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

// Attach to Child Object on Player
public class PlayerSanity : MonoBehaviour
{
    //Componenets
    public CinemachineVirtualCamera vcam;
    public SharedData sharedData;
    AudioSource audi;
    public GameObject lanternLight;
    public GameObject globalLight;
    public Image Timer;
    
    //Values
    public float playerSanity;
    float playerSanityHold;

    public float nausiaFreq;
    public float nausiaAmp;

    //Audio
    public AudioClip whispers;
    void Start()
    {
        audi = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")){
            playerSanity = 0;
            lanternLight.SetActive(false);
            globalLight.SetActive(false);
        }
        if(Input.GetButton("Fire2")){
            Timer.fillAmount += Time.deltaTime * .5f;
        }
        if(Input.GetButtonUp("Fire2")){
            Timer.fillAmount = 0;
        }
        if(playerSanity <= 0){
            if(!audi.isPlaying){
                audi.Play();

            }
            float freqHold = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain;
            float ampHold = vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain;
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = Mathf.Lerp(freqHold,nausiaFreq,.1f);
            vcam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = Mathf.Lerp(freqHold,nausiaAmp,.1f);
        }
    }
}
