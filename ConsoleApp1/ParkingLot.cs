namespace ConsoleApp1;
using System.Collections.Generic;
using System.Linq;
public class ParkingLot
{
    private readonly int capacity;
    private readonly List<Vehicle> vehicles;

    public ParkingLot(int capacity)
    {
        this.capacity = capacity;
        vehicles = new List<Vehicle>(capacity);
    }

    public int ParkVehicle(Vehicle vehicle)
    {
        if (vehicles.Count >= capacity)
        {
            return -1; // Parking lot is full
        }

        int slotNumber = FindNextAvailableSlot();

        if (slotNumber == -1)
        {
            return -1; // All slots are occupied
        }

        vehicle.SlotNumber = slotNumber;
        vehicles.Add(vehicle);
        return slotNumber;
    }

    private int FindNextAvailableSlot()
    {
        for (int i = 1; i <= capacity; i++)
        {
            bool slotOccupied = vehicles.Any(v => v.SlotNumber == i);
            if (!slotOccupied)
            {
                return i;
            }
        }

        return -1; // All slots are occupied
    }

    public void Leave(int slotNumber)
    {
        Vehicle vehicle = vehicles.FirstOrDefault(v => v.SlotNumber == slotNumber);
        if (vehicle != null)
        {
            vehicles.Remove(vehicle);
        }
    }

    public void PrintStatus()
    {
        Console.WriteLine("Slot\tNo.\tType\tRegistration No\tColour");
        foreach (Vehicle vehicle in vehicles)
        {
            Console.WriteLine($"{vehicle.SlotNumber}\t{vehicle.RegistrationNumber}\t{vehicle.Type}\t{vehicle.Color}");
        }
    }

    public int GetVehicleCountByType(string vehicleType)
    {
        return vehicles.Count(v => v.Type.Equals(vehicleType, StringComparison.OrdinalIgnoreCase));
    }

    public string GetRegistrationNumbersByOddPlate()
    {
        var oddPlateNumbers = vehicles
            .Where(v => IsPlateTypeOdd(v.RegistrationNumber))
            .Select(v => v.RegistrationNumber);
        return string.Join(", ", oddPlateNumbers);
    }

    public string GetRegistrationNumbersByEvenPlate()
    {
        var evenPlateNumbers = vehicles
            .Where(v => !IsPlateTypeOdd(v.RegistrationNumber))
            .Select(v => v.RegistrationNumber);
        return string.Join(", ", evenPlateNumbers);
    }


    public string GetRegistrationNumbersByColor(string color)
    {
        var filteredVehicles = vehicles
            .Where(v => v.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
            .Select(v => v.RegistrationNumber);
        return string.Join(", ", filteredVehicles);
    }

    public string GetSlotNumbersByColor(string color)
    {
        var filteredSlots = vehicles
            .Where(v => v.Color.Equals(color, StringComparison.OrdinalIgnoreCase))
            .Select(v => v.SlotNumber.ToString());
        return string.Join(", ", filteredSlots);
    }

    public int GetSlotNumberByRegistrationNumber(string regNumber)
    {
        Vehicle vehicle = vehicles.FirstOrDefault(v => v.RegistrationNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase));
        return vehicle?.SlotNumber ?? -1;
    }

    private static bool IsPlateTypeOdd(string registrationNumber)
    {
        char lastDigit = registrationNumber.LastOrDefault();
        // Menggunakan karakter terakhir sebagai karakter saja
        // dan memeriksa apakah itu digit ganjil atau tidak.
        return lastDigit == '1' || lastDigit == '3' || lastDigit == '5' || lastDigit == '7' || lastDigit == '9';
    }



}