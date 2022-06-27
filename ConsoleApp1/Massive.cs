using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;

namespace ConsoleApp1
{

    public class Massive
    {

        public int UniqNumber;
        static public int size;
        public int Size = size;
        public int[] Mass = new int[size];

        public Massive(int size)
        {
            Massive.size = size;
        }


        public void RandomNumbers()
        {
            Random random = new Random();

            for (int i = 0; i < size; i++)
            {
                Mass[i] = random.Next(-15, 15);
            }

            Console.Write($"Массив: {string.Join(" ", Mass)} ");
        }


        public void RandomOrder()
        {
            Random randNum = new();
            int f = 1;
            int k = randNum.Next(0, 30);
            for (int i = 0; i < k; i++) 
            {
                int j = Mass[f];
                Mass[f] = Mass[f - 1];
                Mass[f - 1] = j;
                f++;
                if (f == size - 1)
                    f = 1;
            }

            Console.Write("Случайный порядок: ");
            Console.WriteLine(string.Join(" ", Mass));

        }


        public void UniqNumbers()
        {
            List<int> Unique = Mass.Distinct().ToList();
            UniqNumber = Unique.Count;
            Console.WriteLine($"Уникальные номера: {UniqNumber}");
        }


        public void PrintOutput()
        {
            int option = 0;
            while (option != 1)
            {
                Console.Write("\n\nНажмите 1 чтобы изменить порядок, 2 чтобы вывести уникальные номера и 3 чтобы выполнить оба пункта \nодновременно: ");
                int new_choice = Convert.ToInt32(Console.ReadLine());

                if (new_choice == 1) { RandomOrder(); option = 0; }
                else if (new_choice == 2) { UniqNumbers(); option = 0; }
                else if (new_choice == 3) { RandomOrder(); UniqNumbers(); option = 1; }
                else
                {
                    Console.WriteLine("\nВвод не корректен\n");
                    option = 0;
                }
            }

        }



        public static void Serialization(Massive massive)
        {
            string objectToSerialize = JsonConvert.SerializeObject(massive);
            File.WriteAllText("E:/KPI/Labs/lab1/file.json", objectToSerialize);

            string jsonText = File.ReadAllText("E:/KPI/Labs/lab1/file.json");
            Console.WriteLine($"\nJSON файл: {jsonText}");
        }



        public static Massive Deserialization(string filename)
        {

            string json = File.ReadAllText("E:/KPI/Labs/lab1/file.json");
            var massive = JsonConvert.DeserializeObject<Massive>(json);
            int size = massive.Size;
            return massive;
        }


        ~Massive() { }
    }

    public class JsonConvert
    {
        public static T DeserializeObject<T>(string json)
        {
            throw new NotImplementedException();
        }

        public static string SerializeObject(Massive massive)
        {
            throw new NotImplementedException();
        }
    }
}

