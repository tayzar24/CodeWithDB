﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class DisplayHelper
    {
        static int tableWidth = 100;
        public static void PrintLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public static void PrintRow(params string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        public static string AlignCentre(string text, int width)
        {
            if (string.IsNullOrEmpty(text))
                text = string.Empty;
            text = text.Length > width ? text.Substring(0, width - 4) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }

    }
}
