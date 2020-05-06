using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTireTriggerController : MonoBehaviour
{
    

	public GameObject[] spawners;
    // Start is called before the first frame update
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("RaceTireSpawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("RacePlayer")){
        	foreach (GameObject spawner in spawners) {
        		spawner.GetComponent<RaceTireSpawnerController>().spawnTire();
        	}
        }
    }
}
