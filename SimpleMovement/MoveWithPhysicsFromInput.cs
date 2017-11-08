using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithPhysicsFromInput : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private float _horizontal;
    private float _vertical;

    public float Speed = 5;
    public float RotationSpeed = 2f;

    // Use this for initialization
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();

    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody.velocity = transform.TransformDirection(((Vector3.forward * _vertical) + (Vector3.right * _horizontal)) * Speed);

        //Let's get a left-right means rotation movement.
        var euler = transform.localEulerAngles;
        euler.y += _horizontal * RotationSpeed;

        _rigidbody.rotation = Quaternion.Euler(euler);
    }
}
