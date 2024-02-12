using System;
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


    private Animator _animator;

    private Transform _mytransform;

    private Transform _linkTransform;

    GameObject _link;

    private bool _moving = false;

    private void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _audioManager = FindObjectOfType<AudioManager>();
        _mytransform = transform;

    }

    void OnTriggerEnter2D(Collider2D linkCollider)
    {
        _link = linkCollider.gameObject;

        LinkController _controller = _link.GetComponent<LinkController>();

        _controller.SaveCave(this);

        if (_controller!=null)
        {
            _controller.SetBlockMovement(true);
            _linkTransform = _link.transform;
            _linkTransform.position = _mytransform.position;

            _moving = true;

            _animator = _link.GetComponent<Animator>();

            _animator.SetBool("CaveEnter", true);

            if (_movingToCave)
            {
                _gameManager.linkOnCave = true;
                _audioManager.PlayOrStopMusic(false);
            }

        }
    }
    /*
    private void OnTriggerExit2D()
    {
        //_camera.GetComponent<CameraController>().enabled = false;

        LinkController _controller = _link.GetComponent<LinkController>();
        if (_controller != null)
        {
            _controller.SetBlockMovement(false);

            _moving = false;

            _link.transform.position = _newLinkPosition;
            _camera.transform.position = (Vector3)_newCameraPosition + 10 * Vector3.back;
            if (_movingToCave)
            {
                _gameManager.linkOnCave = true;
                _audioManager.PlayOrStopMusic(false);
            }
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
    */

    public void MoveDown()
    {
        _linkTransform.position = new Vector3 (_linkTransform.position.x, _linkTransform.position.y -0.02f, _linkTransform.position.z);
    }

    private void Update()
    {
        if (_moving) MoveDown();
    }

    public void TpNow()
    {
        _moving = false;

        LinkController _controller = _link.GetComponent<LinkController>();
        if (_controller != null)
        {
            _controller.SetBlockMovement(false);

            _link.transform.position = _newLinkPosition;
            _camera.transform.position = (Vector3)_newCameraPosition + 10 * Vector3.back;



            if (_caveObject != null)
            {
                _caveObject.GetComponent<TalkComponent>().Reset(_textToWrite);
            }

        }
        StartCoroutine(TpDelayedStart());
    }


    private IEnumerator TpDelayedStart()
    {
        LinkController _controller = _link.GetComponent<LinkController>();
        if (_controller != null)
        { 
            yield return new WaitForSeconds(1f);


            if (!_movingToCave)
            {
                _gameManager.linkOnCave = false;
                _audioManager.PlayOrStopMusic(true);
            }



            //_camera.GetComponent<CameraController>().enabled = !_movingToCave;
        }
    }
}
