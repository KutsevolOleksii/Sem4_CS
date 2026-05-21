using System;

public class Player
{
    public int HP { get; private set; }

    public event Action<int>? Damaged;

    public Player(int hp)
    {
        HP = hp;
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        Console.WriteLine($"\nPlayer took {damage} damage");
        Damaged?.Invoke(HP);
    }
}