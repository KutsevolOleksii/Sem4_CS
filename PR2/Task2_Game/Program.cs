using System;

class Program
{
    static void Main()
    {
        var player = new Player(100);

        var ui = new UIHealthBar();
        var sound = new SoundSystem();
        var achievements = new AchievementSystem();
        var logger = new GameLogger();

        player.Damaged += ui.OnDamaged;
        player.Damaged += sound.OnDamaged;
        player.Damaged += achievements.OnDamaged;
        player.Damaged += logger.OnDamaged;

        player.TakeDamage(20);
        player.TakeDamage(30);
        player.TakeDamage(40);
        player.TakeDamage(20);
    }
}