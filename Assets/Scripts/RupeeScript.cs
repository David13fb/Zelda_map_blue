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
        //reemplazar por un componente que solo tenga link
        LinkController Link = linkCollider.gameObject.GetComponent<LinkController>();
        if (Link != null)
        {
            _inventory.ChangeRupeeAmount(_value);
            //no sería mejor eliminarlas??
            gameObject.SetActive(false);
        }
    }
    private void Start()
    {
       _inventory = FindObjectOfType<InventoryManager>();
    }
    #endregion
}
