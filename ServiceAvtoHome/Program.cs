using System;

namespace ServiceAvto
{
    class Program
    {
        static void Main(string[] args)
        {
            string? user;
            while (true)
            {
                Console.WriteLine("Введите Ваш статус (администратор или клиент): ");
                user = Console.ReadLine();
                if (user == "Администратор" || user == "администратор" || user == "Клиент" || user == "клиент") break;
            }
            Console.WriteLine($"Добрый день, {user}!");

        }
    }
}