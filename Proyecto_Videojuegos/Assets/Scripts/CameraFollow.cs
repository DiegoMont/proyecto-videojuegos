using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	public GameObject follow;
    public GameObject follow2;
    public bool followCar;
    // Start is called before the first frame update
    void Start()
    {
        followCar = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if (followCar) {
            float posX = follow.transform.position.x;
            float posY = follow.transform.position.y;
            transform.position = new Vector3(posX, posY, transform.position.z);            
        }

        if (!followCar) {
            float posX = follow2.transform.position.x;
            float posY = follow2.transform.position.y;
            transform.position = new Vector3(posX, posY, transform.position.z);
        }


    }

    public void changeFollow() {
        followCar = false;
    }
}
