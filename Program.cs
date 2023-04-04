using System.ComponentModel.DataAnnotations;
using static _03._Need_for_Speed_III.Program;

namespace _03._Need_for_Speed_III
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputCar = Console.ReadLine().Split("|");
                string carName = inputCar[0];
                int mileage = int.Parse(inputCar[1]);
                int fuel = int.Parse(inputCar[2]);

                Car heroCreat = new Car { Mileage = mileage, Fuel = fuel };

                cars.Add(carName, heroCreat);
            }

            string input;

            while ((input = Console.ReadLine()) != "Stop")
            {
                string[] cmd = input.Split(" : ");
                string command = cmd[0];

                if (command == "Drive")
                {
                    string carToDrive = cmd[1];
                    int distance = int.Parse(cmd[2]);
                    int fuel = int.Parse(cmd[3]);

                    if (cars[carToDrive].Fuel >= fuel)
                    {
                        cars[carToDrive].Fuel -= fuel;
                        cars[carToDrive].Mileage += distance;

                        Console.WriteLine($"{carToDrive} driven for {distance} kilometers. {fuel} liters of fuel consumed.");

                        if (cars[carToDrive].Mileage >= 100_000)
                        {
                            cars.Remove(carToDrive);
                            Console.WriteLine($"Time to sell the {carToDrive}!");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Not enough fuel to make that ride");
                    }
                }
                else if (command == "Refuel")
                {
                    string carForRefuel = cmd[1];
                    int fuel = int.Parse(cmd[2]);

                    int tempFuel = cars[carForRefuel].Fuel + fuel;

                    if (tempFuel >= 75)
                    {
                        Console.WriteLine($"{carForRefuel} refueled with {75 - cars[carForRefuel].Fuel} liters");
                        cars[carForRefuel].Fuel = 75;
                        
                    }
                    else
                    {
                        cars[carForRefuel].Fuel = tempFuel;
                        Console.WriteLine($"{carForRefuel} refueled with {fuel} liters");
                    }
                }
                else if (command == "Revert")
                {
                    string carForRevert = cmd[1];
                    int kilometrs = int.Parse(cmd[2]);

                    if (cars[carForRevert].Mileage - kilometrs < 10_000)
                    {
                        cars[carForRevert].Mileage = 10_000;
                    }
                    else
                    {
                        cars[carForRevert].Mileage -= kilometrs;
                        Console.WriteLine($"{carForRevert} mileage decreased by {kilometrs} kilometers");
                    }
                }
            }

            foreach ( var car in cars )
            {
                Console.WriteLine($"{car.Key} -> Mileage: {car.Value.Mileage} kms, Fuel in the tank: {car.Value.Fuel} lt.");
            }
        }

        public class Car
        {
            public int Mileage { get; set; }
            public int Fuel { get; set; }
        }

    }
}