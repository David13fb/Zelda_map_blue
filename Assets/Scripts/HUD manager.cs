using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDmanager : MonoBehaviour
{
    [SerializeField]
    private Image[] _hearts;
    [SerializeField]
    private Sprite _fullHeart;
    [SerializeField]
    private Sprite _halfHeart;
    [SerializeField]
    private Sprite _emptyHeart;


    private int _numberOfHeartsEnabled;

    public void UpdateHPmaxHP(int newMaxHp)
    {
        
        _numberOfHeartsEnabled = (newMaxHp / 2 + newMaxHp % 2);
        Debug.Log(_numberOfHeartsEnabled);
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
        Debug.Log("current");
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
}
