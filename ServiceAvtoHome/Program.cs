using ServiceAvtoHome;
using System;

namespace ServiceAvto
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string? user, PoiskMarka, PoiskColor, newMarka, newColor, newType;
            int choice, nomerAvto, x, yearEditionA, yearEditionB, powerA, powerB, y, newYearEdition, newPower, newCost;
            int size = 10;
           
            int[] YearEdition = new int[10];
            string[] Marka = new string[10];
            string[] Color = new string[10];
            int[] Power = new int[10];
            int[] Cost = new int[10];
            string[] masMarka = { "FORD", "AUDI", "BMW", "OPEL", "MAZDA", "LADA", "MITSUBISHI", "NISSAN", "TOYOTA", "LEXUS", "FIAT", "RENAULT", "MERCEDES BENZ" };
            string[] masType = { "Седан", "Хэтчбек", "Универсал", "Купе", "SUV" };
            string[] masColor = { "Белый", "Черный", "Серебристый", "Красный", "Синий" };
            List<Avto> car = new List<Avto>();
            Random rand = new Random();
            for (int i = 0; i < size; i++)
            {
                car.Add(new Avto { marka = masMarka[rand.Next(0, 12)], color = masColor[rand.Next(0, 4)], type = masType[rand.Next(0, 4)], yearEdition = rand.Next(2000, 2021), power = rand.Next(2, 6) * 50, cost = rand.Next(10, 30) * 1000});
                Console.WriteLine(car[i].KomponovkaCar());
               
             }
            
            while (true)
            {
                Console.WriteLine("Введите Ваш статус \n администратор \n клиент \n СТОП ");
                user = Console.ReadLine();
                if (user.ToUpper() == "АДМИНИСТРАТОР")
                {
                    user = "admin";
                    Console.WriteLine($"Добрый день, {user}!");
                    Console.WriteLine();
                    while (true)
                    {
                        Console.WriteLine("Что необходимо сделать: \n 1 - Вывести на экран все имеющиеся авто на складе \n 2 - добавить авто в каталог \n 3 - изменить цену авто \n 4 - выход");
                        choice = Convert.ToInt32(Console.ReadLine());
                        if (choice == 1)
                        {
                            for (int i = 0; i < size; i++)
                            {
                                Console.WriteLine(car[i].KomponovkaCar());
                            }
                        }
                        if(choice == 2)
                        {
                            size++;
                            Console.WriteLine("Введите марку авто ");
                            newMarka = Console.ReadLine();
                            Console.WriteLine("Введите тип кузова (Седан, Хэтчбек, Универсал, Купе, SUV) ");
                            newType = Console.ReadLine();
                            Console.WriteLine("Введите год выпуска ");
                            newYearEdition = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите цвет авто (белый, черный, серебристый, красный, синий) ");
                            newColor = Console.ReadLine();
                            Console.WriteLine("Введите мощность (100-300 л.с.) ");
                            newPower = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите цену авто ");
                            newCost = Convert.ToInt32(Console.ReadLine());
                            car.Add(new Avto { marka = newMarka, type=newType, color=newColor, power=newPower, yearEdition=newYearEdition,cost=newCost });
                            Console.WriteLine("Добавлена новая машина в каталог\n"+car[size-1].KomponovkaCar());
                        }
                        if (choice == 3)
                        {
                            while (true)
                            {
                                Console.WriteLine("Введите порядковый номер авто");
                                nomerAvto = Convert.ToInt32(Console.ReadLine());
                                if (nomerAvto < 1 || nomerAvto > size)
                                {
                                    Console.WriteLine("Неверный номер авто");
                                    continue;
                                }
                                Console.WriteLine("Старая цена " + nomerAvto + "-й машины: " + car[nomerAvto - 1].cost + "$ \n Введите новую цену ");
                                car[nomerAvto - 1].cost = Convert.ToInt32(Console.ReadLine());
                                break;

                            }
                        }
                        if (choice == 4) break;
                    }
                }

                if (user.ToUpper() == "КЛИЕНТ")
                {
                    Console.WriteLine("Как к Вам обращаться?");
                    user = Console.ReadLine();
                    Console.WriteLine($"Добрый день, {user}!");
                    while (true)
                    {
                        Console.WriteLine($"{user}, по какому параметру будем искать авто: \n 1 - марка авто \n 2 - год выпуска (2000-2021) \n 3 - мощность в л.с.(100-300) \n 4 - цвет \n 5 - выход");
                        choice = Convert.ToInt32(Console.ReadLine());
                        x = 0; // счетчик
                        if (choice == 1)
                        {
                            Console.WriteLine("Введите марку авто (англ, заглавными буквами)");
                            PoiskMarka = Console.ReadLine();
                            for (int i = 0; i < 10; i++)
                            {
                                if (Marka[i] == PoiskMarka)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Найдено:");
                                    Console.WriteLine($"Марка авто {Marka[i]}");
                                    Console.WriteLine($"Год выпуска {YearEdition[i]}");
                                    Console.WriteLine($"Мощность {Power[i]} л.с.");
                                    Console.WriteLine($"Цвет {Color[i]}");
                                    Console.WriteLine($"Цена {Cost[i]} $");
                                    Console.WriteLine();
                                    x++;
                                }
                            }
                            if (x == 0) Console.WriteLine("К сожалению, у нас нет такой машины");

                        }
                        if (choice == 2)
                        {
                            while (true)
                            {
                                Console.WriteLine("Введите год выпуска в виде интервала (не ранее 2000г), начиная с ");
                                yearEditionA = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("по (не позднее 2021г) ");
                                yearEditionB = Convert.ToInt32(Console.ReadLine());
                                if (yearEditionA < 2000 || yearEditionB > 2021 || yearEditionA > yearEditionB)
                                {
                                    Console.WriteLine("Неверный год выпуска. Введите заново");
                                    continue;
                                }
                                break;
                            }
                            for (int i = yearEditionA; i < yearEditionB + 1; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
                                    if (YearEdition[j] == i)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Найдено:");
                                        Console.WriteLine($"Марка авто {Marka[j]}");
                                        Console.WriteLine($"Год выпуска {YearEdition[j]}");
                                        Console.WriteLine($"Мощность {Power[j]} л.с.");
                                        Console.WriteLine($"Цвет {Color[j]}");
                                        Console.WriteLine($"Цена {Cost[j]} $");
                                        Console.WriteLine();
                                        x++;
                                    }
                                }
                            }
                            if (x == 0) Console.WriteLine("К сожалению, у нас нет такой машины");

                        }
                        if (choice == 3)
                        {
                            while (true)
                            {
                                Console.WriteLine("Введите мощности в виде интервала (не менее 100 л.с.), начиная с ");
                                powerA = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("по (не более 300 л.с.) ");
                                powerB = Convert.ToInt32(Console.ReadLine());
                                if (powerA < 100 || powerB > 300 || powerA > powerB)
                                {
                                    Console.WriteLine("Неверно введена мощность. Попробуйте заново");
                                    continue;
                                }
                                break;
                            }
                            for (int i = powerA; i < powerB + 1; i++)
                            {
                                for (int j = 0; j < 10; j++)
                                {
                                    if (Power[j] == i)
                                    {
                                        Console.WriteLine();
                                        Console.WriteLine("Найдено:");
                                        Console.WriteLine($"Марка авто {Marka[j]}");
                                        Console.WriteLine($"Год выпуска {YearEdition[j]}");
                                        Console.WriteLine($"Мощность {Power[j]} л.с.");
                                        Console.WriteLine($"Цвет {Color[j]}");
                                        Console.WriteLine($"Цена {Cost[j]} $");
                                        Console.WriteLine();
                                        x++;
                                    }
                                }
                            }
                            if (x == 0) Console.WriteLine("К сожалению, у нас нет такой машины");

                        }
                        if (choice == 4)
                        {
                            while (true)
                            {
                                y = 0;
                                Console.WriteLine("Введите цвет авто (белый, черный, серебристый, красный)");
                                PoiskColor = Console.ReadLine();
                                for (int i = 0; i < 4; i++)
                                {
                                    if (masColor[i] == PoiskColor)
                                    {
                                        y = 1;
                                        break;
                                    }
                                }
                                if (y == 1) break;
                            }
                            for (int i = 0; i < 10; i++)
                            {
                                if (Color[i] == PoiskColor)
                                {
                                    Console.WriteLine();
                                    Console.WriteLine("Найдено:");
                                    Console.WriteLine($"Марка авто {Marka[i]}");
                                    Console.WriteLine($"Год выпуска {YearEdition[i]}");
                                    Console.WriteLine($"Мощность {Power[i]} л.с.");
                                    Console.WriteLine($"Цвет {Color[i]}");
                                    Console.WriteLine($"Цена {Cost[i]} $");
                                    Console.WriteLine();
                                    x++;
                                }
                            }
                            if (x == 0) Console.WriteLine("К сожалению, у нас нет такой машины");

                        }
                        if (choice == 5) break;
                    }

                }
                if (user.ToUpper() == "СТОП") break;

            }


        }
    }
}