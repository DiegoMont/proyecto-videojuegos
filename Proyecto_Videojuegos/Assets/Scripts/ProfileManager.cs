using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ProfileManager : MonoBehaviour {

    public TextMeshProUGUI nombrePlayer1;
    public TextMeshProUGUI nombrePlayer2;
    public TextMeshProUGUI nameInput;
    public GameObject formNombre;
    private string editingPlayer;

    private void Start(){
        nombrePlayer2.text = PlayerPrefs.GetString("player2Name", "Player 2");
        nombrePlayer1.text = PlayerPrefs.GetString("player1Name", "Player 1");
        formNombre.SetActive(false);
    }

    public void checkName() {
        string nombre = nameInput.text;
        if (nombre != "" || nombre.Length < 20)
        {
            crearPerfil(editingPlayer, nombre);
            goToMainMenu(editingPlayer);
        }
        else {
            nameInput.text = "";
        }
    }

    public void loginPlayer1()
    {
        if (PlayerPrefs.GetInt("perfil1EstaActivo", 0) == 0)
        {
            editingPlayer = "PLAYER1";
            formNombre.SetActive(true);
        }
        else
        {
            goToMainMenu("PLAYER1");
        }
    }

    public void loginGuest()
    {
        goToMainMenu("GUEST");
    }

    public void loginPlayer2()
    {
        if (PlayerPrefs.GetInt("perfil2EstaActivo", 0) == 0)
        {
            editingPlayer = "PLAYER1";
            formNombre.SetActive(true);
        }
        else
        {
            goToMainMenu("PLAYER2");
        }
    }

    public void goToMainMenu(string profile) {
        MenuController.setCurrentPlayer(profile);
        SceneManager.LoadScene("Scenes/Menus/Jugar-Tienda");
    }

    public void crearPerfil(string jugador, string name)
    {
        PlayerPrefs.SetString(jugador + "Name", name);
        PlayerPrefs.SetInt(jugador + "Coins", 0);
    }
}
