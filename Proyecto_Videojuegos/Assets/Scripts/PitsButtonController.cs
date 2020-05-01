using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PitsButtonController : MonoBehaviour
{
    //Controladores a los que se tiene acceso
    public PitsEquippedItemController equippedtool;
    private PitsGameManager gameManager;

    //Variable que permite verificar si la herramienta es correcta o incorrecta
    public int index;


    private void Start()
    {
        gameManager = FindObjectOfType<PitsGameManager>();
    }

    //Método que envía el índice de la herramienta clickeada a la imagen de herramienta seleccionada
    public void ClickItem()
    {
        gameManager.PlaySound("button");
        equippedtool.ChangeItem(index);
    }

}
