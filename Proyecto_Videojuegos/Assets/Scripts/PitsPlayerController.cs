using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitsPlayerController : MonoBehaviour
{
    //Controladores a los que se tiene acceso
    private PitsGameManager gameManager;
    private PitsEquippedItemController selectedicon;

    //Variables para métodos de movimiento controlado por usuario
    public float moveSpeed;
    public Animator animator;
    public Rigidbody2D rigidbody2D;
    public SpriteRenderer spriteRenderer;
    private float speed = 2f;
    
    //Variable para mostrar y ocultar el menú de herramientas
    public GameObject toolMenu;

    //Variables para animación de victoria y bloquear movimiento de jugador
    private Vector3 Safespot;
    public bool move = false;
    public bool CarExit = false;

    //Varaibles para efectos de sonido
    public AudioClip getCoinClip;

    //Variables para efectos de los objetos de la tienda
    private int valorMonedas;


    void Start()
    {
        gameManager = FindObjectOfType<PitsGameManager>();
        selectedicon = FindObjectOfType<PitsEquippedItemController>();
        Safespot = transform.position;
        valorMonedas = 1 + PlayerPrefs.GetInt(MenuController.currentPlayer + "StoreObjectActive7");
        moveSpeed *= PlayerPrefs.GetInt(MenuController.currentPlayer + "StoreObjectActive6") + 1;
    }

    private void FixedUpdate()
    {
        if(move == false && gameManager.win == true)
        {
            spriteRenderer.flipX = false;
            MovetoSafe();
        }

        if (move == false && gameManager.win == true && transform.position == Safespot)
        {
            animator.SetFloat("xmove", 0);
            animator.SetFloat("ymove", 0);
            CarExit = true;
        }

        if (move == false)
        {
            return;
        }

        float xInput = Input.GetAxis("Horizontal");

        if (xInput < 0.1)
        {
            spriteRenderer.flipX = true;
        }
        else if (xInput >= 0)
        {
            spriteRenderer.flipX = false;
        }

        float yInput = Input.GetAxis("Vertical");

        float xForce = xInput * moveSpeed * Time.deltaTime;
        float yForce = yInput * moveSpeed * Time.deltaTime;

        Vector2 velocity = new Vector2(xForce, yForce);
        rigidbody2D.velocity = velocity;

        animator.SetFloat("xmove", Mathf.Abs(velocity.x));
        animator.SetFloat("ymove", velocity.y);
    }

    //Métodos para detectar daño o elección de herramienta (Permanecer en trigger)
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("ToolZone"))
        {
            toolMenu.SetActive(true);
            gameManager.QuitInstructions();
        }

        if (other.CompareTag("Coin"))
        {
            gameObject.GetComponent<AudioSource>().PlayOneShot(getCoinClip);
            int dineroActual = PlayerPrefs.GetInt("EarnedCoins");
            dineroActual += valorMonedas;
            PlayerPrefs.SetInt("EarnedCoins", dineroActual);
            Destroy(other.gameObject);
            Debug.Log(dineroActual);
        }

        if (other.CompareTag("Cone"))
        {
            spriteRenderer.color = Color.red;
        }
    }

    //Métodos para detectar daño o elección de herramienta (Salir de trigger)
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("ToolZone"))
        {
            toolMenu.SetActive(false);
        }

        if (other.CompareTag("Cone"))
        {
            gameManager.PlaySound("harm");
            selectedicon.DropItem();
            spriteRenderer.color = Color.white;
            gameManager.Lives--;
            Destroy(other.gameObject);
        }
    }

    //Método de transición para animación de victoria, movimiento automático a lugar seguro
    public void MovetoSafe()
    {
        float distance = Vector3.Distance(gameObject.transform.position, Safespot);
        transform.position = Vector3.Lerp(transform.position, Safespot, (Time.deltaTime * speed) / distance);
    }
}
