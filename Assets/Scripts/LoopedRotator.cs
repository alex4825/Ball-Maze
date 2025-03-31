using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopedRotator : MonoBehaviour
{
    [SerializeField] private float _rotationSpeed = 100;

    private void Update()
    {
        transform.Rotate(Vector3.up, _rotationSpeed *  Time.deltaTime);
    }
}
