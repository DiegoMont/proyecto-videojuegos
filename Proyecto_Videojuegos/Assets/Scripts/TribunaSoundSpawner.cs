using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribunaSoundSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    
	public GameObject sound;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("RacePlayer")){
            Instantiate(sound, gameObject.transform.position, gameObject.transform.rotation);        }
    }
}
