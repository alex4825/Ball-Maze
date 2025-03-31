using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 5;

    private bool _isCanMove = false;
    private Vector3 _forceDirection;
    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessMoveInput();
    }

    private void FixedUpdate()
    {
        if (_isCanMove)
            _rigidbody.AddForce(_forceDirection * _moveSpeed);
    }

    private void ProcessMoveInput()
    {
        float verticalInput = Input.GetAxisRaw("Vertical");
        float horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector3 moveDirectionNormalized = new Vector3(horizontalInput, 0, verticalInput).normalized;
        _isCanMove = moveDirectionNormalized.magnitude > 0;

        if (_isCanMove)
        {
            Vector3 cameraRightAxis = Camera.main.transform.right;
            Vector3 cameraForwardFlat = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;

            Vector3 forceHorizontalDirection = cameraRightAxis * horizontalInput;
            Vector3 forceVerticalDirection = cameraForwardFlat * verticalInput;
            _forceDirection = (forceHorizontalDirection + forceVerticalDirection).normalized;
        }
    }
}
