using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    [SerializeField]
    private int _itemId;
    [SerializeField]
    private int _itemPrice;

    [SerializeField]
    private int _healthRecovered = 0;
    [SerializeField]
    private int _maxHealthIncrease = 0;
    [SerializeField] private AudioClip _getItemSoundEffect;
    [SerializeField]
    private GameObject _objectToDestroyOnPickUp;

    private LinkAnimatorComponent _link;
    private InventoryManager _inventoryManager;
    private AudioManager _audioManager;
    /*
     * [SerializeField]
    private Sprite _itemImage;
    

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _itemImage;
    }
    */
    private void Start()
    {
        _link = FindAnyObjectByType<LinkAnimatorComponent>();
        _inventoryManager = FindAnyObjectByType<InventoryManager>();
        _audioManager = FindAnyObjectByType<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D linkCollider)
    {
     
        if (linkCollider.gameObject.GetComponent<LinkController>() != null)
        {
           
            if (_inventoryManager.nRupees < _itemPrice) return;
            _inventoryManager.ChangeRupeeAmount(-_itemPrice);
            if (_itemId < 4) 
            {
                _link.ItemPicked(1);
                _inventoryManager.UnlockItem(_itemId);
                _inventoryManager.ChangeItemEquiped(_itemId);
            }
            else
            {
                HP_manager linkHp = _link.gameObject.GetComponent<HP_manager>();
                linkHp.changeMaxHealth(_maxHealthIncrease);
                linkHp.changeCurrentHealth(_healthRecovered);
                Destroy(_objectToDestroyOnPickUp);
            }
            

            _audioManager.PlaySoundEffect(_getItemSoundEffect);

            Destroy(gameObject);
        }
    }
}
