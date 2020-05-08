﻿using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    private static string difficulty = "MEDIUM";
    private static string currentPlayer = "GUEST";
    public TextMeshProUGUI nombreJugador;
    public TextMeshProUGUI dineroJugador;
    public GameObject menuinicio;
    public GameObject menuDificultad;
    public GameObject barraJugador;

    void hideAll(){
        menuinicio.SetActive(false);
      menuDificultad.SetActive(false);
        barraJugador.SetActive(false);
    }

    void Start() {
        hideAll();
        loadPlayerInfo();
        menuinicio.SetActive(true);
        barraJugador.SetActive(true);
        PlayerPrefs.SetInt("RaceBegin", 0);
        PlayerPrefs.SetFloat("RaceClock", 0);
    }

    private void loadPlayerInfo() {
        nombreJugador.text = PlayerPrefs.GetString(currentPlayer+"Name", "Guest");
        dineroJugador.text = PlayerPrefs.GetInt(currentPlayer+"Coins", 0).ToString();
    }

    public void goToProfileSelection() {
        SceneManager.LoadScene("Scenes/Menus/Elegir Perfil");
    }

    public static void playGame(){
      SceneManager.LoadScene("Scenes/RaceScene");
    }

    public void selectDifficulty(){
      hideAll();
      menuDificultad.SetActive(true);

      //Guardar la posición inicial de cada jugador


      PlayerPrefs.SetFloat("Player1PositionX", -1.69f);
      PlayerPrefs.SetFloat("Player1PositionY", 4.02f);
      PlayerPrefs.SetFloat("Player2PositionX", -3.93f);
      PlayerPrefs.SetFloat("Player2PositionY", 4.03f);
      PlayerPrefs.SetFloat("Player3PositionX", -2.6f);
      PlayerPrefs.SetFloat("Player3PositionY", 3.19f);

    }

    public static string getDifficulty(){
      return difficulty;
    }

    public static string getCurrentPlayer() {
        return currentPlayer;
    }

    public static void setCurrentPlayer(string profile) {
        if (profile == "PLAYER1")
            currentPlayer = "PLAYER1";
        else if (profile == "PLAYER2")
            currentPlayer = "PLAYER2";
        else
            currentPlayer = "GUEST";
    }

    public void difficultyEasy(){
      difficulty = "EASY";
      playGame();
    }

    public void difficultyMedium(){
      difficulty = "MEDIUM";
      playGame();
    }

    public void difficultyHard(){
      difficulty = "HARD";
      playGame();
    }

}
