using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Maze _maze;
    [SerializeField] private bool _isMazeCanMove;
    [SerializeField] private float _initialTimer = 30f;
    [SerializeField] private int _coinsTargetCount = 10;

    private float _timer;
    private bool _isPlay;

    public float Timer => _timer > 0 ? _timer : 0;

    private void Awake()
    {
        _timer = _initialTimer;
        _isPlay = true;
    }

    private void Update()
    {
        _ball.IsMovementAllowed = _isMazeCanMove == false;
        _maze.IsRotationAllowed = _isMazeCanMove;

        if (_isPlay)
        {
            _timer -= Time.deltaTime;

            PrintCoinsAndTimerToConsole();

            if (_timer <= 0 || _ball.CollectedCoins == _coinsTargetCount)
            {
                _isPlay = false;
                DetermineVictory();
            }
        }
    }

    private void PrintCoinsAndTimerToConsole()
    {
        Debug.Log($"������� �������: {_ball.CollectedCoins}. ������� ��������: {Timer:00.00}.");
    }

    private void DetermineVictory()
    {
        if (_ball.CollectedCoins == _coinsTargetCount)
        {
            Debug.Log("�� ��������!");
        }
        else
        {
            Debug.Log("�� ��������.");
        }
    }
}
