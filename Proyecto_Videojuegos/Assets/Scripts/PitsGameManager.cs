using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PitsGameManager : MonoBehaviour
{
    //Controladores a los que se tiene acceso
    private PitsPlayerController player;
    private PitsSpawnerController spawner;


    //Variables para animaciones de victoria e inicio de juego
    public bool playerCanMove = false;
    public bool showInstructions = true;
    public bool win = false;
    public bool loose = false;
    private bool spawninit = false;

    //Variables para la asignación de dificultad
    private float conefreq;
    private float tirefreq;
    private float coinfreq;


    //Variables utilizadas para la medición de tiempo en cronómetro
    public float TimerControl;
    public bool StartTimer = false;
    private bool alerted = false;


    //Variables utilizadas en asignación de elementos visuales y sonoros
    public TextMeshProUGUI textlives, texttimer, textobjectives, textoMonedas;
    public int Objectives;
    public int Lives;
    public string TimerString;
    public AudioSource backgroundMusic;
    public AudioSource effectplayer;
    public AudioClip screw, nut, harm, tiktak, carenter, carexit, button;
    public GameObject instructionsview;


    //Al inicializar el juego se asigna el tiempo límite, las vidas y reparaciones por hacer
    //FALTA ASIGNAR LOS VALORES ACORDE A DIFICULTAD MEDIANTE OBJETO DONT DESTROY ON LOAD
    void Awake() {
        string difficulty = PlayerPrefs.GetString("Difficulty");
        switch (difficulty)
        {
            case "EASY":
                tirefreq = 10f;
                coinfreq = 10;
                conefreq = 7f;
                Objectives = 1;
                break;
            case "MEDIUM":
                tirefreq = 8f;
                coinfreq = 8f;
                conefreq = 5f;
                Objectives = 3;
                break;
            case "HARD":
                tirefreq = 6f;
                coinfreq = 6f;
                conefreq = 3f;
                Objectives = 5;
                break;
        }

        TimerControl = 90;
    }
    void Start()
    {
        Lives = 3;

        player = FindObjectOfType<PitsPlayerController>();
        spawner = FindObjectOfType<PitsSpawnerController>();

        string mins = ((int)TimerControl / 60).ToString("00");
        string segs = (TimerControl % 60).ToString("00");
        TimerString = string.Format("{00}:{01}", mins, segs);
        texttimer.text = TimerString;

        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        if (Objectives == 0 && win == false)
        {
            StartTimer = false;
            GameWon();
        }

        if (StartTimer == true)
        {
            CountDown();
        }

        if (TimerControl <= 0)
        {
            StartTimer = false;
            GameOver();
        }

        if (Lives == 0)
        {
            GameOver();
        }

        if (StartTimer == true && TimerControl > 0.5 && spawninit == false)
        {
            spawninit = true;
            InvokeRepeating("spawnTire", 1f, tirefreq);
            InvokeRepeating("spawnCoin", 1f, coinfreq);
            InvokeRepeating("spawnCone", 1f, conefreq);
        }

        if (TimerControl < 15 && alerted == false)
        {
            PlaySound("tiktak");
            alerted = true;
        }
    }

    //Método que permite a usuario moverse o perder posibilidad de moverse
    public void SwitchPlayerMovement()
    {
        player.move = !player.move;
    }

    //Método que destruye las indicaciones de elecctión de herramientas al acceder al menú por primera vez
    public void QuitInstructions()
    {
        if (showInstructions == true)
        {
            Destroy(instructionsview);
            showInstructions = false;
        }
    }

    //Método que muestra las indicaciones de elecctión de herramientas al iniciar el juego
    public void EnableInstructions()
    {
        instructionsview.SetActive(true);
    }

    //Método que actualiza los datos del juego en la barra de elementos visuales
    public void UpdateText()
    {
        texttimer.text = TimerString;
        textobjectives.text = "x" + Objectives;
        textlives.text = "x" + Lives;
        updateMoneditas();
    }

    //Método que actualiza la cuenta regresiva del reloj
    private void CountDown()
    {
        TimerControl -= Time.deltaTime;
        string mins = ((int)TimerControl / 60).ToString("00");
        string segs = (TimerControl % 60).ToString("00");

        TimerString = string.Format("{00}:{01}", mins, segs);
        UpdateText();
    }

    //Método de pérdida de juego
    //FALTA IMPLEMENTAR EL CAMBIO DE ESCENA A MENÚ DE GAME OVER
    public void GameOver()
    {
        player.move = false;
        SceneManager.LoadScene("Scenes/Menus/GameOverScene");
    }

    //Método que inicializa las animaciones de victoria y detiene el temporizador
    public void GameWon()
    {
        player.move = false;
        win = true;
        CancelInvoke();
    }

    //Método que regresa a la escena de carreras con vida del carro al máximo
    //FALTA EL CAMBIO DE ESCENA
    public void WonTransition()
    {

        string pistaToPlay = PlayerPrefs.GetString("pistaToPlay");

        if (pistaToPlay == "Pista1") {
            SceneManager.LoadScene("Scenes/RaceScene");
        } else {
            SceneManager.LoadScene("Scenes/RaceScene2");
        }



    }

    //Método que llama al método de controlador de conos para destruírlos al reparar correctamente una avería
    public void DestroyCones()
    {
        //PitsConeController[] cones = FindObjectsOfType<PitsConeController>();
        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Cone");
        foreach (GameObject obstacle in obstacles) {
            Destroy(obstacle);
        }

    }

    //Método que permite la reproducción de los sonidos del juego
    public void PlaySound(string sound)
    {
        //screw, nut, harm, tiktak, carenter, carexit, button;
        switch (sound) {
            case "screw":
                effectplayer.PlayOneShot(screw);
                break;
            case "nut":
                effectplayer.PlayOneShot(nut);
                break;
            case "harm":
                effectplayer.PlayOneShot(harm);
                break;
            case "tiktak":
                effectplayer.PlayOneShot(tiktak);
                break;
            case "carenter":
                effectplayer.PlayOneShot(carenter);
                break;
            case "carexit":
                effectplayer.PlayOneShot(carexit);
                break;
            case "button":
                effectplayer.PlayOneShot(button);
                break;
        }
    }

    private void updateMoneditas() {
        textoMonedas.text = PlayerPrefs.GetInt("EarnedCoins").ToString();
    }

    private void spawnTire() {
        spawner.spawnTire();
    }

    private void spawnCoin() {
        spawner.spawnCoin();
    }

    private void spawnCone()
    {
        spawner.Spawn();
    }

}
