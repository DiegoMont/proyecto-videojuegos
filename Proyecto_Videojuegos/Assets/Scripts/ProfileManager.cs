using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ProfileManager : MonoBehaviour {

    public TextMeshProUGUI nombrePlayer1;
    public TextMeshProUGUI nombrePlayer2;
    public TextMeshProUGUI nameInput;
    public TextMeshProUGUI placeholder;
    public GameObject formNombre;
    private string editingPlayer;

    private void Start(){
        nombrePlayer2.text = PlayerPrefs.GetString("PLAYER2Name", "Player 2");
        nombrePlayer1.text = PlayerPrefs.GetString("PLAYER1Name", "Player 1");
        formNombre.SetActive(false);
    }

    public void checkName() {
        string nombre = nameInput.text;
        if (3 < nombre.Length && nombre.Length < 20)
        {
            Debug.Log(nombre.Length);
            crearPerfil(editingPlayer, nombre);
            goToMainMenu(editingPlayer);
        }
        else {
            nameInput.text = " ";
            //Debug.Log(nameInput.text.Length);
        }
    }

    public void loginPlayer1()
    {
        if (PlayerPrefs.GetInt("PLAYER1Activo", 0) == 0)
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
        if (PlayerPrefs.GetInt("PLAYER2Activo", 0) == 0)
        {
            editingPlayer = "PLAYER2";
            placeholder.text = "Player 2";
            formNombre.SetActive(true);
        }
        else
        {
            goToMainMenu("PLAYER2");
        }
    }

    public static void goToMainMenu(string profile) {
        MenuController.setCurrentPlayer(profile);
        SceneManager.LoadScene("Scenes/Menus/Jugar-Tienda");
    }

    public void crearPerfil(string jugador, string name)
    {
        PlayerPrefs.SetString(jugador + "Name", name);
        PlayerPrefs.SetInt(jugador + "Coins", 0);
        PlayerPrefs.SetInt(editingPlayer + "Activo", 1);
    }

    public void resetPrefs() {
        nombrePlayer1.text = "Player 1";
        nombrePlayer2.text = "Player 2";
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("PLAYER2Name");
        PlayerPrefs.DeleteKey("PLAYER1Name");
        PlayerPrefs.DeleteKey("PLAYER2Coins");
        PlayerPrefs.DeleteKey("PLAYER1Coins");
        PlayerPrefs.DeleteKey("PLAYER1Activo");
        PlayerPrefs.DeleteKey("PLAYER2Activo");
    }
    
}
