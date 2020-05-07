using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    GameObject camera;
	Rigidbody2D rb;
    GameObject ambulance;

	[SerializeField]
	float accelerationPower = 5f;
	[SerializeField]
	float steeringPower = 5f;
	float steeringAmount, speed, direction;
    public bool CanMove;

    private RaceGameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = GameObject.FindWithTag("MainCamera");
        ambulance = GameObject.FindWithTag("Ambulance");
        gameManager = GameObject.FindObjectOfType<RaceGameManager>();
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

 

      void OnTriggerEnter2D(Collider2D other)
    {
       if(other.gameObject.CompareTag("Oil")){
            accelerationPower = 8f;
            gameManager.PlaySound("Oil");
        }

         if (other.gameObject.CompareTag("PeopleLeft")){
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.transform.position = new Vector3(10000,0,0);
            
            camera.GetComponent<CameraFollow>().changeFollow();
            other.GetComponent<RacePeopleController>().dontMove();
            ambulance.GetComponent<RaceAmbulanceController>().callAmbulance(other.gameObject.GetComponent<Transform>());

        }

         if (other.gameObject.CompareTag("PeopleRight")){
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
            gameObject.transform.position = new Vector3(10000,0,0);
            
            ambulance.GetComponent<Transform>().rotation *= Quaternion.Euler(0,180f,0);
            
            camera.GetComponent<CameraFollow>().changeFollow();
            other.GetComponent<RacePeopleController>().dontMove();
            //ambulance.GetComponent<Transform>().rotation
            ambulance.GetComponent<RaceAmbulanceController>().callAmbulance(other.gameObject.GetComponent<Transform>());

        }


    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Oil")){
            accelerationPower = 25f;

        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameManager.PlaySound("Crash");
    }
    /*
        void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.CompareTag("PeopleLeft")){


            }
        }
        */
}
