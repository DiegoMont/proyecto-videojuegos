using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitsCameraFollow : MonoBehaviour
{
    
	public Transform targetToFollow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        /*
        float posX = follow.transform.position.x;
        float posY = follow.transform.position.y;

        transform.position = new Vector3(posX, posY, transform.position.z);
        */

        transform.position = new Vector3(Mathf.Clamp(targetToFollow.position.x, -0.629f, 0.614f), Mathf.Clamp(targetToFollow.position.y, -0.053f, -0.052f), transform.position.z);
    }
}
