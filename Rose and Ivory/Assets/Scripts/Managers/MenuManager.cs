using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public SystemPref systemPref;
    public string[] scene;
    int sceneNum;
    public Animator anim;

    public void StartGame()
    {
        sceneNum = 0;
        systemPref.introShouldPlay = true;
        systemPref.startGame = true;
        StartCoroutine(Cutscene());
    }
    public void Options()
    {
        sceneNum = 1;
        StartCoroutine(Cutscene());
        systemPref.introShouldPlay = false;
    }
    public void Credits()
    {
        sceneNum = 2;
        StartCoroutine(Cutscene());
        systemPref.introShouldPlay = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ReturnToMenu(){
        sceneNum = 3;
        StartCoroutine(Cutscene());
    }
    public void MiniGameTest(){
        sceneNum = 4;
        StartCoroutine(Cutscene());
    }
    IEnumerator Cutscene(){
        anim.SetBool("ChangingScene",true);
        yield return new WaitForSeconds(1f);
        anim.SetBool("ChangingScene",false);
        SceneManager.LoadScene(scene[sceneNum].ToString());

    }
}
