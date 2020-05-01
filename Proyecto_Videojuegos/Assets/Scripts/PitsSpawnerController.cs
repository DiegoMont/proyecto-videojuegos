using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitsSpawnerController : MonoBehaviour
{
    //Controlador con método de Spawnear conos, se llama desde GameManager
    
    public GameObject objectToSpawn;

    public void Spawn()
    {
        float x = Random.Range(-5.6f, 8.5f);
        float y = Random.Range(-4.5f, -0.3f);

        Vector3 newposition = new Vector3(x, y, 0);
        gameObject.transform.position = newposition;

        Instantiate(objectToSpawn, gameObject.transform.position, Quaternion.identity);
    }
}
