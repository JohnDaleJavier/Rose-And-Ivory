using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManager : MonoBehaviour
{
    public SystemPref systemPref;
    void Start()
    {
        if(systemPref.introShouldPlay == false){
            Destroy(this.gameObject);
        }
    }

}
