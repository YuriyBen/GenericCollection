using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Class_Student
{
    class StudentsCollection<T> where T : new()
    {
        internal static List<T> collection = new List<T>();
        internal static string path;
        //public StudentsCollection(List<Student> lst)
        //{
        //    students = lst;
        //}
        T this[int index]
        {
            get => collection[index];
            set => collection[index] = value;
        }
        public static void ReadFromFile()
        {
            path = Validation.FileExistance();
            string[] studColl = File.ReadAllLines(path);
            foreach (string item in studColl)
            {
                collection.Add((T)Activator.CreateInstance(typeof(T),item));
            }
        }
        public static void Edit(string substring,T newItem)
        {
            try
            {
                for (int i = 0; i < collection.Count; i++)
                {
                    if (collection[i].ToString().ToLower().Contains(substring.ToLower()))
                    {
                        collection[i]=newItem;
                    }
                }
                OutputFile();
            }
            catch
            {

                throw new Exception("Uncorrect substring...");
            }
            Console.WriteLine("Done...");
            Console.ResetColor();
        }
        public static void Add(T item)
        {
            collection.Add(item);
            Console.WriteLine("Done...");
            OutputFile();
            Console.ResetColor();
        }
        public static void Find()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
            Console.Write("Input the string you want to find: ");
            string text = Console.ReadLine();
            Console.Clear();
            foreach (var item in collection)
            {
                if (item.ToString().Contains(text))
                {
                    Console.WriteLine(item);
                }
            }
            Console.ResetColor();
        }
        public static void Sort(string property)
        {
            try
            {
                collection = collection.OrderBy(p => p.GetType().GetProperty(property).GetValue(p)).ToList();
                OutputFile();
            }
            catch
            {
                throw new Exception("Class has not such property!");
            }
            Console.WriteLine("Done...");
        }
        public static void Remove(string substring)
        {
            try
            {
                for (int i = 0; i < collection.Count; i++)
                {
                    if (collection[i].ToString().ToLower().Contains(substring.ToLower()))
                    {
                        collection.RemoveAt(i);
                    }
                }
                OutputFile();
            }
            catch
            {

                throw new Exception("Uncorrect substring...");
            }
            Console.WriteLine("Done...");
        }
        static void OutputFile()
        {
            using (StreamWriter writer = new StreamWriter(path))
            {
                foreach (var item in collection)
                {
                    writer.WriteLine(item.ToString());
                }
            }
        }
    }
}
