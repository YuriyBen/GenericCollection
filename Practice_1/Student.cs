using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
//Створити клас СТУДЕНТ з наступними полями: прізвище, номер групи, успішність (масив із 5 цілих). 
//1. Додати до класу додаткові поля так, щоб сумарна кількість полів була 5+: 
//2+ текстові поля, решта - числа.
//4. Додати можливість видалення запису (+ запис у файл) по ідентифікатору
//5. Додати можливість додавання запису(+ запис у файл)
//6. Додати можливість редагування запису(+ запис у файл) по ідентифікатору
//7. Код повинен бути якісним: клас повинен бути в окрумому файлі, назва файла
//не повинна бути захардкоджена, читання з файла - окрема фукнція, тощо."
namespace Class_Student
{
    class Student
    {
        #region properties
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Group { get; set; }
        static int counter = 0;

        public int Id { get; internal set; }
        public int[] Mark;
        #endregion

        public Student()
        {

        }
        public Student(string smth)
        {
            string[]qqq = smth.Split(' ');
            FirstName = Validation.ValidateName(qqq[1]);
            LastName = Validation.ValidateName(qqq[0]);
            Group = Validation.ValidateGroup(qqq[2]);
            Mark = Validation.ValidateIntArr<string>(qqq[3].Split(','));
        }
        public Student(string surname, string name, string group, int[] success)
        {
            FirstName = Validation.ValidateName(name);
            LastName = Validation.ValidateName(surname);
            Group = Validation.ValidateGroup(group);
            Mark = Validation.ValidateIntArr<int>(success);
            Id = ++counter;
        }
        internal static Tuple<string, string, string, int[]> Input()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Surname: ");
            string surname = Console.ReadLine();
            Console.Write("Group: ");
            string group = Console.ReadLine();
            Console.Write("Marks: ");
            string[] text = Console.ReadLine().Split(' ');
            int[] arr;

            if (text.All(p => Regex.IsMatch(p.ToString(), @"^[0-5]*$", RegexOptions.IgnoreCase)))
            {
                arr = Array.ConvertAll(text, s => int.Parse(s));
            }
            else
            {
                throw new Exception("Wrong marks' input!");
            }
            return Tuple.Create(name, surname, group, arr);
        } // Input
        public static Student Parse(string repr)
        {
            repr = Validation.ValidationToParse(repr.Replace('\t', ' '));
            string[] repr_div = repr.Split();
            Student stud = new Student
            {
                FirstName = Validation.ValidateName(repr_div[0]),
                LastName = Validation.ValidateName(repr_div[1]),
                Group = Validation.ValidateGroup(repr_div[2]),
                Mark = Validation.ValidateIntArr<string>(repr_div[3].Split(',')),
                Id = ++counter,
            };
            return stud;
        }
        //public delegate void MyDel(string s);
        //public static void Output(MyDel del,List<Student>collection)
        //{
        //    for (int i = 0; i < collection.Count; i++)
        //    {
        //        del($"{collection[i].LastName} {collection[i].FirstName} {collection[i].Group} {string.Join(',', collection[i].Mark)}");
        //    }
        //}
        public override string ToString()
        {
            return $"{LastName} {FirstName} {Group} {string.Join(",", Mark)}";
        }
    }

}





