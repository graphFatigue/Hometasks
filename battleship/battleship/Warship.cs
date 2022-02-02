using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class Warship: Ship, IWarship
    {
    public Warship(short speed, short range, short length)
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
    
        public void Shoot(short x, short y, GameField field)
        {
            if (field.FieldSize[y, x] == 1)
            {
                field.FieldSize[y, x] = -1;
            }
            else if (field.FieldSize[y, x] == -1)
            {
                field.FieldSize[y, x] = 0;
                field.DeleteCell(x, y);
            }
        } 
        
    }
   
}
