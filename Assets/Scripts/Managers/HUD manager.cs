using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HUDmanager : MonoBehaviour
{
    //minimap
    [SerializeField]
    private RectTransform _greenblock;



    //--Health Meter----------
    [SerializeField]
    private Image[] _hearts;
    [SerializeField]
    private Sprite _fullHeart;
    [SerializeField]
    private Sprite _halfHeart;
    [SerializeField]
    private Sprite _emptyHeart;

    private int _numberOfHeartsEnabled;
    //------------------------

    //--ResouceCount----------
    [SerializeField]
    private TextMeshProUGUI _ruppeText;
    [SerializeField]
    private TextMeshProUGUI _keyText;
    [SerializeField]
    private TextMeshProUGUI _bombText;
    //------------------------

    //--ItemEquiped-----------
    [SerializeField]
    private Image[] _itemSlots = new Image[2];
    //sprites de los items en el orden de su Id.
    //el 5 es el color del fondo
    [SerializeField]
    private Sprite[] _itemSprites = new Sprite[5];

    public void EquipItem(int itemSlot, int newItemId)
    {
        _itemSlots[itemSlot].sprite = _itemSprites[newItemId];
        
    }

    public void UpdateHPmaxHP(int newMaxHp)
    {
        
        _numberOfHeartsEnabled = (newMaxHp / 2 + newMaxHp % 2);
        for (int i = 0; i < _hearts.Length; i++)
        {
            if(i < _numberOfHeartsEnabled)
            {
                _hearts[i].enabled = true;
            }
            else
            {
                _hearts[i].enabled = false;
            }
        }
    }

    public void UpdateCurrentHP(int currentHp)
    {
        for(int i = 0; i < _numberOfHeartsEnabled; i++)
        {
            if(i < currentHp / 2)
            {
                _hearts[i].sprite = _fullHeart;
            }else if(i-1 < currentHp/2 && currentHp%2 == 1)
            {
                _hearts[i].sprite = _halfHeart;
            }
            else
            {
                _hearts[i].sprite = _emptyHeart;
            }
        }
    }

    public void UpdateCurrentRupees(int newAmount)
    {
        _ruppeText.text = ("x" + newAmount);
    }
    public void UpdateCurrentKeys(int newAmount)
    {
        _keyText.text = ("x" + newAmount);
    }
    public void UpdateCurrentBombs(int newAmount)
    {
        _bombText.text = ("x" + newAmount);
    }

  
    public void UpdateMinimap(bool minimapa, Vector2 direction)
    {
        if (minimapa)
        {

            Vector2 newPosition = _greenblock.anchoredPosition + direction;
            _greenblock.anchoredPosition = newPosition;
        }

    }





}
