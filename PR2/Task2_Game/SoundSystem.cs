using System;

public class SoundSystem
{
    public void OnDamaged(int hp)
    {
        Console.WriteLine("Play damage sound");

        if (hp <= 20)
            Console.WriteLine("Play critical sound");
    }
}