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



}
