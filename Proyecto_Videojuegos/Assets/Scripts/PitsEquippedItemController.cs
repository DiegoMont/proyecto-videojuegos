using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PitsEquippedItemController : MonoBehaviour
{
    //Variables que se usarán en métodos locales
    public Sprite[] sprites;
    public Image itemImage;
    public int index;
    
    //Al iniciar el objeto, se asigna la imagen con índice 6, que indica ninguna herramienta seleccionada
    void Start()
    {
        index = 6;
    }

    //Método que recibe el índice de imagen clickeada y se asigna a la imgagen de herramienta seleccionada
    public void ChangeItem(int newindex)
    {
        index = newindex;
        itemImage.sprite = sprites[index];
    }

    //Método que indica la imagen de ningún elemento seleccionado
    public void DropItem()
    {
        itemImage.sprite = sprites[6];
        index = 6;
    }

}
