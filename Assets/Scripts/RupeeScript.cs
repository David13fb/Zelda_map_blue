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
    [SerializeField]
    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D linkCollider)
    {
        if (linkCollider.gameObject.GetComponent<LinkController>() != null)
        {
            Debug.Log("a");
            InventoryManager.Instance.ChangeRupeeAmount(_value);
            //no sería mejor eliminarlas??
            Destroy(this.gameObject);
            
        }
    }
    #endregion
}
