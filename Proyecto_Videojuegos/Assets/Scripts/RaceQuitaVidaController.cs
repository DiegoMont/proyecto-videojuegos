using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceQuitaVidaController : MonoBehaviour
{
    public GameObject sceneManager;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public int pointsP1;
    public int pointsP2;
    public int pointsP3;
    public GameObject meta;
    public float min, max;


    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.FindWithTag("RaceSceneManager");
        player1 = GameObject.FindWithTag("RacePlayer");
        player2 = GameObject.FindWithTag("RacePlayer2");
        player3 = GameObject.FindWithTag("RacePlayer3");
        meta = GameObject.FindWithTag("RaceMeta");

        player1.GetComponent<CarController>().setPoints(PlayerPrefs.GetInt("pointsP1"));
        player2.GetComponent<AutonomousCar>().setPoints(PlayerPrefs.GetInt("pointsP2"));
        player3.GetComponent<AutonomousCar>().setPoints(PlayerPrefs.GetInt("pointsP3"));

    }

    // Update is called once per frame
    void Update()
    {
        //checkPlaces();
    }

    void OnTriggerEnter2D(Collider2D other) {

       int loadedcar = 0;

        for(int i=0; i<=2; i++)
        {
            int state = PlayerPrefs.GetInt(MenuController.currentPlayer + "StoreObjectActive" + i, 0);
            if(state == 1)
            {
                loadedcar = i;
            }
        }


        switch (loadedcar)
        {
            case 0:
                min = 3.0f;
                max = 5.0f;
                break;
            case 1:
                min = 2.0f;
                max = 4.0f;
                break;
            case 2:
                min = 1.0f;
                max = 3.0f;
                break;

        }
         if (other.gameObject.CompareTag("RacePlayer"))
        {
          pointsP1 = player1.GetComponent<CarController>().getPoints();
          pointsP1++;
          //Debug.Log(pointsP1);
          player1.GetComponent<CarController>().setPoints(pointsP1);
          checkPlaces();
          float lifeToSubstract = Random.Range(min, max);
          //float lifeToSubstract = Random.Range(10.0f, 20.0f);
           float currentLife = RaceHealthBarScript.health;
           if (currentLife <= 0) {
            savePositions();
            sceneManager.GetComponent<RaceSceneManagerController>().LoadScreenPits();

           } else {
                RaceHealthBarScript.health -= lifeToSubstract;
           }



        
        }
        if (other.gameObject.CompareTag("RacePlayer2")) {
          pointsP2 = player2.GetComponent<AutonomousCar>().getPoints();
          pointsP2++;
          player2.GetComponent<AutonomousCar>().setPoints(pointsP2);
          checkPlaces();
        }
        if (other.gameObject.CompareTag("RacePlayer3")) {
          pointsP3 = player3.GetComponent<AutonomousCar>().getPoints();
          pointsP3++;
          player3.GetComponent<AutonomousCar>().setPoints(pointsP3);
          checkPlaces();
        }
    	
    	
    }

    public void savePositions() {


      PlayerPrefs.SetFloat("Player1PositionX", player1.GetComponent<Transform>().position.x);
      PlayerPrefs.SetFloat("Player1PositionY", player1.GetComponent<Transform>().position.y);
      PlayerPrefs.SetInt("Player1Points", player1.GetComponent<CarController>().getPoints());

      PlayerPrefs.SetFloat("Player2PositionX", player2.GetComponent<Transform>().position.x);
      PlayerPrefs.SetFloat("Player2PositionY", player2.GetComponent<Transform>().position.y);
      PlayerPrefs.SetInt("Player2Index", player2.GetComponent<AutonomousCar>().getTargetIndex());
      PlayerPrefs.SetInt("Player2Points", player2.GetComponent<AutonomousCar>().getPoints());


      PlayerPrefs.SetFloat("Player3PositionX", player3.GetComponent<Transform>().position.x);
      PlayerPrefs.SetFloat("Player3PositionY", player3.GetComponent<Transform>().position.y);
      PlayerPrefs.SetInt("Player3Index", player3.GetComponent<AutonomousCar>().getTargetIndex());
        PlayerPrefs.SetInt("Player3Points", player3.GetComponent<AutonomousCar>().getPoints());


      PlayerPrefs.SetInt("numberLaps", meta.GetComponent<RaceMetaController>().currentLaps);
      PlayerPrefs.SetInt("numberLapsP2", meta.GetComponent<RaceMetaController>().currentLapsP2);
      PlayerPrefs.SetInt("numberLapsP3", meta.GetComponent<RaceMetaController>().currentLapsP3);

      PlayerPrefs.SetInt("firstP1", 1);
      PlayerPrefs.SetInt("firstP2", 1);
      PlayerPrefs.SetInt("firstP3", 1);

      PlayerPrefs.SetInt("pointsP1", player1.GetComponent<CarController>().getPoints());
      PlayerPrefs.SetInt("pointsP2", player2.GetComponent<AutonomousCar>().getPoints());
      PlayerPrefs.SetInt("pointsP3", player3.GetComponent<AutonomousCar>().getPoints());





    }


  public void checkPlaces() {
    if (pointsP1 > pointsP2 && pointsP1 > pointsP3) {
      meta.GetComponent<RaceMetaController>().updatePlaces("1st");
    } else if ((pointsP1>pointsP2 && pointsP1 < pointsP3) || (pointsP1>pointsP3 && pointsP1<pointsP2)){
      meta.GetComponent<RaceMetaController>().updatePlaces("2nd");
    }
    else if (pointsP1 < pointsP2 && pointsP1 < pointsP3) {
      meta.GetComponent<RaceMetaController>().updatePlaces("3rd");
    }
  }

}
