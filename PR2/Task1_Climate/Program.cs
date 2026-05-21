using System;

class Program
{
    static void Main()
    {
        var sensor = new TemperatureSensor();

        var display = new Display();
        var ac = new AirConditioner();
        var security = new SecuritySystem();

        sensor.TemperatureChanged += display.OnTemperatureChanged;
        sensor.TemperatureChanged += ac.OnTemperatureChanged;
        sensor.TemperatureChanged += security.OnTemperatureChanged;

        sensor.SetTemperature(10);
        sensor.SetTemperature(20);
        sensor.SetTemperature(30);
        sensor.SetTemperature(45);
        sensor.SetTemperature(2);
    }
}