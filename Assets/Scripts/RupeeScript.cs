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

    private AudioManager _audioManager;
    [SerializeField] private AudioClip _getRupeeAudio;
    #endregion
    #region Methods
    
    private void Start() {
        _inventoryManager = FindObjectOfType<InventoryManager>();
        _audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D linkCollider)
    {
        if (linkCollider.gameObject.GetComponent<LinkController>() != null)
        {
            _inventoryManager.ChangeRupeeAmount(_value);
            _audioManager.PlaySoundEffect(_getRupeeAudio);
            Destroy(this.gameObject);
            
        }
    }
    #endregion
}
