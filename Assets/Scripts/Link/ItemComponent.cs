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
    }

    void OnTriggerEnter2D(Collider2D linkCollider)
    {
     
        if (linkCollider.gameObject.GetComponent<LinkController>() != null)
        {
           
            if (InventoryManager.Instance.nRupees < _itemPrice) return;
            InventoryManager.Instance.ChangeRupeeAmount(-_itemPrice);
            if (_itemId < 4) 
            {
                _link.ItemPicked(1);
                InventoryManager.Instance.UnlockItem(_itemId);
                InventoryManager.Instance.ChangeItemEquiped(_itemId);
            }
            else
            {
                HP_manager linkHp = _link.gameObject.GetComponent<HP_manager>();
                linkHp.changeMaxHealth(_maxHealthIncrease);
                linkHp.changeCurrentHealth(_healthRecovered);
                Destroy(_objectToDestroyOnPickUp);
            }
            

            AudioManager.Instance.PlaySoundEffect(_getItemSoundEffect);

            Destroy(gameObject);
        }
    }
}
