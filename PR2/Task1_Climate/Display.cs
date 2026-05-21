using System;

public class Display
{
    public void OnTemperatureChanged(double temp)
    {
        Console.WriteLine($"Display: {temp}°C");
    }
}