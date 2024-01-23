using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class LinkMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float _speed = 1.0f;
    [SerializeField]
    private InputActionReference _Input;
    Vector2 actualspeed = Vector2.zero;
    Vector2 targetspeed = Vector2.zero;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {

        Vector2 _vectormovimiento = GetInput();

        if (_vectormovimiento != Vector2.zero)
        {
            actualspeed = rb.velocity;
            targetspeed = _speed * _vectormovimiento;
        }
        else
        {
            actualspeed = Vector2.zero;
            targetspeed = Vector2.zero;
        }


        Vector3 finalspeed = (targetspeed - actualspeed);
        finalspeed.z = 0;
        Debug.Log(finalspeed);
        //   rb.AddForce(finalspeed * rb.mass / Time.fixedDeltaTime);
        transform.position += finalspeed * Time.deltaTime;
    }
    private void OnEnable()
    {
        _Input.action.Enable();
    }
    private void OnDisable()
    {
        _Input.action.Disable();

    }
    public Vector2 GetInput()
    {
        return _Input.action.ReadValue<Vector2>();
    }
}
