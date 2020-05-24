using UnityEngine;
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
    public GameObject menuMapa;
    public GameObject tienda;
    public GameObject items;

    void hideAll(){
        menuinicio.SetActive(false);
        menuDificultad.SetActive(false);
        barraJugador.SetActive(false);
        menuMapa.SetActive(false);
        tienda.SetActive(false);
        items.SetActive(false);
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

    public static void playGame()
    {
        PlayerPrefs.SetInt("EarnedCoins", 0);
    }

    public void playMap1()
    {
        playGame();
        SceneManager.LoadScene("Scenes/RaceScene");
        PlayerPrefs.SetString("pistaToPlay", "Pista1");

        //Guardar la posición inicial de cada jugador y su index pista 1
      PlayerPrefs.SetFloat("Player1PositionX", -1.69f);
      PlayerPrefs.SetFloat("Player1PositionY", 4.02f);
      PlayerPrefs.SetInt("Player1Points", 0);

      PlayerPrefs.SetFloat("Player2PositionX", -3.93f);
      PlayerPrefs.SetFloat("Player2PositionY", 4.03f);
      PlayerPrefs.SetInt("Player2Index", 0);
      PlayerPrefs.SetInt("Player2Points", 0);

      PlayerPrefs.SetFloat("Player3PositionX", -2.6f);
      PlayerPrefs.SetFloat("Player3PositionY", 3.19f);
      PlayerPrefs.SetInt("Player3Index", 0);
      PlayerPrefs.SetInt("Player3Points", 0);

      PlayerPrefs.SetInt("numberLaps", 0);
      PlayerPrefs.SetInt("numberLapsP2", 0);
      PlayerPrefs.SetInt("numberLapsP3", 0);
    }

    public void playMap2()
    {
        playGame();
        SceneManager.LoadScene("Scenes/RaceScene2");
        PlayerPrefs.SetString("pistaToPlay", "Pista2");
        //Guardar la posición inicial de cada jugador y su index pista 2
      PlayerPrefs.SetFloat("Player1PositionX", -16.77f);
      PlayerPrefs.SetFloat("Player1PositionY", -1.41f);
      PlayerPrefs.SetInt("Player1Points", 0);

      PlayerPrefs.SetFloat("Player2PositionX", -19.01f);
      PlayerPrefs.SetFloat("Player2PositionY", -1.41f);
      PlayerPrefs.SetInt("Player2Index", 0);
      PlayerPrefs.SetInt("Player2Points", 0);

      PlayerPrefs.SetFloat("Player3PositionX", -18.04f);
      PlayerPrefs.SetFloat("Player3PositionY", -2.21f);
      PlayerPrefs.SetInt("Player3Index", 0);
      PlayerPrefs.SetInt("Player3Points", 0);

      PlayerPrefs.SetInt("numberLaps", 0);
      PlayerPrefs.SetInt("numberLapsP2", 0);
      PlayerPrefs.SetInt("numberLapsP3", 0);
    }

    public void selectMap()
    {
        hideAll();
        menuMapa.SetActive(true);
    }

    public void selectDifficulty(){

      hideAll();
      menuDificultad.SetActive(true);
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
      PlayerPrefs.SetString("Difficulty", difficulty);
      selectMap();
    }

    public void difficultyMedium(){
      difficulty = "MEDIUM";
      PlayerPrefs.SetString("Difficulty", difficulty);
      selectMap();
    }

    public void difficultyHard(){
      difficulty = "HARD";
      PlayerPrefs.SetString("Difficulty", difficulty);
      selectMap();
    }

    public void OpenStore()
    {
        hideAll();
        tienda.SetActive(true);
        barraJugador.SetActive(true);
    }

    public void OpenItems()
    {
        hideAll();
        items.SetActive(true);
        barraJugador.SetActive(true);
    }

    public void BacktoStart()
    {
        hideAll();
        menuinicio.SetActive(true);
        barraJugador.SetActive(true);
    }

}
