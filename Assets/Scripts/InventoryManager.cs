using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private int _nRupees = 0;
    private int _nBombs = 0;
    //espada, escudo especial(tienda), bombas (tienda), flechas(tienda)
    //Al crear la zona de conseguir cada item este le pasa un id al personaje
    //que es el que usa para identificarlos y desbloquearlos
    private bool[] _itemsUnlocked = new bool[4];

    //objeto en el Botón A, objeto en el Boton B, el int corresponde al id del objeto
    //inicializado a valores fuera del rango de item ID
    private int[] itemsEquiped = {-1,-1}; 

    public void ChangeRupeeAmount(int value)
    {
        _nRupees += value;
    }

    //al comprar las bombas en la tienda consigues 4 y a veces consigues 1 al matar enemigos. Esta 2a opción se desbloquea al comprarlas por 1a vez
    public void ChangeBombAmount(int value)
    {
        _nBombs += value;
    }

    public void UnlockItem(int itemId)
    {
        _itemsUnlocked[itemId] = true;
    }

    //se equipa automáticamente en el botón B, porque lo único que se equipa al botón A es a la espada.
    public void ChangeItemEquiped(int itemId, int itemSlot)
    {
        itemsEquiped[itemSlot] = itemId;
    }
}
