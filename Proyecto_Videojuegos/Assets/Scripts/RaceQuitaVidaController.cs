using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceQuitaVidaController : MonoBehaviour
{
    public GameObject sceneManager;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.FindWithTag("RaceSceneManager");
        player1 = GameObject.FindWithTag("RacePlayer");
        player2 = GameObject.FindWithTag("RacePlayer2");
        player3 = GameObject.FindWithTag("RacePlayer3");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.CompareTag("RacePlayer"))
        {
           //float lifeToSubstract = Random.Range(1.0f, 3.0f);
          float lifeToSubstract = Random.Range(10.0f, 20.0f);
           float currentLife = RaceHealthBarScript.health;
           if (currentLife <= 0) {
            savePositions();
            sceneManager.GetComponent<RaceSceneManagerController>().LoadScreenPits();

           } else {
                RaceHealthBarScript.health -= lifeToSubstract;
           }



        
        }
    	
    	
    }

    public void savePositions() {


      PlayerPrefs.SetFloat("Player1PositionX", player1.GetComponent<Transform>().position.x);
      PlayerPrefs.SetFloat("Player1PositionY", player1.GetComponent<Transform>().position.y);
      PlayerPrefs.SetFloat("Player2PositionX", player2.GetComponent<Transform>().position.x);
      PlayerPrefs.SetFloat("Player2PositionY", player2.GetComponent<Transform>().position.y);
      PlayerPrefs.SetFloat("Player3PositionX", player3.GetComponent<Transform>().position.x);
      PlayerPrefs.SetFloat("Player3PositionY", player3.GetComponent<Transform>().position.y);
    }
}
