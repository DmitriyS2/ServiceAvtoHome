using System;

namespace ServiceAvto
{
    class Program
    {
        static void Main(string[] args)
        {
            string? user;
            int[] YearEdition = new int[10];
            string[] Marka = new string[10];
            string[] Color = new string[10];
            double[] V_dvig = new double[10];
            string[] mas_Marka = { "Ford", "Audi", "BMW", "Opel", "Mazda", "LADA", "Mitsubishi", "Nissan", "Toyota", "Lexus", "Fiat", "Renault", "Mercedes Benz" };
            string[] mas_Color = { "Белый", "Черный", "Серебристый", "Красный" };
            Random rand = new Random();
            for (int i=0; i<10; i++)
            {
                YearEdition[i] = rand.Next(2000, 2021);
                V_dvig[i] = rand.Next(10, 30)*0.1;
                Marka[i] = mas_Marka[rand.Next(0, 12)];
                Color[i] = mas_Color[rand.Next(0, 4)];
                Console.WriteLine($"Марка авто {Marka[i]}");
                Console.WriteLine($"Год выпуска {YearEdition[i]}");
                Console.WriteLine($"ОбЪём двигателя {V_dvig[i]} л");
                Console.WriteLine($"Цвет {Color[i]}");
                Console.WriteLine();
            }
            while (true)
            {
                Console.WriteLine("Введите Ваш статус (администратор или клиент): ");
                user = Console.ReadLine();
                if (user == "Администратор" || user == "администратор")
                {
                    Console.WriteLine("Добрый день, Админ!");
                    break;
                }
                if (user == "Клиент" || user == "клиент")
                {
                    Console.WriteLine("Как к Вам обращаться?");
                    user = Console.ReadLine();
                    Console.WriteLine($"Добрый день, {user}!");
                    break;
                }
                
             
            }
            

        }
    }
}