using System;

public class AirConditioner
{
    public void OnTemperatureChanged(double temp)
    {
        if (temp < 17)
            Console.WriteLine("Heating ON");
        else if (temp <= 25)
            Console.WriteLine("AC OFF");
        else
            Console.WriteLine("Cooling ON");
    }
}