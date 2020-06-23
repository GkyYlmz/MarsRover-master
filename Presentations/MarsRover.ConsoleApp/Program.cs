using System;
using System.Net.Http.Headers;
using MarsRover.Core.Enums;
using MarsRover.Core.Infrastructure;
using MarsRover.Core.Model;
using MarsRover.Core.Helpers;

namespace MarsRover.ConsoleApp
{

    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                var grid = GetLimit();
                var coordinates = GetCoordinates();

                IVehicle roverManager = new RoverManager(coordinates.X, coordinates.Y, coordinates.Direction, grid);
                Console.WriteLine("Lütfen robotun harf katarını giriniz!");
                var result = roverManager.Process(Console.ReadLine());
                Console.WriteLine(result);
            }
        }

        private static Grid GetLimit()
        {
            Console.WriteLine("Lütfen x ve y sınırlarını giriniz..");
            var limitString = Console.ReadLine();
            var limitArray = limitString.Split(' ');

            if (limitArray.Length != 2 || ((!limitArray[0].IsNumber()) || (!limitArray[1].IsNumber())))
            {
                Console.WriteLine("İçerik yanlış girildi!");
                return GetLimit();
            }
           
            var grid = new Grid(limitArray[0].ToInt(), limitArray[1].ToInt());

            return grid;
        }

        private static Coordinates GetCoordinates()
        {
            Console.WriteLine($"Lütfen  robotun koordinatlarını giriniz..");
            var coordinatString = Console.ReadLine();
            var coordinatArray = coordinatString.ToUpper().Split(' ');

            if (coordinatArray.Length != 3)
            {
                Console.WriteLine("İçerik yanlış girildi!");
                return GetCoordinates();

            }

            Direction direction = (Direction)Enum.Parse(typeof(Direction), coordinatArray[2]);
            var coordinates = new Coordinates
            {
                X = coordinatArray[0].ToInt(),
                Y = coordinatArray[1].ToInt(),
                Direction = direction
            };

            return coordinates;
        }

    }
}
