using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class RaceGameManager : MonoBehaviour
{
    private CarController player;
    //private AutonomousCar ai;
    private AutonomousCar[] ais;

    private float TimerControl;
    private bool StartanimationPlayed;
    private bool StartsoundPlayed;

    public TextMeshProUGUI texttimer;
    private string TimerString;


    public AudioClip Hunk, Crash, Oil, Lap;
    public AudioSource effectplayer;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;

    //public GameOject 

    void Start()
    {
        //Asignar a cada jugador su posición, y para los autonomos, su index.
        player1 = GameObject.FindWithTag("RacePlayer");
        player2 = GameObject.FindWithTag("RacePlayer2");
        player3 = GameObject.FindWithTag("RacePlayer3");

        float player1X = PlayerPrefs.GetFloat("Player1PositionX");
        float player1Y = PlayerPrefs.GetFloat("Player1PositionY");
        player1.GetComponent<Transform>().position = new Vector3(player1X, player1Y, 0.0f);

        float player2X = PlayerPrefs.GetFloat("Player2PositionX");
        float player2Y = PlayerPrefs.GetFloat("Player2PositionY");
        player2.GetComponent<Transform>().position = new Vector3(player2X, player2Y, 0.0f);
        player2.GetComponent<AutonomousCar>().setTargetIndex(PlayerPrefs.GetInt("Player2Index"));

        float player3X = PlayerPrefs.GetFloat("Player3PositionX");
        float player3Y = PlayerPrefs.GetFloat("Player3PositionY");
        player3.GetComponent<Transform>().position = new Vector3(player3X, player3Y, 0.0f);
        player3.GetComponent<AutonomousCar>().setTargetIndex(PlayerPrefs.GetInt("Player3Index"));





        player = FindObjectOfType<CarController>();
        //ai = FindObjectOfType<AutonomousCar>();
        ais = FindObjectsOfType<AutonomousCar>();
        ConfigureClock();
    }

    // Update is called once per frame
    void Update()
    {
        CountTime();
    }

    private void ConfigureClock()
    {
        int confirm = PlayerPrefs.GetInt("RaceBegin");
        if (confirm == 0)
        {
            TimerControl = 0;
            StartanimationPlayed = false;
            PlayerPrefs.SetInt("RaceBegin", 1);
        }
        else
        {
            TimerControl = PlayerPrefs.GetFloat("RaceClock");
            StartanimationPlayed = true;
            player.CanMove = true;
            ais[0].CanMove = true;
            ais[1].CanMove = true;
        }
    }

    private void CountTime()
    {
        if(StartanimationPlayed == false)
        {
            TimerControl += Time.deltaTime;

            if (StartsoundPlayed == false)
            {
                PlaySound("Hunk");
                StartsoundPlayed = true;
            }
            
            if (TimerControl > 3.2f)
            {
                TimerControl = 0;
                player.CanMove = true;
                ais[0].CanMove = true;
                ais[1].CanMove = true;
                StartanimationPlayed = true;
            }   
        }

        else
        {
            TimerControl += Time.deltaTime;
            string mins = ((int)TimerControl / 60).ToString("00");
            string segs = (TimerControl % 60).ToString("00");

            TimerString = string.Format("{00}:{01}", mins, segs);
            UpdateText();
        }
        
    }

    public void UpdateText()
    {
        texttimer.text = TimerString;
        PlayerPrefs.SetFloat("RaceClock", TimerControl);
    }

    public void PlaySound(string sound)
    {
        switch (sound)
        {
            case "Hunk":
                effectplayer.PlayOneShot(Hunk);
                break;
            case "Crash":
                effectplayer.PlayOneShot(Crash);
                break;
            case "Lap":
                effectplayer.PlayOneShot(Lap);
                break;
            case "Oil":
                effectplayer.PlayOneShot(Oil);
                break;

        }
    }
}
