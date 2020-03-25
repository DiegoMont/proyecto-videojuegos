using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public SpriteRenderer TheSpriteRender;
    private PlayerController player;
    private GameManagerController managerController;
    private SpawnerController spawner;
    public int isfixed = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = Object.FindObjectOfType<PlayerController>();
        managerController = Object.FindObjectOfType<GameManagerController>();
        spawner = Object.FindObjectOfType<SpawnerController>();

        spawner.carcontrol = this;
        spawner.SetCarToPosition();
        Debug.Log("Envia a spawner");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D (Collision2D other) {
        if(player.equippedtool != null){
            managerController.car = this;
        if (other.gameObject.CompareTag("Mechanic") && player.equippedtool.TheSpriteRender.color == TheSpriteRender.color){
            isfixed = 1;
            player.equippedtool.ReturnTool();
        }
        else{
            isfixed = 2;
            player.equippedtool.ReturnTool();
            
        }
        }
    }

    public void DestroyCar(){
        Destroy(gameObject);
    }
}
