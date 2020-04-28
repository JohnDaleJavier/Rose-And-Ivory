using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuAudioManager : MonoBehaviour
{
    public SystemPref systemPref;
    AudioSource audi;
    public AudioClip MenuMusic;
    void Start()
    {
        audi = GetComponent<AudioSource>();
        audi.Play();
    }

    // Update is called once per frame
    void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    void Update(){
        if(systemPref.startGame == true){
            audi.volume -= (Time.deltaTime *.3f);
            StartCoroutine(GameStart());
        }
        else if(systemPref.startGame == false){
            audi.volume = systemPref.masterVol;
        }
    }
    IEnumerator GameStart(){
        yield return new WaitForSeconds(5f);
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if(sceneName == "GamePreface"){
            Destroy(this.gameObject);
        }        
    }
}
