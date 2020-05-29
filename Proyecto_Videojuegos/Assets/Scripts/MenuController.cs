using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    private static string difficulty = "MEDIUM";
    public static string currentPlayer = "GUEST";
    public TextMeshProUGUI nombreJugador;
    public TextMeshProUGUI dineroJugador;
    public GameObject menuinicio;
    public GameObject menuDificultad;
    public GameObject barraJugador;
    public GameObject menuMapa;
    public GameObject tienda;
    public GameObject items;

    public GameObject[] storeItems;
    public GameObject[] boughtItems;
    public Button[] itembuttons;
    private int[] prices = new int[] { 0, 80, 160, 80, 60, 100, 25, 100, 100 };
    public Sprite active;
    public Sprite unactive;

    private MenuAudio audio;

    void hideAll(){
        menuinicio.SetActive(false);
        menuDificultad.SetActive(false);
        barraJugador.SetActive(false);
        menuMapa.SetActive(false);
        tienda.SetActive(false);
        items.SetActive(false);
    }

    void Start() {
        //PlayerPrefs.SetInt(currentPlayer + "Coins", 600);

        hideAll();
        loadPlayerInfo();
        menuinicio.SetActive(true);
        barraJugador.SetActive(true);
        PlayerPrefs.SetInt("RaceBegin", 0);
        PlayerPrefs.SetFloat("RaceClock", 0);
        audio = FindObjectOfType<MenuAudio>();


        int car2 = PlayerPrefs.GetInt(currentPlayer + "StoreObjectActive1", 0);
        int car3 = PlayerPrefs.GetInt(currentPlayer + "StoreObjectActive2", 0);

        if (car2 == 1 || car3 == 1)
        {
            PlayerPrefs.SetInt(currentPlayer + "StoreObjectActive0", 0);
        }
        else
        {
            PlayerPrefs.SetInt(currentPlayer + "StoreObjectActive0", 1);
        }

        PlayerPrefs.SetInt(currentPlayer + "StoreObject0", 1);     
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
        PlayerPrefs.SetInt("firstP1", 0);
        PlayerPrefs.SetInt("firstP2", 0);
        PlayerPrefs.SetInt("firstP3", 0);

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
        UpdateStore();
    }

    public void OpenItems()
    {
        hideAll();
        items.SetActive(true);
        barraJugador.SetActive(true);
        UpdateItems();
    }

    public void BacktoStart()
    {
        hideAll();
        menuinicio.SetActive(true);
        barraJugador.SetActive(true);
    }

    public void BuyItem(int indexitem)
    {
        int coins = PlayerPrefs.GetInt(currentPlayer + "Coins", 0);
        if (coins > prices[indexitem]) {
            audio.playStoreSound(1);
            PlayerPrefs.SetInt(currentPlayer + "Coins", coins - prices[indexitem]);
            PlayerPrefs.SetInt(currentPlayer + "StoreObject" + indexitem, 1);
        }
        else
        {
            //Reproducir sonido de dinero insuficiente
            audio.playStoreSound(0);
            Debug.Log("Dinero insuficiente");
        }
        UpdateStore();
    }

    public void UpdateStore()
    {
        for(int i=0; i<storeItems.Length; i++)
        {
            int bought = PlayerPrefs.GetInt(currentPlayer + "StoreObject" + i, 0);
            if (bought == 1)
            {
                storeItems[i].SetActive(false);
            }
            else
            {
                storeItems[i].SetActive(true);
            }
        }
        loadPlayerInfo();
    }

    public void UpdateItems()
    {
        for(int i=0; i<boughtItems.Length; i++)
        {
            int bought = PlayerPrefs.GetInt(currentPlayer + "StoreObject" + i, 0);
            if (bought == 1)
            {
                boughtItems[i].SetActive(true);
            }
            else
            {
                boughtItems[i].SetActive(false);
            }
        }

        for(int i=3; i<itembuttons.Length; i++)
        {
            int butstate = PlayerPrefs.GetInt(currentPlayer + "StoreObjectActive" + i, 0);
            if (butstate==0)
            {
                itembuttons[i].image.sprite = unactive;
            }
            else
            {
                itembuttons[i].image.sprite = active;
            }
        }

        for (int i = 0; i <= 2; i++)
        {
            int carsellected = PlayerPrefs.GetInt(currentPlayer + "StoreObjectActive" + i, 0);
            
            if(carsellected == 1)
            {
                itembuttons[i].image.sprite = active;
            }
            else
            {
                itembuttons[i].image.sprite = unactive;
            }
        }
    }

    public void SwitchButton(int index)
    {
            int state = PlayerPrefs.GetInt(currentPlayer + "StoreObjectActive" + index, 0);
            if(state == 0)
            {
                PlayerPrefs.SetInt(currentPlayer + "StoreObjectActive" + index, 1);
                itembuttons[index].image.sprite = active;
            }
            else
            {
                PlayerPrefs.SetInt(currentPlayer + "StoreObjectActive" + index, 0);
                itembuttons[index].image.sprite = unactive;
            }
        audio.ItemsSound();
    }

    public void CarButton(int index)
    {
        for(int i=0; i<=2; i++)
        {
            PlayerPrefs.SetInt(currentPlayer + "StoreObjectActive" + i, 0);
            itembuttons[i].image.sprite = unactive;
        }

        PlayerPrefs.SetInt(currentPlayer + "StoreObjectActive" + index, 1);
        itembuttons[index].image.sprite = active;

        audio.ItemsSound();
    }
    

}
