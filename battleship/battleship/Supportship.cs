using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Supportship: Ship, ISupportship
    {
     public Supportship(short speed, short range, short length)
        {
            Speed = speed;
            Range = range;
            Length = length;
            ShipCoordinate = new short[length][];
            for (int i = 0; i < length; i++)
            {
                ShipCoordinate[i] = new short[2];        
            }
        }
        
        public void Repair(short x, short y, GameField field)
        {
            if (field.FieldSize[y, x] == -1)
            {
                field.FieldSize[y, x] = 1;
            }
        }
       
    }
}
}
