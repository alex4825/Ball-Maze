using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 50;

    private float _verticalInput;
    private float _horizontalInput;

    private void Update()
    {
        ProcessRotation();
    }
    public void ToggleMovement(bool isToggleOn)
    {
        enabled = isToggleOn;
    }

    private void ProcessRotation()
    {
        _verticalInput = Input.GetAxisRaw("Vertical");
        _horizontalInput = Input.GetAxisRaw("Horizontal");

        transform.Rotate(transform.forward, -_verticalInput * _rotationSpeed * Time.deltaTime);
        transform.Rotate(transform.right, -_horizontalInput * _rotationSpeed * Time.deltaTime);
    }
}
