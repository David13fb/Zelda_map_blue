using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemComponent : MonoBehaviour
{
    [SerializeField]
    private int _itemId;
    [SerializeField]
    private int _itemPrice;
    /*
     * [SerializeField]
    private Sprite _itemImage;
    

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _itemImage;
    }
    */


    void OnTriggerEnter2D(Collider2D linkCollider)
    {
        if (linkCollider.gameObject.GetComponent<LinkController>() != null)
        {
            if (InventoryManager.Instance.nRupees < _itemPrice) return;
            InventoryManager.Instance.ChangeRupeeAmount(-_itemPrice);

            InventoryManager.Instance.UnlockItem(_itemId);
            InventoryManager.Instance.ChangeItemEquiped(_itemId);

            Destroy(gameObject);
        }
    }
}
