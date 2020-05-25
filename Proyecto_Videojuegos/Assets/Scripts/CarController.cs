using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    // Velocidades: 18, 25, 35
    GameObject camera;
	Rigidbody2D rb;
    GameObject ambulance;
    public SpriteRenderer spriteRender;
    public Sprite verde, amarillo;


	[SerializeField]
	float accelerationPower;
	[SerializeField]
	float steeringPower = 5f;
	float steeringAmount, speed, direction;
    public bool CanMove;
    public int racePoints;

    private RaceGameManager gameManager;

    public GameObject player2;
    public GameObject player3;

    //Habilidades de la tienda
    public int tribuneGuard;
    public int rainTire;
    public static int immunity;
    public string currentPlayer;

    public float lastAcceleration;
  
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = GameObject.FindWithTag("MainCamera");
        ambulance = GameObject.FindWithTag("Ambulance");
        gameManager = GameObject.FindObjectOfType<RaceGameManager>();
        player2 = GameObject.FindWithTag("RacePlayer2");
        player3 = GameObject.FindWithTag("RacePlayer3");

        currentPlayer = MenuController.currentPlayer;

        LoadCar();

        tribuneGuard = PlayerPrefs.GetInt(currentPlayer + "StoreObjectActive3");
        if (tribuneGuard==1) {
            activateTribuneGuard();
        }

        rainTire = PlayerPrefs.GetInt(currentPlayer + "StoreObjectActive4");
        immunity = PlayerPrefs.GetInt(currentPlayer + "StoreObjectActive5");
        RaceTireSpawnerController.inmunidad = immunity;
        
    }

    // Update is called once per frame
    void Update()
    {
        //accelerationPower = 5f;
    }

    void FixedUpdate() {
        if (CanMove == false)
        {
            return;
        }

        else
        {   

            steeringAmount = -Input.GetAxis("Horizontal");
            speed = Input.GetAxis("Vertical") * accelerationPower;
            direction = Mathf.Sign(Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up)));
            rb.rotation += steeringAmount * steeringPower * rb.velocity.magnitude * direction;

            rb.AddRelativeForce(Vector2.up * speed);
            rb.AddRelativeForce(-Vector2.right * rb.velocity.magnitude * steeringAmount / 2);
        }
    }

      public void LoadCar()
    {
        int loadedcar = 0;
        for(int i=0; i<=2; i++)
        {
            int state = PlayerPrefs.GetInt(MenuController.currentPlayer + "StoreObjectActive" + i, 0);
            if(state == 1)
            {
                loadedcar = i;
            }
        }

        switch (loadedcar)
        {
            case 0:
                spriteRender.sprite = verde;
                accelerationPower = 21f;
                lastAcceleration = accelerationPower;
                break;
            case 1:
                spriteRender.sprite = amarillo;
                accelerationPower = 26f;
                lastAcceleration = accelerationPower;
                break;
            case 2:
                spriteRender.sprite = amarillo;
                spriteRender.color = Color.red;
                accelerationPower = 35f;
                lastAcceleration = accelerationPower;
                break;

        }
    }

      void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Oil")){
            if(rainTire != 1) {
                accelerationPower = 8f;
                gameManager.PlaySound("Oil");
            }
            
        }

        /*

         if (other.gameObject.CompareTag("PeopleLeft")){
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.transform.position = new Vector3(10000,0,0);
            
            camera.GetComponent<CameraFollow>().changeFollow();
            other.GetComponent<RacePeopleController>().dontMove();
            ambulance.GetComponent<RaceAmbulanceController>().callAmbulance(other.gameObject.GetComponent<Transform>());

        }
        */

         if (other.gameObject.CompareTag("Ruta1")){
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.transform.position = new Vector3(10000,0,0);
            player2.transform.position = new Vector3(10000,0,0);
            player3.transform.position = new Vector3(10000,0,0);

            
            //ambulance.GetComponent<Transform>().rotation *= Quaternion.Euler(0,180f,0);
            
            camera.GetComponent<CameraFollow>().changeFollow();
            other.GetComponent<RacePeopleController>().dontMove();
           
            ambulance.GetComponent<RaceNewAmbulanceController>().callAmbulance("Ruta1");

        }

        if (other.gameObject.CompareTag("Ruta2")){
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.transform.position = new Vector3(10000,0,0);
            player2.transform.position = new Vector3(10000,0,0);
            player3.transform.position = new Vector3(10000,0,0);
            
            //ambulance.GetComponent<Transform>().rotation *= Quaternion.Euler(0,180f,0);
            
            camera.GetComponent<CameraFollow>().changeFollow();
            other.GetComponent<RacePeopleController>().dontMove();
           
            ambulance.GetComponent<RaceNewAmbulanceController>().callAmbulance("Ruta2");

        }

        if (other.gameObject.CompareTag("Ruta3")){
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.transform.position = new Vector3(10000,0,0);
            player2.transform.position = new Vector3(10000,0,0);
            player3.transform.position = new Vector3(10000,0,0);
            
            //ambulance.GetComponent<Transform>().rotation *= Quaternion.Euler(0,180f,0);
            
            camera.GetComponent<CameraFollow>().changeFollow();
            other.GetComponent<RacePeopleController>().dontMove();
           
            ambulance.GetComponent<RaceNewAmbulanceController>().callAmbulance("Ruta3");

        }




    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Oil")){

            accelerationPower = lastAcceleration;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.PlaySound("Crash");
    }
    public void setPoints(int points) {
        racePoints = points;
    }
    public int getPoints() {
        return racePoints;
    }
    public void activateTribuneGuard() {
        GameObject[] ruta1 = GameObject.FindGameObjectsWithTag("Ruta1");
        GameObject[] ruta2 = GameObject.FindGameObjectsWithTag("Ruta2");
        GameObject[] ruta3 = GameObject.FindGameObjectsWithTag("Ruta3");

        foreach (GameObject ruta in ruta1) {
            ruta.SetActive(false);
        }
        foreach (GameObject ruta in ruta2) {
            ruta.SetActive(false);
        }
        foreach (GameObject ruta in ruta3) {
            ruta.SetActive(false);
        }

    }
}
