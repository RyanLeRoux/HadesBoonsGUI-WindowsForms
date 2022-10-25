using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadesBoonsGUI
{
    internal class Basics
    {
        public static string StringBoolComb(bool bools, string strings)
        {
            // Similar to multiplying a boolean with a string in Python
            if (bools == false) strings = " ";
            return strings;
        }
    }
}
