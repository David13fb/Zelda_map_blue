using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeletransportLinkOnTrigger : MonoBehaviour
{
    [SerializeField]
    private Vector2 _newLinkPosition;

    [SerializeField]
    private Vector2 _newCameraPosition;

    [SerializeField]
    private GameObject _camera;

    [SerializeField]
    private GameObject _caveObject;

    [SerializeField]
    private string _textToWrite;


    [SerializeField]
    private bool _movingToCave;

    private GameManager _gameManager;
    private AudioManager _audioManager;

    GameObject _link;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioManager = FindObjectOfType<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D linkCollider)
    {
        //_camera.GetComponent<CameraController>().enabled = false;

        _link = linkCollider.gameObject;
        if (_link.GetComponent<LinkController>() != null)
        {
            if (_movingToCave)
            {
                _gameManager.linkOnCave = true;
                _audioManager.PlayOrStopMusic(false);
            }

            _link.transform.position = _newLinkPosition;
            _camera.transform.position = (Vector3)_newCameraPosition + 10 * Vector3.back;

            if (_caveObject != null)
            {
                _caveObject.GetComponent<TalkComponent>().Reset(_textToWrite);
            }

            if (!_movingToCave)
            {
                _gameManager.linkOnCave = false;
                _audioManager.PlayOrStopMusic(true);
            }

            //_camera.GetComponent<CameraController>().enabled = !_movingToCave;
        }


    }
    private void TPLink()
    {
        //_camera.GetComponent<CameraController>().enabled = false;


        if (_link.GetComponent<LinkController>() != null)
        {
            if (_movingToCave)
            {
                _gameManager.linkOnCave = true;
                _audioManager.PlayOrStopMusic(false);
            }

            _link.transform.position = _newLinkPosition;
            _camera.transform.position = (Vector3)_newCameraPosition + 10 * Vector3.back;

            if (_caveObject != null)
            {
                _caveObject.GetComponent<TalkComponent>().Reset(_textToWrite);
            }

            if (!_movingToCave)
            {
                _gameManager.linkOnCave = false;
                _audioManager.PlayOrStopMusic(true);
            }

            //_camera.GetComponent<CameraController>().enabled = !_movingToCave;
        }
    }
}
