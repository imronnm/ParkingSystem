namespace ConsoleApp1;
public class Vehicle
{
    public Vehicle(string registrationNumber, string color, string type)
    {
        RegistrationNumber = registrationNumber;
        Color = color;
        Type = type;
    }

    public int SlotNumber { get; set; }
    public string RegistrationNumber { get; }
    public string Color { get; }
    public string Type { get; }
}
