using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitsSpawnerController : MonoBehaviour
{
    //Controlador con método de Spawnear conos, se llama desde GameManager
    
    public GameObject objectToSpawn;
    public GameObject tireObject;
    public GameObject coinObject;

    public void Spawn()
    {
        float x = Random.Range(-5.6f, 8.5f);
        float y = Random.Range(-4.5f, -0.3f);

        Vector3 newposition = new Vector3(x, y, 0);
        gameObject.transform.position = newposition;

        Instantiate(objectToSpawn, gameObject.transform.position, Quaternion.identity);
    }

    public void spawnTire() {
        System.Random random = new System.Random();
        float[] posiblesY = { 0, -1, -2, -3, -4};
        float y = posiblesY[random.Next(posiblesY.Length)];
        Instantiate(tireObject, new Vector3(-14f, y, 0f), Quaternion.identity);
    }

    public void spawnCoin() {
        float x = Random.Range(-5.7f, 8.5f);
        float y = Random.Range(-4.5f, -0.3f);

        Instantiate(coinObject, new Vector3(x, y, 0f), Quaternion.identity);
    }
}
