using System;
using System.Collections.Generic;
using System.Text;

namespace _2048game
{
    class Tile
    {   
        public int Value { get; set; }
        public const int MAX_VALUE = 2048;

        public Tile()
        {
            Value = 2;
        }

        public Tile(int value)
        {
            Value = value;
        }

     
        public static string GetTileString(int v)
        {
            string vString = v.ToString();
            string prefix, suffix;

            if (v == 0)
                vString = " ";
            
            switch (vString.Length)
            {
                case (1):
                    prefix = "    ";
                    suffix = "    ";
                    break;
                case (2):
                    prefix = "    ";
                    suffix = "   ";
                    break;
                case (3):
                    prefix = "   ";
                    suffix = "   ";
                    break;
                case (4):
                    prefix = "   ";
                    suffix = "  ";
                    break;
                default:
                    prefix = "     ";
                    suffix = "    ";
                    break;
            }

            return "|" + prefix + vString + suffix + "|";
        }

        public override string ToString()
        {
            return GetTileString(Value);
        }
    }
}
