using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaceGameManager : MonoBehaviour
{
    private CarController player;
    //private AutonomousCar ai;
    private AutonomousCar[] ais;

    private float StartTime;
    private float TimerControl;
    private bool StartanimationPlayed;
    private bool StartsoundPlayed;

    public TextMeshProUGUI texttimer;
    private string TimerString;


    public AudioClip Hunk, Crash, Oil, Lap;
    public AudioSource effectplayer;

    void Start()
    {
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
        if (StartanimationPlayed == false)
        {
            StartTime = 0;
        }
        else
        {
            //Cargar tiempo antes de entrar a los pits
        }
    }

    private void CountTime()
    {
        if(StartanimationPlayed == false)
        {
            TimerControl = (StartTime) + Time.time;

            if (StartsoundPlayed == false)
            {
                PlaySound("Hunk");
                StartsoundPlayed = true;
            }
            
            if (TimerControl > 2.7f)
            {
                StartTime -= 2.7f;
                player.CanMove = true;
                ais[0].CanMove = true;
                ais[1].CanMove = true;
                StartanimationPlayed = true;
            }   
        }

        else
        {
            TimerControl = (StartTime) + Time.time;
            string mins = ((int)TimerControl / 60).ToString("00");
            string segs = (TimerControl % 60).ToString("00");

            TimerString = string.Format("{00}:{01}", mins, segs);
            UpdateText();
        }
        
    }

    public void UpdateText()
    {
        texttimer.text = TimerString;
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
