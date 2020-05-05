using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour {
    private static string difficulty = "MEDIUM";

    public GameObject menuPerfiles;
    public GameObject menuJuegoYTienda;
    public GameObject menuDificultad;

    void hideAll(){
      menuPerfiles.SetActive(false);
      menuJuegoYTienda.SetActive(false);
      menuDificultad.SetActive(false);
    }

    void Start(){
      hideAll();
      selectProfile();
    }

    public void  selectGame(){
      hideAll();
      menuJuegoYTienda.SetActive(true);
    }

    public void playGame(){
      SceneManager.LoadScene("Scenes/RaceScene");
    }

    public void selectProfile(){
      hideAll();
      menuPerfiles.SetActive(true);
    }

    public void selectDifficulty(){
      hideAll();
      menuDificultad.SetActive(true);
    }

    public static string getDifficulty(){
      return difficulty;
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
