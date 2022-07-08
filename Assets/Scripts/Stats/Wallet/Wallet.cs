using System;

public class Wallet
{
    public int CoinsAmount { get; private set; }

    public Wallet(int amount)
        => CoinsAmount = amount;

    public void AddCoins(int value)
    {
        if (value <= 0)
            throw new InvalidOperationException();

        CoinsAmount += value;
    }

    public void SpendCoins(int value)
    {
        if (value > CoinsAmount)
            throw new InvalidOperationException();

        CoinsAmount -= value;
    }
}
