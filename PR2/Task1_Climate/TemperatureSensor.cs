using System;

public class TemperatureSensor
{
    public event Action<double>? TemperatureChanged;

    public void SetTemperature(double temp)
    {
        Console.WriteLine($"\nTemperature changed to: {temp}");
        TemperatureChanged?.Invoke(temp);
    }
}