using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitsCarSpawner : MonoBehaviour
{
    //Aquí se indicará el color del carro que el usuario tiene acorde a lo comprado en tienda o tipo de jugador
    //FALTA IMPLEMENTAR LA ASIGNACIÓN DE VARIABLE ELEGIDA POR EL OBJETO DONT DESTROY ON LOAD

    private int cartoSpawn;
    public GameObject[] cars;

    void Start()
    {
        for(int i=0; i<=2; i++)
        {
            int p = PlayerPrefs.GetInt(MenuController.currentPlayer + "StoreObjectActive" + i, 0);
            if(p == 1)
            {
                cartoSpawn = i;
            }
        }



        Instantiate(cars[cartoSpawn], gameObject.transform.position, Quaternion.identity);
    }

}
