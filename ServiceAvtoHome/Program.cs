using ServiceAvtoHome;
using System;
using static ServiceAvtoHome.SimpleData;

namespace ServiceAvtoHome
{
    class Program
    {
        static void Main(string[] args)
        {
           
            string? user, searchMarka, searchColor, newMarka, newColor, newType, newTypeDisk, newTypeTyre, newConditioner, newHeat, newNavigation, choise2 ;
            int choice, nomerAvto, x, yearEditionA, yearEditionB, powerA, powerB, y, newYearEdition, newPower, newCost, tempIndex, newRadius, z;
            
            // x - счетчик машин в выборе клиента; y - переменная для выхода из цикла проверки цвета; z - счетчик увеличения стоимости за доп.опции и колеса
            // tempIndex - порядковый номер машины найденной клиентом в базе; choise2 - выбор да/нет
            int size = 10;

            CreateCatalogAvto();
            for (int i = 0; i < size; i++)
            {
                Console.WriteLine(cars[i].CarComposition(i + 1));
                Console.WriteLine(wheels[i].WheelComposition());
                Console.WriteLine(options[i].OptionComposition());
            }
            while (true)
            {
                Console.WriteLine("\nВведите Ваш статус \n администратор \n клиент \n СТОП ");
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
                                Console.WriteLine(cars[i].CarComposition(i+1));
                                Console.WriteLine(wheels[i].WheelComposition());
                                Console.WriteLine(options[i].OptionComposition());
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
                            Console.WriteLine("Ведите радиус диска ");
                            newRadius = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Введите тип диска (литой или штамп) ");
                            newTypeDisk = Console.ReadLine();
                            Console.WriteLine("Введите сезонность резины (зима или лето) ");
                            newTypeTyre = Console.ReadLine();
                            Console.WriteLine("Введите наличие кондиционера (да или нет) ");
                            newConditioner = Console.ReadLine();
                            Console.WriteLine("Введите наличие зимнего пакета (да или нет) ");
                            newHeat = Console.ReadLine();
                            Console.WriteLine("Введите наличие навигации (да или нет) ");
                            newNavigation = Console.ReadLine();

                            cars.Add(new Avto { marka = newMarka, type=newType, color=newColor, power=newPower, yearEdition=newYearEdition,cost=newCost });
                            Console.WriteLine("\nДобавлена новая машина в каталог\n"+cars[size-1].CarComposition(size));
                            wheels.Add(new Wheel { radius = newRadius, typeDisk = newTypeDisk, typeTyre = newTypeTyre, });
                            Console.WriteLine(wheels[size-1].WheelComposition());
                            options.Add(new Option { conditioner = newConditioner, heat= newHeat, navigation=newNavigation });
                            Console.WriteLine(options[size-1].OptionComposition());

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
                                Console.WriteLine("Старая цена " + nomerAvto + "-й машины: " + cars[nomerAvto - 1].cost + "$ \nВведите новую цену ");
                                cars[nomerAvto - 1].cost = Convert.ToInt32(Console.ReadLine());
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
                        x = 0;
                        y = 0;
                        z = 0;
                        tempIndex = 0;
                        if (choice == 1)
                        {
                            Console.WriteLine("Введите марку авто (англ, заглавными буквами)");
                            searchMarka = Console.ReadLine();
                            for (int i = 0; i < size; i++)
                            {
                                if (searchMarka.ToUpper() == cars[i].marka)
                                {
                                    tempIndex = i+1;
                                    Console.WriteLine(cars[i].CarComposition(i+1));
                                    x++;
                                }
                            }
                           

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
                                for (int j = 0; j < size; j++)
                                {
                                    if (cars[i].yearEdition == i)
                                    {
                                        tempIndex = i + 1;
                                        Console.WriteLine(cars[i].CarComposition(i+1));
                                        x++;
                                    }
                                }
                            }
                            

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
                                for (int j = 0; j < size; j++)
                                {
                                    if (cars[i].power == i)
                                    {
                                        tempIndex = i + 1;
                                        Console.WriteLine(cars[i].CarComposition(i+1));
                                        x++;
                                    }
                                }
                            }
                          

                        }
                        if (choice == 4)
                        {
                            while (true)
                            {
                                Console.WriteLine("Введите цвет авто (белый, черный, серебристый, красный, синий)");
                                searchColor = Console.ReadLine();
                                for (int i = 0; i < 5; i++)
                                {
                                    if (masColor[i] == searchColor.ToUpper())
                                    {
                                        y = 1;
                                        break;
                                    }
                                }
                                if (y == 1) break;
                               
                            }
                            for (int i = 0; i < size; i++)
                            {
                                if (cars[i].color == searchColor.ToUpper())
                                {
                                    tempIndex = i + 1;
                                    Console.WriteLine(cars[i].CarComposition(i+1));
                                    x++;
                                }
                            }
                           

                        }
                        if(choice > 0 && choice<5)
                        {
                            if (x == 0) Console.WriteLine("\nК сожалению, у нас нет такой машины");
                            else {
                                Console.WriteLine($"\n{user}, Вы останавливаетесь на этом выборе(да/нет)? ");
                                choise2 = Console.ReadLine();
                                if(choise2.ToUpper() == "ДА")
                                {
                                    if (x > 1)
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("\nНайдено несколько машин. Введите номер авто в базе, который Вы планируете брать");
                                            tempIndex = Convert.ToInt32(Console.ReadLine());
                                            if (tempIndex >= 1 && tempIndex <= size) break;
                                        }
                                    }
                                    Console.WriteLine("На выбранной Вами машине установлены колеса:");
                                    Console.WriteLine(wheels[tempIndex - 1].WheelComposition());
                                    Console.WriteLine("Будете менять (да/нет)?");
                                    choise2 = Console.ReadLine();
                                    if (choise2.ToUpper() == "ДА")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("Ведите радиус диска (c 16-го). Изменение на один размер - изменение на 500$");
                                            newRadius = Convert.ToInt32(Console.ReadLine());
                                            if (newRadius < wheels[tempIndex-1].radius) continue;
                                            z += (newRadius - wheels[tempIndex-1].radius)*500;
                                            wheels[tempIndex-1].radius = newRadius;
                                            cars[tempIndex - 1].cost += z;
                                            break;
                                        }
                                        while (true)
                                        {
                                            Console.WriteLine("Введите тип диска (литой или штамп). Стоимость изменения - 1000$ ");
                                            newTypeDisk = Console.ReadLine();
                                            if (newTypeDisk.ToUpper() !="ЛИТОЙ" && newTypeDisk.ToUpper() !="ШТАМП") continue;
                                            if (wheels[tempIndex - 1].typeDisk != newTypeDisk.ToUpper())
                                            {
                                                z += 1000;
                                                wheels[tempIndex - 1].typeDisk = newTypeDisk;
                                                cars[tempIndex - 1].cost += z;
                                            }
                                            break;
                                        }
                                        while (true)
                                        {
                                            Console.WriteLine("Введите сезонность резины (зима или лето). Стоимость изменения - 1000$ ");
                                            newTypeTyre = Console.ReadLine();
                                            if (newTypeTyre.ToUpper() != "ЗИМА" && newTypeTyre.ToUpper() != "ЛЕТО") continue;
                                            if (wheels[tempIndex - 1].typeDisk != newTypeDisk)
                                            {
                                                z += 1000;
                                                wheels[tempIndex - 1].typeDisk = newTypeDisk;
                                                cars[tempIndex - 1].cost += z;
                                            }
                                            break;
                                        }

                                    }
                                    Console.WriteLine("Опции на выбранной Вами машине:");
                                    Console.WriteLine(options[tempIndex - 1].OptionComposition());
                                    Console.WriteLine("Будете менять (да/нет)?");
                                    choise2 = Console.ReadLine();
                                    if (choise2.ToUpper() == "ДА")
                                    {
                                        while (true)
                                        {
                                            Console.WriteLine("Кондиционер (да/нет) - изменение на 500$");
                                            newConditioner = Console.ReadLine();
                                            if (newConditioner.ToUpper() != "ДА" && newConditioner != "НЕТ") continue;
                                            if (options[tempIndex - 1].conditioner != newConditioner)
                                            {
                                                z += 500;
                                                options[tempIndex - 1].conditioner = newConditioner;
                                                cars[tempIndex - 1].cost += z;
                                            }
                                            break;
                                        }
                                        while (true)
                                        {
                                            Console.WriteLine("Зимний пакет (да/нет) - изменение на 500$");
                                            newHeat = Console.ReadLine();
                                            if (newHeat.ToUpper() != "ДА" && newHeat != "НЕТ") continue;
                                            if (options[tempIndex - 1].heat != newHeat)
                                            {
                                                z += 500;
                                                options[tempIndex - 1].heat = newHeat;
                                                cars[tempIndex - 1].cost += z;
                                            }
                                            break;
                                        }
                                        while (true)
                                        {
                                            Console.WriteLine("Навигация (да/нет) - изменение на 500$");
                                            newNavigation = Console.ReadLine();
                                            if (newNavigation.ToUpper() != "ДА" && newHeat != "НЕТ") continue;
                                            if (options[tempIndex - 1].navigation != newNavigation)
                                            {
                                                z += 500;
                                                options[tempIndex - 1].navigation = newNavigation;
                                                cars[tempIndex - 1].cost += z;
                                            }
                                            break;
                                        }

                                    }
                                }
                            }

                                 
                            

                        }
                        if (choice == 5) break;
                    }

                }
                if (user.ToUpper() == "СТОП") break;

            }


        }
    }
}