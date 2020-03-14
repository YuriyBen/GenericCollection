using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
namespace Class_Student
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                #region List for console input
                //List<Student> students = new List<Student>()
                //{
                //    new Student("Ben","Yuriy", "AMi-25", new int[]{ 1, 2, 3, 4, 3}),
                //    new Student("Serdiuk","Nazar", "Kio-12", new int[]{ 1, 2, 5,4,2}),
                //    new Student("Libik","Sania", "Dlk", new int[]{ 1, 1,5,5,3}),
                //    new Student("Riabiy","Oleksiy", "Let", new int[]{ 1, 2, 3, 4, 3})
                //};
                #endregion

                StudentsCollection<Student>.ReadFromFile();
                Console.Clear();
                ConditionsMenu();
                Menu();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message); ;
            }
            Console.ReadLine();
        }


        #region Menu and conditions
        static void ConditionsMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new string('-', 30) + "\tM\te\tn\tu\t" + new string('-', 30));
            Console.Write("Possible options:\nOutput datas(1)\nSort datas(2)\nFind by criteria(3)\nWork with file( add(4),remove(5),edit(6) )\nExit(0)\n\nYour choise: ");
            Console.ResetColor();
        }

        static void Menu()
        {
            bool result = true;
            while (result)
            {
                int choise = Validation.Converter();
                switch (choise)
                {
                    case 1:
                        {
                            Console.Clear();
                            foreach (var item in StudentsCollection<Student>.collection)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(item);
                                Console.ResetColor();
                            }
                            Console.ReadLine();
                            Console.Clear();
                            ConditionsMenu();
                            break;
                        }
                    case 2:
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("The possible properties for sorting: ");
                            PropertyInfo[] propertyInfos = typeof(Student).GetProperties();
                            foreach (PropertyInfo propertyInfo in propertyInfos)
                            {
                                Console.Write(propertyInfo.Name + " ");
                            }
                            Console.Write("Your choise: ");
                            string property = Console.ReadLine();
                            StudentsCollection<Student>.Sort(property);//
                            Console.ResetColor();
                            Console.ReadLine();
                            Console.Clear();
                            ConditionsMenu();
                            break;
                        }
                    case 3:
                        {
                            Console.Clear();
                            StudentsCollection<Student>.Find();//
                            Console.ReadLine();
                            Console.Clear();
                            ConditionsMenu();
                            break;
                        }
                    case 4:
                        {
                            Console.Clear();
                            var tuple = Student.Input();
                            StudentsCollection<Student>.Add(new Student(tuple.Item2, tuple.Item1, tuple.Item3, tuple.Item4));//
                            Console.ReadLine();
                            Console.Clear();
                            ConditionsMenu();
                            break;
                        }

                    case 5:
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.Write("Input the substring you want to remove: ");
                            string substring = Console.ReadLine();
                            StudentsCollection<Student>.Remove(substring);//
                            Console.ResetColor();
                            Console.ReadLine();
                            Console.Clear();
                            ConditionsMenu();
                            break;
                        }

                    case 6:
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write("Input the substring you want to edit: ");
                            string substring = Console.ReadLine();
                            var tuple = Student.Input();
                            StudentsCollection<Student>.Edit(substring, new Student(tuple.Item2, tuple.Item1, tuple.Item3, tuple.Item4));
                            Console.ReadLine();
                            Console.Clear();
                            ConditionsMenu();
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.BackgroundColor = ConsoleColor.Gray;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write("I'm sorry...");
                            Console.ResetColor();
                            result = false;
                            break;
                        }
                }
            }
        }
        #endregion
    }
}