using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vehicles;

namespace ConsoleTests
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();

            var vehicles = new List<IFuelCosts>
            {
                new Car(900) { Distance = 100 },
                new HybridCar(900) { Distance = 100 },
                new Helicopter(4000) { Distance = 100 }
            };


            foreach (IFuelCosts veh in vehicles)
            {
                Console.WriteLine(
                    $"Чтобы преодалеть {(veh as VehiclesBase).Type} " +
                    $"{veh.Distance} километров, " +
                    $"необходимо {veh.FuelCost()} литров топлива");
            }

            Console.ReadKey();
        }
    }
}
