using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Mover _moverComponent;
    private Jumper _jumperComponent;
    private Wallet _walletComponent;

    public Wallet Wallet => _walletComponent;

    private void Awake()
    {
        _moverComponent = GetComponent<Mover>();
        _jumperComponent = GetComponent<Jumper>();
        _walletComponent = GetComponent<Wallet>();
    }

    public void ToggleMovement(bool isToggleOn)
    {
        _moverComponent.enabled = isToggleOn;
        _jumperComponent.enabled = isToggleOn;
    }
}
