using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work4
{
    class Program
    {
        
        static void Main(string[] args)
        {
            MyList<string> List1 = new MyList<string>();

            List1.Add("Na");
            List1.Add("stya");

            Console.Write("Список1:\0");
            List1.Print(List1);
            Console.WriteLine();

            MyList<string> List2 = new MyList<string>();

            List2.Add("Sa");
            List2.Add("kun");

            Console.Write("Список2:\0");
            List2.Print(List2);
            Console.WriteLine();

            MyList<string> List3 = new MyList<string>();
            List3 = (List1 + List2);
            Console.Write("Сложение двух списков: ");
            List3.Print(List3);
            Console.WriteLine();

            Console.WriteLine($"Проверка на равенство:\0{List1 == List2}");
            Console.WriteLine($"Проверка на неравенство:\0{List1 != List2}");
            Console.WriteLine();


            Console.Write($"Инверсия: ");

            var t = !List1;
            foreach (string e in List1 )
            {
                Console.Write($"{e}\0");
            }
            Console.WriteLine();
            Console.WriteLine();


            MyList<string>.Owner Own = new MyList<string>.Owner { ID = 12, Name = "Анастасия", Org = "БГТУ" };
            Own.PrintOwner();
            Console.WriteLine();

            MyList<string>.Date date = new MyList<string>.Date();
            date.InfoDate();
            Console.WriteLine();

            MathOperation.Count(List1);
            MathOperation.Min(List1);
            MathOperation.Max(List1);
            Console.WriteLine();
        }

        public class MyList<T> : List<T>
        {
            public void Print(MyList<T> list)

            {
                foreach (T i in list)
                {
                    Console.Write($"{i}\0");
                }

                Console.WriteLine();
            }

            public static MyList<string> operator +(MyList<T> list1, MyList<T> list2)
            {
                MyList<string> list3 = new MyList<string>();
                foreach (T i in list1) list3.Add(i.ToString());
                foreach (T i in list2) list3.Add(i.ToString());
                return list3;
            }

            public static bool operator ==(MyList<T> list1, MyList<T> list2)
            {
                return list1.Equals(list2);
            }

            public static bool operator !=(MyList<T> list1, MyList<T> list2)
            {
                return !list1.Equals(list2);
            }

            public static IEnumerable<char> operator !(MyList<T> list1)
            {
                return list1.ToString().Reverse();
            }


            public class Owner
            {
                public int ID;
                public string Name;
                public string Org;

                public void PrintOwner()
                {
                    Console.WriteLine($"Owner: ID - {ID}; Имя - {Name}; Организация - {Org};");
                }
            }

            public class Date
            {
                public void InfoDate()
                {
                    Console.WriteLine("Сегодня: " + DateTime.Now);
                }
            }
        }
        
        public static class MathOperation
        {

            public static void Count( MyList<string> list1)
            {
                Console.WriteLine("Количество элементов в списке1: " + list1.Count);
            }

            public static void Min(MyList<string> list1)
            {
                string min = list1[0];

                for (int i=0; i<list1.Count; i++)
                {
                    if (list1[i].Length < min.Length)
                    {
                        min = list1[i];
                    }
                }

                Console.WriteLine("Минимальная строка в списке1: " + min);
            }

            public static void Max(MyList<string> list1)
            {
                string max = list1[0];

                for (int i = 0; i < list1.Count; i++)
                {
                    if (list1[i].Length > max.Length)
                    {
                        max = list1[i];
                    }
                }

                Console.WriteLine("Максимальная строка в списке1: " + max);
            }
        }
    }
        
    
}
