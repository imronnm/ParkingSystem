using ConsoleApp1;
public class Program
{
    public static void Main(string[] args)
    {
        ParkingLot parkingLot = null;
        Console.WriteLine("Welcome to the Parking Lot Program. Please enter your commands.");

        while (true)
        {
            Console.Write("$ ");
            string input = Console.ReadLine();
            string[] command = input.Split(' ');

            if (command.Length == 0)
            {
                Console.WriteLine("Invalid command");
                continue;
            }

            string action = command[0].ToLower();

            switch (action)
            {
                case "create_parking_lot":
                    if (command.Length >= 2)
                    {
                        int capacity;
                        if (int.TryParse(command[1], out capacity))
                        {
                            parkingLot = new ParkingLot(capacity);
                            Console.WriteLine($"Created a parking lot with {capacity} slots");
                        }
                        else
                        {
                            Console.WriteLine("Invalid capacity value");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Usage: create_parking_lot <capacity>");
                    }
                    break;

                case "park":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                        break;
                    }

                    if (command.Length >= 4)
                    {
                        string regNumber = command[1];
                        string color = command[2];
                        string vehicleType = command[3];

                        Vehicle vehicle = new Vehicle(regNumber, color, vehicleType);

                        int slotNumber = parkingLot.ParkVehicle(vehicle);
                        if (slotNumber != -1)
                        {
                            Console.WriteLine($"Allocated slot number: {slotNumber}");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, parking lot is full");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Usage: park <registration_number> <color> <vehicle_type>");
                    }
                    break;

                case "leave":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                        break;
                    }

                    if (command.Length >= 2)
                    {
                        int slotNumber;
                        if (int.TryParse(command[1], out slotNumber))
                        {
                            parkingLot.Leave(slotNumber);
                            Console.WriteLine($"Slot number {slotNumber} is free");
                        }
                        else
                        {
                            Console.WriteLine("Invalid slot number");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Usage: leave <slot_number>");
                    }
                    break;

                case "status":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                    }
                    else
                    {
                        parkingLot.PrintStatus();
                    }
                    break;

                case "type_of_vehicles":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                    }
                    else if (command.Length >= 2)
                    {
                        string vehicleType = command[1];
                        int count = parkingLot.GetVehicleCountByType(vehicleType);
                        Console.WriteLine(count);
                    }
                    else
                    {
                        Console.WriteLine("Usage: type_of_vehicles <vehicle_type>");
                    }
                    break;

                case "registration_numbers_for_vehicles_with_ood_plate":
                    string oddPlateNumbers = parkingLot.GetRegistrationNumbersByOddPlate();
                    Console.WriteLine(oddPlateNumbers);
                    break;

                case "registration_numbers_for_vehicles_with_event_plate":
                    string evenPlateNumbers = parkingLot.GetRegistrationNumbersByEvenPlate();
                    Console.WriteLine(evenPlateNumbers);
                    break;


                
                case "registration_numbers_for_vehicles_with_colour_putih":
                    string putihColorNumbers = parkingLot.GetRegistrationNumbersByColor("Putih");
                    Console.WriteLine(putihColorNumbers);
                    break;

                case "slot_numbers_for_vehicles_with_colour_putih":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                    }
                    else if (command.Length >= 2)
                    {
                        string color = command[1];
                        string result = parkingLot.GetSlotNumbersByColor(color);
                        Console.WriteLine(result);
                    }
                    else
                    {
                        Console.WriteLine("Usage: slot_numbers_for_vehicles_with_colour <color>");
                    }
                    break;

                case "slot_number_for_registration_number":
                    if (parkingLot == null)
                    {
                        Console.WriteLine("Please create a parking lot first.");
                    }
                    else if (command.Length >= 2)
                    {
                        string regNumber = command[1];
                        int slotNumber = parkingLot.GetSlotNumberByRegistrationNumber(regNumber);
                        if (slotNumber != -1)
                        {
                            Console.WriteLine(slotNumber);
                        }
                        else
                        {
                            Console.WriteLine("Not found");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Usage: slot_number_for_registration_number <registration_number>");
                    }
                    break;

                case "exit":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid command");
                    break;
            }
        }
    }
}
