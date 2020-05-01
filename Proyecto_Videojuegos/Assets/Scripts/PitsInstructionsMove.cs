using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitsInstructionsMove : MonoBehaviour
{
    //Variables para los métodos locales
    private Vector3 currentTarget;
    private Vector3 _ping;
    private Vector3 _pong;
    public float Speed = 4;

    void Start()
    {
        _ping = new Vector3(10.4f, 1.4f, 0f);
        _pong = new Vector3(10.4f, 1.8f, 0f);
        currentTarget = _ping;
    }

    void Update()
    {
        Move();
    }

    //Método que permite la animación de indicaciones para seleccionar herramienta
    void Move()
    {
        float distance = Vector3.Distance(gameObject.transform.position, currentTarget);
        if(distance <= 0)
        {
            if(currentTarget == _ping)
            {
                currentTarget = _pong;
            }
            else
            {
                currentTarget = _ping;
            }
        }
        else
        {
            gameObject.transform.position = Vector3.Lerp(transform.position, currentTarget, (Time.deltaTime * Speed) / distance);
        }
    }
}
