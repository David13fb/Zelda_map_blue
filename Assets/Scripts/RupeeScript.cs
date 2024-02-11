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
    private InventoryManager _inventoryManager;
    #endregion
    #region Methods
    
    private void Start() {
        _inventoryManager = FindObjectOfType<InventoryManager>();
    }
    private void OnTriggerEnter2D(Collider2D linkCollider)
    {
        if (linkCollider.gameObject.GetComponent<LinkController>() != null)
        {
            _inventoryManager.ChangeRupeeAmount(_value);
            //no ser�a mejor eliminarlas??
            Destroy(this.gameObject);
            
        }
    }
    #endregion
}
