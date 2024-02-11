using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

public class ParabolaTektiteIA : MonoBehaviour
{
   
    public bool activity;
    [Serialize]
    private TektiteAnimator _animator;
 
    private CharacterMovement _chMovement;
    private Transform _myTransform;
    private Vector3 _targetPoint;
    private Vector2 _direction;
   
    [SerializeField] int _timeBetweenJumps = 4000;
    private Stopwatch _sw = new Stopwatch();

    private float _timer;
    [SerializeField]
    private float _jumpDuration = 1f;
    private float _jumpYOffset = 2f;
    private Vector2 _currentDisplacementVector;
    private Vector3 _initialPosition;
    [SerializeField]
    private float _maxXMovement = 3;
    [SerializeField]
    private float _maxYMovement = 1.5f;

    bool _hasArrived = false;

    bool _onScreen =true;

    //Calculates new target position and the direction
    void NewTargetPosition()
    {
        _hasArrived = false;
        
        _timer = Time.time;
        _sw.Restart();
        _sw.Stop();
        //Target Point
        float _xTargetPos = 0;
        _xTargetPos = _myTransform.position.x + Random.Range(-_maxXMovement, _maxXMovement + 1);

        float _yTargetPos = _myTransform.position.y + Random.Range(-_maxYMovement, _maxYMovement + 1);
        _targetPoint = new Vector3(_xTargetPos, _yTargetPos, 0);

        //UnityEngine.Debug.Log(_targetPoint);

        _initialPosition = _myTransform.position;
        _currentDisplacementVector = new Vector2 (_targetPoint.x - _myTransform.position.x, _targetPoint.y - _myTransform.position.y);
        //_chMovement.SetCharacterVelocity(_currentDisplacementVector.normalized);
    }

    public void StartMoving()
    {
        _onScreen = true;
    }
    public void StopMoving()
    {
        _onScreen = false;
    }
    // Start is called before the first frame update
    void Start()
    {
       
        _chMovement = GetComponent<CharacterMovement>();
        _myTransform = transform;
        NewTargetPosition();
    _animator=GetComponent<TektiteAnimator>();
    }

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Active(bool state)
    {
        activity = state;
        gameObject.SetActive(state);
    }




    // Update is called once per frame
    void Update()
    {
        float currentOffset;
        if ((_targetPoint - _myTransform.position).magnitude > 0.01f && _onScreen)
        {
            currentOffset = Mathf.Lerp(0, _jumpYOffset, - Mathf.Pow(2*((Time.time - _timer)/_jumpDuration) - 1,2)+1);
            _myTransform.position = Vector3.up * currentOffset + Vector3.Lerp(_initialPosition, _targetPoint, (Time.time - _timer)/_jumpDuration);
         
        }
        else if(!_hasArrived)
        {
            //_chMovement.SetCharacterVelocity(Vector2.zero);
            _sw.Restart();
            _hasArrived = true;
          
        }
        _animator.Jump(_hasArrived);

        if (_sw.ElapsedMilliseconds >= _timeBetweenJumps)
        {
           
            NewTargetPosition();
            
        }
          
    }
}
