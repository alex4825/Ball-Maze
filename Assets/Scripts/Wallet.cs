using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int CoinsCount { get; private set; }

    public int Cash { get; private set; } = 0;

    public void Add(Coin coin)
    {
        CoinsCount++;
        Cash += coin.Cost;
    }
}
