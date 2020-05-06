using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{


	Rigidbody2D rb;

	[SerializeField]
	float accelerationPower = 5f;
	[SerializeField]
	float steeringPower = 5f;
	float steeringAmount, speed, direction;
    public bool CanMove;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

         }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Oil")){
            accelerationPower = 25f;

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("PeopleLeft")){
            

        }
    }
    
}
