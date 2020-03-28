using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool equipped = false;
    public ToolController equippedtool = null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move(){
            float x = Input.GetAxis("Horizontal") * 0.1f;
            gameObject.transform.Translate(new Vector3(
            Mathf.Clamp(x, -1f, 1f), 
            0, 
            0));

            float y = Input.GetAxis("Vertical") * 0.1f;
            gameObject.transform.Translate(new Vector3(
            0,
            Mathf.Clamp(y, -1f, 1f),
            0));
    }
    public void GameOver(){
        enabled = false;
    }
}
