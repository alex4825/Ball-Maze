using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;

    private bool _isJumpKeyPressed;
    private bool _isCanJump = true;
    private bool _isCanMove = false;
    private float _verticalInput;
    private float _horizontalInput;
    private Rigidbody _ballRigidbody;
    private Vector3 _forceDirection;

    public int CollectedCoins { get; private set; }

    private void Awake()
    {
        _ballRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessJumpInput();

        ProcessMovementInput();
    }

    private void ProcessMovementInput()
    {
        _verticalInput = Input.GetAxisRaw("Vertical");
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        Vector3 moveDirectionNormalized = new Vector3(_horizontalInput, 0, _verticalInput).normalized;
        _isCanMove = moveDirectionNormalized.magnitude > 0;

        if (_isCanMove)
        {
            Vector3 cameraRightAxis = Camera.main.transform.right;
            Vector3 cameraForwardFlat = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up).normalized;

            Vector3 forceHorizontalDirection = cameraRightAxis * _horizontalInput;
            Vector3 forceVerticalDirection = cameraForwardFlat * _verticalInput;
            _forceDirection = (forceHorizontalDirection + forceVerticalDirection).normalized;
        }
    }

    private void ProcessJumpInput()
    {
        if (Input.GetKeyDown(_jumpKey))
        {
            _isJumpKeyPressed = true;
        }
        else if (Input.GetKeyUp(_jumpKey))
        {
            _isJumpKeyPressed = false;
        }
    }

    private void FixedUpdate()
    {
        if (_isJumpKeyPressed && _isCanJump)
        {
            _ballRigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumpKeyPressed = false;
        }

        if (_isCanMove)
            _ballRigidbody.AddForce(_forceDirection * _moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (IsMazeCollision(collision))
            _isCanJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (IsMazeCollision(collision))
            _isCanJump = false;
    }

    private bool IsMazeCollision(Collision collision)
    => collision.gameObject.GetComponent<Maze>() != null;

    private void OnTriggerEnter(Collider other)
    {
        CollectedCoins++;
        other.gameObject.SetActive(false);
    }
}
