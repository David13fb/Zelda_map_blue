using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField]
    private int _nRupees = 0;

    public void GetRupee(int value)
    {
        _nRupees += value;
    }
}
