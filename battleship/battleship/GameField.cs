using battleship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Battleship
{
    public class GameField
    {
        public string NameOfThePlayground { get; set; }
        public short Width { get; set; }
        public short Height { get; set; }
        public short QuantityOfShips { get; set; }
        public short[,] FieldSize { get; set; }

        public Ship[] ListOfShips = new Ship[] { };
        public List<short> ListOfValidCoordinates { get; set; } = new List<short>();

        public GameField(short height, short width, string name)
        {
            Width = width;
            Height = height;
            NameOfThePlayground = name;
            FieldSize = new short[height, width];
        }


        public void Print()
        {
            for (short i = 0; i < FieldSize.GetLength(0); i++)
            {
                for (short j = 0; j < FieldSize.GetLength(1); j++)
                {
                    Console.Write("{0,3}", FieldSize[i, j]);
                }
                Console.WriteLine();
            }
        }


        public bool CanAddShip(Ship ship, Direction direction, short x, short y)
        {
            if (direction == Direction.North && y - ship.Length + 1 >= 0)
            {
                for (short i = y, j = ship.Length; j > 0; i--, j--)
                {
                    if (FieldSize[i, x] == 1)
                    {
                        Console.WriteLine("no empty space");
                        return false;
                    }
                }
            }
            else if (direction == Direction.East && x + ship.Length <= FieldSize.GetLength(1))
            {
                for (short i = x, j = ship.Length; j > 0; j--, i++)
                {
                    if (FieldSize[y, i] == 1)
                    {
                        Console.WriteLine("no empty space");
                        return false;
                    }
                }
            }
            else if (direction == Direction.West && x - ship.Length + 1 >= 0)
            {
                for (short i = x, j = ship.Length; j > 0; j--, i--)
                {
                    if (FieldSize[y, i] == 1)
                    {
                        Console.WriteLine("no empty space");
                        return false;
                    }
                }
            }
            else if (direction == Direction.South && y + ship.Length <= FieldSize.GetLength(0))
            {
                for (short i = y, j = ship.Length; j > 0; i++, j--)
                {
                    if (FieldSize[i, x] == 1)
                    {
                        Console.WriteLine("no empty space");
                        return false;
                    }
                }
            }
            else
            {
                Console.WriteLine("out of range");
                return false;
            }
            return true;
        }

        public void AddShip(Ship ship, Direction direction, short x, short y)
        {
            if (direction == Direction.North && CanAddShip(ship, direction, x, y))
            {
                for (short i = y, j = ship.Length; j > 0; i--, j--)
                {
                    FieldSize[i, x] = 1;
                    ship.ShipCoordinate[j - 1][0] = i;
                    ship.ShipCoordinate[j - 1][1] = x;
                }
                Array.Resize(ref ListOfShips, ListOfShips.Length + 1);
                ListOfShips[ListOfShips.Length - 1] = ship;
            }
            if (direction == Direction.West && CanAddShip(ship, direction, x, y))
            {
                for (short i = x, j = ship.Length; j > 0; j--, i--)
                {
                    FieldSize[y, i] = 1;
                    ship.ShipCoordinate[j - 1][0] = y;
                    ship.ShipCoordinate[j - 1][1] = i;
                }
                Array.Resize(ref ListOfShips, ListOfShips.Length + 1);
                ListOfShips[ListOfShips.Length - 1] = ship;
            }
            if (direction == Direction.East && CanAddShip(ship, direction, x, y))
            {

                for (short i = x, j = ship.Length; j > 0; j--, i++)
                {
                    FieldSize[y, i] = 1;
                    ship.ShipCoordinate[j - 1][0] = y;
                    ship.ShipCoordinate[j - 1][1] = i;
                }
                Array.Resize(ref ListOfShips, ListOfShips.Length + 1);
                ListOfShips[ListOfShips.Length - 1] = ship;
            }
            if (direction == Direction.South && CanAddShip(ship, direction, x, y))
            {
                for (short i = y, j = ship.Length; j > 0; i++, j--)
                {
                    FieldSize[i, x] = 1;
                    ship.ShipCoordinate[j - 1][0] = i;
                    ship.ShipCoordinate[j - 1][1] = x;
                }
                Array.Resize(ref ListOfShips, ListOfShips.Length + 1);
                ListOfShips[ListOfShips.Length - 1] = ship;
            }
        }

        public void RemoveShip(Ship ship)
        {
            ListOfShips = ListOfShips.Where(val => val != ship).ToArray();
        }

        public void Check(Ship ship)
        {
            if (ship.ShipCoordinate.Length == 0)
            {
                RemoveShip(ship);
            }
        }

        public void DeleteCell(short x, short y)
        {
            foreach (var ship in ListOfShips)
            {
                for (short i = 0; i < ship.ShipCoordinate.GetLength(0); i++)
                {
                    if (ship.ShipCoordinate[i][0] == y && ship.ShipCoordinate[i][1] == x)
                    {
                        ship.ShipCoordinate = ship.ShipCoordinate.Where((el, j) =>j != i).ToArray();
                        Check(ship);
                    }
                    }
                }
            }
        }
    }
