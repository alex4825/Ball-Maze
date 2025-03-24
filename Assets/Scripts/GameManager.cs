using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private float _initialTimer = 30f;
    [SerializeField] private int _coinsTargetCount = 10;

    private float _timer;
    private bool _isPlay;
    private bool _isWin;
    private bool _isLoose;

    public float Timer => _timer > 0 ? _timer : 0;

    private void Awake()
    {
        _timer = _initialTimer;
        _isPlay = true;
    }

    private void Update()
    {
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
        Debug.Log($"Монеток собрано: {_ball.CollectedCoins}. Времени осталось: {Timer:00.00}.");
    }

    private void DetermineVictory()
    {
        if (_ball.CollectedCoins == _coinsTargetCount)
        {
            Debug.Log("Вы победили!");
            _isWin = true;
        }
        else
        {
            Debug.Log("Вы програли.");
            _isLoose = true;
        }
    }
}
