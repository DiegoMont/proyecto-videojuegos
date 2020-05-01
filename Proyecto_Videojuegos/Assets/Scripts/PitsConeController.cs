using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitsConeController : MonoBehaviour
{
    //Este controlador permite acceder al método "destruír" todos los conos cuando el jugador acierta la herramienta solicitada
    public void DestroyCone()
    {
        Destroy(gameObject);
    }
}
