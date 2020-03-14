using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;

namespace Class_Student
{
    class Validation
    {
        public static string ValidateName(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-z]*$", RegexOptions.IgnoreCase)) throw new Exception("Wrong name or surname...");
            return name;
        }
        public static string ValidateGroup(string group)
        {

            if (!Regex.IsMatch(group, @"^[a-z]{2,10}[-|_]{0,1}[0-9]{0,5}$", RegexOptions.IgnoreCase)) throw new Exception("Wrong group...");
            return group;
        }
        public static int[] ValidateIntArr<T>(T[]array)
        {
            if (array.Length != 5) throw new Exception("Wrong a size of the array...");
            int[] arr = new int[array.Length];     
            if (!array.All(p => Regex.IsMatch(p.ToString(), @"^[0-5]{1}$", RegexOptions.IgnoreCase)))
            {
                throw new Exception("Wrong marks...");
            }
            arr = Array.ConvertAll(array, s => int.Parse(s.ToString()));
            return arr;
        }
        public static string FileExistance()
        {
            Console.Write("Input the name of your file: ");
            string path = Console.ReadLine();
            while (!File.Exists(path))
            {
                Console.Write($"Wrong the path to your file ({path})\nRewrite it correctly: ");
                path = Console.ReadLine();
            }
            return path;
        }
        public static uint ValidateSize(string size)
        {
            if (!uint.TryParse(size, out uint res))
            {
                throw new Exception("Wrong the size of a collection");
            }
            return res;
        }
        public static int Converter()
        {
            if (!Int32.TryParse(Console.ReadLine(), out int indexerChoise))
            {
                throw new Exception("Can't convert from string to int...");
            }
            return indexerChoise;
        }
        public static Regex stringToParse { get; private set; } = new Regex(".+[ ].+[ ].+[ ].+");
        public static string ValidationToParse(string strToParse)
        {
            while (!stringToParse.IsMatch(strToParse))
            {
                throw new Exception("Wrong input...");
            }
            return strToParse;
        }
    }
}