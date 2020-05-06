using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceTireController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10.0f);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(new Vector3(-0.05f, -0.01f, 0));
    }
}
