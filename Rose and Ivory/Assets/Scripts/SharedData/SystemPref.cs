using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ( menuName = "SystemPref")]
public class SystemPref : ScriptableObject
{
    public bool introShouldPlay;
    public bool startGame;
    public float masterVol;

    public void OnEnable()
    {
        startGame = false;
        masterVol = .8f;
        introShouldPlay = true;
    }
    public void Awake()
    {
        
    }
}
