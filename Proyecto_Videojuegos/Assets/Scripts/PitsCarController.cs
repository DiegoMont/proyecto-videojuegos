using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PitsCarController : MonoBehaviour
{
    public SpriteRenderer iconrenderer;
    public Sprite[] iconsprites;
    public int index;
    private Vector3 carParked;
    private Vector3 carExit;
    public bool caractive = false;
    private bool iconactive = false;
    private bool startengine = false; 
    public int missingWork;
    private float Speed = 2f;
    private float Speed2 = 6.0f;
    private GameObject icon;
    public GameObject iconTarget;
    private PitsEquippedItemController selectedicon;
    private PitsPlayerController player;

    private PitsGameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<PitsGameManager>();
        selectedicon = FindObjectOfType<PitsEquippedItemController>();
        player = FindObjectOfType<PitsPlayerController>();
        icon = transform.GetChild(0).gameObject;
        carParked = new Vector3(-9.2f, -2.6f, 0f);
        carExit = new Vector3(-9.2f, -9.18f, 0f);
        gameManager.PlaySound("carenter");

    }

    void CarAnimation(Vector3 currentTarget)
    {
        float distance = Vector3.Distance(gameObject.transform.position, currentTarget);
        transform.position = Vector3.Lerp(transform.position, currentTarget, (Time.deltaTime * Speed)/distance);
    }

    void StartEngine()
    {
        gameManager.PlaySound("carexit");
    }

    void CreateIcon()
    {
        float randomfloat = UnityEngine.Random.Range(0, iconsprites.Length);
        int randomindex = (int)Math.Round(randomfloat);
        iconrenderer.sprite = iconsprites[randomindex];
        icon.gameObject.transform.position = Vector3.Lerp(icon.gameObject.transform.position, iconTarget.transform.position, Time.deltaTime * Speed2);
        index = randomindex;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(index == selectedicon.index)
            {
                CorrectIcon();
                gameManager.DestroyCones();
            }
            else
            {
                Debug.Log("Incorrecto");
            }

            selectedicon.DropItem();
        }
    }

    private void CorrectIcon()
    {
        if(gameManager.Objectives % 2 == 0)
        {
            gameManager.PlaySound("screw");
        }
        else
        {
            gameManager.PlaySound("nut");
        }
        gameManager.Objectives--;
        gameManager.UpdateText();
        icon.transform.position = gameObject.transform.position;
        if (gameManager.Objectives != 0)
        {
            iconactive = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.win == false)
        {

            if (caractive == false)
            {
                CarAnimation(carParked);
            }

            if (transform.position == carParked && caractive == false)
            {
                caractive = true;
                gameManager.backgroundMusic.Play();
                gameManager.SwitchPlayerMovement();
                gameManager.EnableInstructions();
                gameManager.StartTimer = true;

            }

            if (caractive && iconactive == false)
            {
                CreateIcon();
            }

            if (icon.transform.position == iconTarget.transform.position)
            {
                iconactive = true;
            }
        } else if(gameManager.win && player.CarExit)
        {
            if(startengine == false)
            {
                StartEngine();
                startengine = true;
            }

            CarAnimation(carExit);
        }

        if(gameManager.win && player.CarExit && transform.position == carExit)
        {
            gameManager.WonTransition();
        }
    }

}
