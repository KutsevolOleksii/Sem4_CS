using System;

public class AchievementSystem
{
    public void OnDamaged(int hp)
    {
        if (hp <= 50)
            Console.WriteLine("Achievement: Half Health");

        if (hp <= 0)
            Console.WriteLine("Achievement: First Death");
    }
}