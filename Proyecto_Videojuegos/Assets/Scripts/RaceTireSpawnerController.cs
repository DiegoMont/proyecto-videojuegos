using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTireSpawnerController : MonoBehaviour
{
 
	public GameObject tire;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnTire() {
    	Vector3 position = gameObject.transform.position;
    	Instantiate(tire, position, Quaternion.identity);
    }
}
