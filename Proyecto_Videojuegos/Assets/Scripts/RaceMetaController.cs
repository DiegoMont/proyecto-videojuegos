﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RaceMetaController : MonoBehaviour
{
    

	public Text lapText;
    public Text placeText;
	public int totalLaps;
	public int currentLaps;
    public int currentLapsP2;
    public int currentLapsP3;
    public bool firstP1 = false;
    public bool firstP2 = false;
    public bool firstP3 = false;
    private RaceGameManager gameManager;
    public GameObject sceneManager;


    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.FindWithTag("RaceSceneManager");
        gameManager = GameObject.FindObjectOfType<RaceGameManager>();
    	totalLaps = 5;
        currentLaps = 0;
        updateLaps(currentLaps, totalLaps);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

  void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("RacePlayer")){

            if (!firstP1) {
                firstP1 = true;
                return;
            }
            if (firstP1) {
                currentLaps++;
                updateLaps(currentLaps, totalLaps);
            }
            if (currentLaps>= totalLaps) {
                winRace();
            }
            if (currentLaps != 0)
            {
                gameManager.PlaySound("Lap");
            }
        }


        if(other.gameObject.CompareTag("RacePlayer2")){
            if (!firstP2) {
                firstP2 = true;
                return;
            }
            if (firstP2) {
                currentLapsP2++;
            }
            if (currentLapsP2 >= totalLaps) {
                lostRace();
            }
        }

        if(other.gameObject.CompareTag("RacePlayer3")){
            if (!firstP3) {
                firstP3 = true;
                return;
            }
            if (firstP3) {
                currentLapsP3++;
            }
            if (currentLapsP3 >= totalLaps) {
                lostRace();
            }
        }

    }




    public void updateLaps(int currentLaps, int totalLaps) {
        lapText.text = currentLaps + "/" + totalLaps;
     }

     public void updatePlaces(string place) {
        placeText.text = place;
     }

    public void winRace() {
        //Debug.Log("You won the race");
        //Poner escena de carrera ganada
        sceneManager.GetComponent<RaceSceneManagerController>().LoadWinnerScene();
    }

    public void lostRace() {
        //Poner escena de carrera perdida
        sceneManager.GetComponent<RaceSceneManagerController>().LoadGameOverScene();
    }
     
}
