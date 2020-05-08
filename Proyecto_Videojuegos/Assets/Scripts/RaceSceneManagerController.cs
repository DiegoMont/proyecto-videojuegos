using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RaceSceneManagerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



   public void LoadScreenRace() {
        SceneManager.LoadScene(1);
    }

     public void LoadScreenMenu() {
        SceneManager.LoadScene(0);
    }

    public void LoadScreenPits() {
        SceneManager.LoadScene(2);
    }

    public void LoadWinnerScene() {
        SceneManager.LoadScene(4);
    }
    public void LoadGameOverScene() {
        SceneManager.LoadScene(5);
    }

}
