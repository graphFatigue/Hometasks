using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    internal class Mixedship: Ship, ISupportship, IWarship
    {
        public void Repair(short x, short y, GameField field)
        {
            if (field.FieldSize[y, x] == -1)
            {
                field.FieldSize[y, x] = 1;
            }
        }
        public void Shoot(short x, short y, GameField field)
        {
            if (field.FieldSize[y, x] == 1)
            {
                field.FieldSize[y, x] = -1;
            }
            if (field.FieldSize[y, x] == -1)
            {
                field.FieldSize[y, x] = 0;
            }
        }

        public Mixedship(short speed, short range, short length)
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
        }
    }

    

