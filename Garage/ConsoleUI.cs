﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GarageMaker
{
    internal class ConsoleUI
    {

        internal static ConsoleKey GetKey => Console.ReadKey(intercept: true).Key;

    }
}
