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
    private GameObject _item;
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
            _link.ItemPicked(1);
            InventoryManager.Instance.UnlockItem(_itemId);
            InventoryManager.Instance.ChangeItemEquiped(_itemId);

            //para la collision con el corazon seria el 2
          //  GameManager.instance.PickItem(1);
            Destroy(gameObject);
        }
    }
}
