using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalkComponent : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textRef;
    private string text = "";

    private int letterShown = 120;

    private float _timer;
    [SerializeField]
    private float _letterDuration;

    [SerializeField]
    private AudioClip _letterSoundEffect;

    public void ChangeText(string newText)
    {
        text = newText;
    }

    public void Reset(string text)
    {
        _textRef.text = "";
        letterShown = -1;
        _timer = Time.time;
        ChangeText(text);
    }

    void Update()
    {
        if (letterShown < text.Length-1)
        {
            if (Time.time - _timer >= _letterDuration)
            {
                letterShown++;
                if (text[letterShown] == ' ')
                {
                    _textRef.text += ' ';

                    letterShown++;
                }

                _textRef.text += text[letterShown];

                if(GameManager.instance.linkOnCave) AudioManager.Instance.PlaySoundEffect(_letterSoundEffect);

                _timer = Time.time;
            }
        }

    }

}
