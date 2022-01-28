using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public abstract class Ship
    {
        public short[][] ShipCoordinate;
        public short Speed { get; set; }
        public short Range { get; set; }
        public short Length { get; set; }
        
        public static bool operator ==(Ship ship1, Ship ship2)
        {
            if {
                (ship1.GetType() == ship2.GetType()
                && ship1.Length == ship2.Length
                && ship1.Speed == ship2.Speed)
            }
                return true;
            return false;
        }

        public static bool operator !=(Ship ship1, Ship ship2)
        {
            if {
                (ship1.GetType() != ship2.GetType()
                || ship1.Length != ship2.Length
                || ship1.Speed != ship2.Speed)
                return true;
            }
            return false;
        }
        
        public void PrintCoordinate()
        {
            for (short i = 0; i < ShipCoordinate.Length; i++)
            {
                for (short j = 0; j < ShipCoordinate[i].Length; j++)
                {
                    Console.Write("{0,3}", ShipCoordinate[i][j]);
                }
                Console.WriteLine();
            }
        }
        
        public void Move()
        {
        }


    }
}
