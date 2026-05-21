using System;

public class SecuritySystem
{
    public void OnTemperatureChanged(double temp)
    {
        if (temp > 40)
            Console.WriteLine("Overheat!");
        if (temp < 5)
            Console.WriteLine("Freezing risk!");
    }
}