using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Position : MonoBehaviour
{
    public Vector3 position;
    public CarControllermec car;
    public bool occuppied;

    // Start is called before the first frame update
    void Start()
    {
        position = gameObject.transform.position;
        occuppied = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (car != null)
        {
            if (car.isfixed == 1)
            {
                occuppied = false;
                car = null;
            }
        }
    }
}
