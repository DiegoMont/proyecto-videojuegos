using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitsCarSpawner : MonoBehaviour
{
    //Aquí se indicará el color del carro que el usuario tiene acorde a lo comprado en tienda o tipo de jugador
    //FALTA IMPLEMENTAR LA ASIGNACIÓN DE VARIABLE ELEGIDA POR EL OBJETO DONT DESTROY ON LOAD

    public int cartoSpawn;
    public GameObject[] cars;

    void Start()
    {
        Instantiate(cars[cartoSpawn], gameObject.transform.position, Quaternion.identity);
    }

}
