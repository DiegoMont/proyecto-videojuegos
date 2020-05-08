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
