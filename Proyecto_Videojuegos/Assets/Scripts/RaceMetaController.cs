using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RaceMetaController : MonoBehaviour
{
    

	public GameObject lap;
	public int totalLaps;
	public int currentLaps;
    // Start is called before the first frame update
    void Start()
    {
    	//lap.GetComponent<Text>().text = "ok";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
/*
    public void updateLaps(int currentLaps, int totalLaps) {
        lapText.text = currentLaps + "/" + totalLaps;
     }
     */
}
