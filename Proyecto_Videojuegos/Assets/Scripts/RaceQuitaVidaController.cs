using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceQuitaVidaController : MonoBehaviour
{
    public GameObject sceneManager;
    // Start is called before the first frame update
    void Start()
    {
        sceneManager = GameObject.FindWithTag("RaceSceneManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
         if (other.gameObject.CompareTag("RacePlayer"))
        {
           float lifeToSubstract = Random.Range(1.0f, 3.0f);
           float currentLife = RaceHealthBarScript.health;
           if (currentLife <= 0) {
            sceneManager.GetComponent<RaceSceneManagerController>().LoadScreenPits();
           } else {
                RaceHealthBarScript.health -= lifeToSubstract;
           }



        
        }
    	
    	
    }
}
