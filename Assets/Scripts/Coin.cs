using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _maxCost = 5;
    [SerializeField] private int _minCost = 1;

    public int Cost => Random.Range(_minCost, _maxCost + 1);
}
