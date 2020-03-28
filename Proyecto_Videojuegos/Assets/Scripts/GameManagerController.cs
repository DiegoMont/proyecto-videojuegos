using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;



public class GameManagerController : MonoBehaviour
{
    public ItemController item;
    public ToolController [] tools;
    public PlayerController player;
    private bool itemexists = false;
    public CarControllermec car = null;
    public SpawnerController spawner;
    public GameObject[] cars;
    public int carDifficulty;
    public float spawnDifficulty;
    public int totalcars;
    public int score;
    public Text textscore;

    // Start is called before the first frame update
    void Start()
    {
        item.TheSpriteRender.enabled = false;
        InvokeRepeating("SpawnCar", 0, spawnDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        if (totalcars==8)
        {
            GameOver();
        }
        
        ShowItem();
        ValidateCar();    
    }

    private void GameOver(){
        CancelInvoke();
        player.GameOver();
    }

    private void SpawnCar(){
        AssignCar();
        spawner.SpawnCar();
    }
    private void AssignCar(){
        float randomcar = UnityEngine.Random.Range(0, carDifficulty);
        int index = (int)Math.Round(randomcar);
        spawner.carToSpawn = cars[index];
    }
    private void ValidateCar(){
        if (car != null)
        {
            if (car.isfixed==1)
            {
                car.DestroyCar();
                totalcars --;
                score ++;
                textscore.text = "SCORE x " + score;
            }
        }
    }

    private void ShowItem(){
        if (!itemexists){  
        for (int i = 0; i < tools.Length; i++)
        {
            if (tools[i].selected == true)
            {
                item.TheSpriteRender.sprite = tools[i].TheSpriteRender.sprite;
                item.TheSpriteRender.color = tools[i].TheSpriteRender.color;
                item.TheSpriteRender.enabled = true;
                itemexists = true;
            }
        }
        }

        if (itemexists){  
            int counter = 0;
            for (int i = 0; i < tools.Length; i++)
            {
                if (tools[i].selected == false)
                {
                    counter++;
                }
            }
            if (counter == 4)
            {
                item.TheSpriteRender.enabled = false;
                itemexists=false;  
            }
        }
    }
}
