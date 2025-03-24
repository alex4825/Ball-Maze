using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 50;

    private float _verticalInput;
    private float _horizontalInput;
    public bool IsRotationAllowed { get; set; }

    private void Update()
    {
        if (IsRotationAllowed)
        {
            ProcessRotation();
        }
    }

    private void ProcessRotation()
    {
        _verticalInput = Input.GetAxisRaw("Vertical");
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        transform.Rotate(transform.forward, -_verticalInput * _rotationSpeed * Time.deltaTime);
        transform.Rotate(transform.right, -_horizontalInput * _rotationSpeed * Time.deltaTime);
    }
}
