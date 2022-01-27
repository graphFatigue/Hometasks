using battleship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            var field = new GameField(10, 10, "dedinside");
            var ship1 = new Warship(4, 5, 4);
            field.AddShip(ship1, 0, 0, 4);
            field.Print();
            Console.WriteLine(ship1.ShipCoordinate);
            var ship2 = new Warship(4, 5, 1);
            field.AddShip(ship2, 0, 0, 2);
            field.Print();
            ship1.PrintCoordinate();
            ship2.Shoot(0, 1, field);
            Console.WriteLine();
            field.Print();
            ship2.Shoot(0, 1, field);
            var ship3 = new Warship(4, 5, 2);
            field.AddShip(ship3, Direction.East, 3, 2); //alt + enter
            field.Print();
            ship1.PrintCoordinate();
            foreach (var ship in field.ListOfShips)
            {
                Console.WriteLine(ship.Length);
            }
        }
    }
}
