using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolController : MonoBehaviour
{
    public PlayerController player;
    public bool selected = false;
    public SpriteRenderer TheSpriteRender;
    private Vector3 respawnPoint;
    private Vector3 secretPosition;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoint = transform.position;
        secretPosition = new Vector3(respawnPoint.x, -7.0f, respawnPoint.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && selected == true)
        {
            ReturnTool();
        }
    }

    private void OnCollisionEnter2D (Collision2D other){
        if (other.gameObject.CompareTag("Mechanic") && player.equipped == false)
        {
            selected = true;
            player.equipped = true;
            player.equippedtool = this;
            TheSpriteRender.enabled = false;
            transform.position = secretPosition;
        }
    }

    public void ReturnTool(){
        selected = false;
        player.equipped = false;
        player.equippedtool = null;
        TheSpriteRender.enabled = true;
        transform.position = respawnPoint;
    }
}
