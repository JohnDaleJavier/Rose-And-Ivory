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
    public Animator anim;
    AudioSource audi;
    public GameObject lanternLight;
    public Image Timer;
    
    //Values
    public float playerSanity;
    float playerSanityHold;

    public float nausiaFreq;
    public float nausiaAmp;
    void Start()
    {
        audi = GetComponent<AudioSource>();
        playerSanity = 0;
    }

    // Update is called once per frame
    void Update()
    {
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
