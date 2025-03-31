using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private MazeRotator _mazeRotator;

    [SerializeField] private bool _isMazeCanMove;

    [SerializeField] private float _initialTimer = 30f;
    [SerializeField] private int _coinsTargetCount = 10;

    private float _timer;
    private bool _isPlay;
    private bool _isMazeCanMoveLastFrame;

    public float Timer => _timer > 0 ? _timer : 0;

    private void Awake()
    {
        _timer = _initialTimer;
        _isPlay = true;
        _isMazeCanMoveLastFrame = _isMazeCanMove;
    }

    private void Update()
    {
        if (_isMazeCanMoveLastFrame != _isMazeCanMove)
        {
            _ball.ToggleMovement(_isMazeCanMove == false);
            _mazeRotator.ToggleMovement(_isMazeCanMove);
        }

        if (_isPlay)
        {
            _timer -= Time.deltaTime;

            PrintCoinsAndTimerToConsole();

            if (_timer <= 0 || _ball.Wallet.CoinsCount == _coinsTargetCount)
            {
                _isPlay = false;
                DetermineVictory();
            }
        }

        _isMazeCanMoveLastFrame = _isMazeCanMove;
    }

    private void PrintCoinsAndTimerToConsole()
    {
        Debug.Log($"Монеток собрано: {_ball.Wallet.CoinsCount}. Времени осталось: {Timer:00.00}.");
    }

    private void DetermineVictory()
    {
        if (_ball.Wallet.CoinsCount == _coinsTargetCount)
        {
            Debug.Log("Вы победили!");
        }
        else
        {
            Debug.Log("Вы програли.");
        }
    }
}
