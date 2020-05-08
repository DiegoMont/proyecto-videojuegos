using UnityEngine;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour {

    public void playGame() {
        MenuController.playGame();
    }

    public void goToMenu() {
        ProfileManager.goToMainMenu(MenuController.getCurrentPlayer());
    }
}
