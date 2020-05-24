using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTireSpawnerController : MonoBehaviour
{
 
	public GameObject tire;
    public GameObject tire2;
    public static int inmunidad;

    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnTire() {
        Debug.Log(inmunidad);
        if (inmunidad != 1) {
            Vector3 position = gameObject.transform.position;
            Instantiate(tire, position, Quaternion.identity);
        } if (inmunidad == 1) {
            Vector3 position = gameObject.transform.position;
            Instantiate(tire2, position, Quaternion.identity);
        }
    	
    }
}
