using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance;

    [SerializeField]
    private HUDmanager _hudManager;

    public int nRupees { get; private set; } = 0;
    public int nBombs { get; private set; } = 0;
    public int nKeys { get; private set; } = 0;
    //espada, escudo especial(tienda), bombas (tienda), flechas(tienda)
    //Al crear la zona de conseguir cada item este le pasa un id al personaje
    //que es el que usa para identificarlos y desbloquearlos
    public bool[] itemsUnlocked = new bool[4];

    //Entre 1 y 3 que son los valores de los items distintos a la espada.
    private int itemEquiped = -1;

    void Start()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public void ChangeRupeeAmount(int value)
    {
        nRupees += value;
        _hudManager.UpdateCurrentRupees(nRupees);
    }

    //al comprar las bombas en la tienda consigues 4 y a veces consigues 1 al matar enemigos. Esta 2a opción se desbloquea al comprarlas por 1a vez
    public void ChangeBombAmount(int value)
    {
        nBombs += value;
        _hudManager.UpdateCurrentBombs(nBombs);
    }

    public void ChangeKeyAmount(int value)
    {
        nKeys += value;
        _hudManager.UpdateCurrentKeys(nKeys);
    }

    public void UnlockItem(int itemId)
    {
        itemsUnlocked[itemId] = true;
        if (itemId == 0)
            _hudManager.EquipItem(0, 0);
        if (itemId == 2)
            ChangeBombAmount(4);
    }

    //se equipa automáticamente en el botón B, porque lo único que se equipa al botón A es a la espada.
    public void ChangeItemEquiped(int itemId)
    {
        itemEquiped = itemId;
        if (itemId == 0) return;
        _hudManager.EquipItem(1, itemId);
    }
}
