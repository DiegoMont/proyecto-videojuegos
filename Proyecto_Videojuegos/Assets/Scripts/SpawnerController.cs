using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnerController : MonoBehaviour
{
    public GameObject carToSpawn;
    public Position[] positions;
    public CarControllermec carcontrol;
    private int randomindex = 0;
    public GameManagerController managerController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnCar(){
        float randomfloat = UnityEngine.Random.Range(0, positions.Length);
        randomindex = (int) Math.Round(randomfloat);
        if (positions[randomindex].occuppied == false && carToSpawn != null)
            {
                Instantiate(carToSpawn, positions[randomindex].position, Quaternion.identity);
                positions[randomindex].occuppied = true;
                managerController.totalcars ++;
            }
        else
            {
                SpawnCar();
            }
    }

    public void SetCarToPosition(){
        positions[randomindex].car = carcontrol;
        Debug.Log("Spawner envia a position");
    }
}
