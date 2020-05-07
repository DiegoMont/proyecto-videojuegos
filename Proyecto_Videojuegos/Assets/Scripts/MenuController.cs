using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {

    private static string difficulty = "MEDIUM";
    private static string currentPlayer = "GUEST";
    public TextMeshProUGUI nombreJugador;
    public TextMeshProUGUI dineroJugador;
    public GameObject menuJuegoYTienda;
    public GameObject menuDificultad;

    void hideAll(){
      menuJuegoYTienda.SetActive(false);
      menuDificultad.SetActive(false);
    }

    void Start() {
        hideAll();
        loadPlayerInfo();
        menuJuegoYTienda.SetActive(true);
    }

    private void loadPlayerInfo() {
        nombreJugador.text = PlayerPrefs.GetString(currentPlayer+"Name", "Guest");
        dineroJugador.text = PlayerPrefs.GetInt(currentPlayer+"Coins", 0).ToString();
    }

    public void goToProfileSelection() {
        SceneManager.LoadScene("Scenes/Menus/Elegir Perfil");
    }

    public void playGame(){
      SceneManager.LoadScene("Scenes/RaceScene");
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
