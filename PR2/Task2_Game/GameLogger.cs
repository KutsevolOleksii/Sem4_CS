using System;

public class GameLogger
{
    public void OnDamaged(int hp)
    {
        Console.WriteLine($"Log: current HP = {hp}");
    }
}