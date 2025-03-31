using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jumper : MonoBehaviour
{
    [SerializeField] private float _jumpForce = 5.5f;
    [SerializeField] private KeyCode _jumpKey = KeyCode.Space;

    private bool _isJumpKeyPressed;
    private Rigidbody _rigidbody;

    public bool IsCanJump { get; set; } = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ProcessJumpInput();
    }

    private void FixedUpdate()
    {
        if (_isJumpKeyPressed && IsCanJump)
        {
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _isJumpKeyPressed = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (IsMazeCollision(collision))
            IsCanJump = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (IsMazeCollision(collision))
            IsCanJump = false;
    }

    private bool IsMazeCollision(Collision collision)
    => collision.gameObject.GetComponent<MazeRotator>() != null;

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
    
}
