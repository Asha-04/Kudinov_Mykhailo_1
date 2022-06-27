using System;
using System.IO;   

namespace ConsoleApp3
{
    class Program
    {

        static void Main()
        {
            string filename = "E:/KPI/Labs/lab1/file.json";
            int option = 0;

            while (option != 1)
            {
                Console.Write("Нажмите 1 чтобы сериализировать и 2 чтобы десериализировать: ");
                int choise = Convert.ToInt32(Console.ReadLine());

                switch (choise)
                {
                    case 1:

                        option = 1;
                        Console.Write("\nВведите размер массива: ");
                        int size = Convert.ToInt32(Console.ReadLine());
                        Massive.size = size; 
                        Massive massive = new(size);
                        massive.RandomNumbers();
                        massive.PrintOutput();
                        Massive.Serialization(massive);
                        break;

                    case 2:

                        option = 1;
                        massive = Massive.Deserialization(filename);
                        massive.RandomNumbers();
                        massive.PrintOutput();
                        string jsonText = File.ReadAllText(filename);
                        Console.WriteLine($"\nJSON файл: {jsonText}");
                        break;

                    default:

                        option = 0;
                        Console.WriteLine("\nВвод не корректен\n");
                        break;

                }
            }
        }
    }
}