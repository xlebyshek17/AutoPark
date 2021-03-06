﻿using System;
using System.Threading;
using System.Collections.Generic;
using System.Globalization;
using Autopark.Controller;
using System.Text;

namespace Autopark
{
    class Program
    {
        public static void Main(string[] Args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US") 
            { 
                NumberFormat = new NumberFormatInfo()
                {
                    NumberDecimalSeparator = "."
                }
            };

            // 1 level
            ClassesController.Start(); 
            //2 level
            //InterfacesController.Start();
            // 3 level
            //InheritanceController.Start();
            // 4 level
            //AbstarctionController.Start();
            // 5 level
            //CollectionsController.Start();
            // 6 level
            //QueueController.Start();
            // 7 level
            //StackController.Start();
            // 8 level
            //DictionaryController.Start();
        }

    }
}
