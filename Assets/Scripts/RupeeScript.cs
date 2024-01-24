using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RupeeScript : MonoBehaviour
{
    #region parameters
    /// <summary>
    /// Entero que almacenara el total de rupias
    /// </summary>
    [SerializeField]
    private int _value;
    #endregion
    #region references
    InventoryManager _inventory;
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D linkCollider)
    {
        LinkMovement Link = linkCollider.gameObject.GetComponent<LinkMovement>();
        if (Link != null)
        {
            _inventory.GetRupee(_value);
            gameObject.SetActive(false);
        }
    }
    private void Start()
    {
       _inventory = FindObjectOfType<InventoryManager>();
    }
    #endregion
}
