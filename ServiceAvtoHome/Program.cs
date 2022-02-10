using ServiceAvtoHome;
using System;
using static ServiceAvtoHome.SimpleData;

namespace ServiceAvtoHome
{
    class Program
    {

        static void Main(string[] args)
        {
            string? user, searchMarka, searchColor, newMarka, newColor, newType, newTypeDisk, newTypeTyre, newConditioner, newHeat, newNavigation, choiseYN;
            int choice, nomerAvto, x, yearEditionA, yearEditionB, powerA, powerB, newYearEdition, newPower, newCost, tempIndex, newRadius, addCost;

            int size = 10;
            int y = 0;

            string NewMarka()
            {
                while (true)
                {
                    Console.WriteLine("\nВведите марку авто (FORD, AUDI, BMW, OPEL, MAZDA, LADA, MITSUBISHI, NISSAN, TOYOTA, LEXUS, FIAT, RENAULT, MERCEDES BENZ)");
                    newMarka = Console.ReadLine();
                    for (int i = 0; i < 13; i++)
                    {
                        if (masMarka[i] == newMarka.ToUpper())
                        {
                            y = 1; // y - переменная для выхода из цикла проверки
                            break;
                        }
                    }
                    if (y == 1) break; // y - переменная для выхода из цикла проверки

                }
                return newMarka.ToUpper();
            }

            string NewType()
            {
                while (true)
                {
                    Console.WriteLine("\nВведите тип кузова (Седан, Хэтчбек, Универсал, Купе, SUV)");
                    newType = Console.ReadLine();
                    for (int i = 0; i < 5; i++)
                    {
                        if (masType[i] == newType.ToUpper())
                        {
                            y = 1; // y - переменная для выхода из цикла проверки
                            break;
                        }
                    }
                    if (y == 1) break; // y - переменная для выхода из цикла проверки

                }
                return newType.ToUpper();
            }

            int NewYearEdition()
            {
                while (true)
                {
                    Console.WriteLine("\nВведите год выпуска (в интервале 2000 - 2021)");
                    newYearEdition = Convert.ToInt32(Console.ReadLine());
                    if (newYearEdition >= 2000 && newYearEdition <= 2021) break;

                }
                return newYearEdition;
            }

            string NewColor()
            {
                while (true)
                {
                    Console.WriteLine("\nВведите цвет кузова (белый, черный, серебристый, красный, синий)");
                    newColor = Console.ReadLine();
                    for (int i = 0; i < 5; i++)
                    {
                        if (masColor[i] == newColor.ToUpper())
                        {
                            y = 1; // y - переменная для выхода из цикла проверки
                            break;
                        }
                    }
                    if (y == 1) break; // y - переменная для выхода из цикла проверки

                }
                return newColor.ToUpper();
            }

            int NewPower()
            {
                while (true)
                {
                    Console.WriteLine("\nВведите мощность (в интервале 100 - 300 л.с.)");
                    newPower = Convert.ToInt32(Console.ReadLine());
                    if (newPower >= 100 && newPower <= 2021) break;

                }
                return newPower;
            }

            int NewCost()
            {
                while (true)
                {
                    Console.WriteLine("\nВведите цену (в интервале 10000 - 30000$)");
                    newCost = Convert.ToInt32(Console.ReadLine());
                    if (newCost >= 10000 && newCost <= 30000) break;

                }
                return newCost;
            }

            int NewRadius()
            {
                while (true)
                {
                    Console.WriteLine("\nВведите радиус диска (в интервале 16 - 21)");
                    newRadius = Convert.ToInt32(Console.ReadLine());
                    if (newRadius >= 16 && newRadius <= 21) break;

                }
                return newRadius;
            }

            string NewTypeDisc()
            {
                while (true)
                {
                    Console.WriteLine("\nВведите тип диска (литой или штамп)");
                    newTypeDisk = Console.ReadLine();
                    if (newTypeDisk.ToUpper() == "ЛИТОЙ" || newTypeDisk.ToUpper() == "ШТАМП") break;
                }
                return newTypeDisk.ToUpper();
            }

            string NewTypeTyre()
            {
                while (true)
                {
                    Console.WriteLine("\nВведите сезонность резины (зима или лето)");
                    newTypeTyre = Console.ReadLine();
                    if (newTypeTyre.ToUpper() == "ЗИМА" || newTypeTyre.ToUpper() == "ЛЕТО") break;
                }
                return newTypeTyre.ToUpper();
            }

            string NewConditioner()
            {
                while (true)
                {
                    Console.WriteLine("\nВведите наличие кондиционера (да или нет)");
                    newConditioner = Console.ReadLine();
                    if (newConditioner.ToUpper() == "ДА" || newConditioner.ToUpper() == "НЕТ") break;
                }
                return newConditioner.ToUpper();
            }

            string NewHeat()
            {
                while (true)
                {
                    Console.WriteLine("\nВведите наличие зимнего пакета (да или нет)");
                    newHeat = Console.ReadLine();
                    if (newHeat.ToUpper() == "ДА" || newHeat.ToUpper() == "НЕТ") break;
                }
                return newHeat.ToUpper();
            }

            string NewNavigation()
            {
                while (true)
                {
                    Console.WriteLine("\nВведите наличие навигации (да или нет)");
                    newNavigation = Console.ReadLine();
                    if (newNavigation.ToUpper() == "ДА" || newNavigation.ToUpper() == "НЕТ") break;
                }
                return newNavigation.ToUpper();
            }

            void AddNewAvto()
            {
                ClearScreen();
                size++;
                newMarka = NewMarka();
                newType = NewType();
                newYearEdition = NewYearEdition();
                newColor = NewColor();
                newPower = NewPower();
                newCost = NewCost();
                newRadius = NewRadius();
                newTypeDisk = NewTypeDisc();
                newTypeTyre = NewTypeTyre();
                newConditioner = NewConditioner();
                newHeat = NewHeat();
                newNavigation = NewNavigation();
                ClearScreen();
                cars.Add(new Avto { marka = newMarka, type = newType, color = newColor, power = newPower, yearEdition = newYearEdition, cost = newCost });
                Console.WriteLine("\nДобавлена новая машина в каталог\n" + cars[size - 1].CarComposition(size));
                wheels.Add(new Wheel { radius = newRadius, typeDisk = newTypeDisk, typeTyre = newTypeTyre });
                Console.WriteLine(wheels[size - 1].WheelComposition());
                options.Add(new Option { conditioner = newConditioner, heat = newHeat, navigation = newNavigation });
                Console.WriteLine(options[size - 1].OptionComposition());
                Console.ReadLine();
                ClearScreen();

            }

            void PrintAvto(int i)
            {
                Console.WriteLine(cars[i].CarComposition(i + 1));
                Console.WriteLine(wheels[i].WheelComposition());
                Console.WriteLine(options[i].OptionComposition());
            }

            void ChangeCost()
            {
                while (true)
                {
                    ClearScreen();
                    Console.WriteLine("\nВведите порядковый номер авто");
                    nomerAvto = Convert.ToInt32(Console.ReadLine());
                    if (nomerAvto < 1 || nomerAvto > size)
                    {
                        Console.WriteLine("Неверный номер авто");
                        continue;
                    }
                    Console.WriteLine("Старая цена " + nomerAvto + "-й машины: " + cars[nomerAvto - 1].cost + "$ \nВведите новую цену ");
                    cars[nomerAvto - 1].cost = Convert.ToInt32(Console.ReadLine());
                    Console.ReadLine();
                    ClearScreen();
                    break;

                }
            }

            void Credit()
            {
                CreateCredit(cars[tempIndex - 1].cost);
                ClearScreen();
                Console.WriteLine($"\n{user}, для Вас есть три предложения по автокредиту:\n");
                for (int i = 0; i < 3; i++)
                {
                    Console.WriteLine(credits[i].CreditComposition());
                }
                while (true)
                {
                    Console.WriteLine("\nКакое предложение выбираете(1,2,3)?");
                    choice = Convert.ToInt32(Console.ReadLine());
                    if (choice >= 1 && choice <= 3) break;
                }
                Console.WriteLine("\nПроходите в " + (choice + 2) + " кабинет. Там находится представитель " + credits[choice - 1].bankName + "\nВтечение получаса мы подготовим Ваш автомобиль и выдадим его Вам. \nПоздравляем с покупкой!");

            }
            void ClearScreen() 
            {
                for (int i = 0; i < 30; i++) Console.WriteLine(" ");
            }

            CreateCatalogAvto();
            
            while (true)
            {
                Console.WriteLine("\nВведите Ваш статус \n администратор \n клиент \n СТОП ");
                user = Console.ReadLine();
                if (user.ToUpper() == "АДМИНИСТРАТОР" || user.ToUpper()=="ADMIN")
                {
                    user = "admin";
                    Console.WriteLine($"\nДобрый день, {user}!\nДля начала нажмите ENTER\n");
                    Console.ReadLine();
                    ClearScreen();
                    while (true)
                    {
                      
                        Console.WriteLine("Что необходимо сделать: \n 1 - Вывести на экран все имеющиеся авто на складе \n 2 - добавить авто в каталог \n 3 - изменить цену авто \n 4 - выход");
                        choice = Convert.ToInt32(Console.ReadLine());
                        
                        if (choice == 1) // печать всех авто
                        {
                            ClearScreen();
                            for (int i = 0; i < size; i++)
                            {
                                PrintAvto(i);
                            }
                            Console.ReadLine();
                        }

                        if (choice == 2) AddNewAvto();// добавить авто в каталог

                        if (choice == 3) ChangeCost();// изменить цену авто

                        if (choice == 4)
                        {
                            ClearScreen();
                            break;
                        }
                    }
                }

                if (user.ToUpper() == "КЛИЕНТ")
                {
                    Console.WriteLine("\nКак к Вам обращаться?");
                    user = Console.ReadLine();
                    Console.WriteLine($"Добрый день, {user}! \nДля начала нажмите ENTER");
                    Console.ReadLine();
                    ClearScreen();
                    while (true)
                    {
                        Console.WriteLine($"\n{user}, по какому параметру будем искать авто: \n 1 - марка авто \n 2 - год выпуска (2000-2021) \n 3 - мощность в л.с.(100-300) \n 4 - цвет \n 5 - выход");
                        choice = Convert.ToInt32(Console.ReadLine());
                        x = 0; // x - счетчик машин в выборе клиента
                        y = 0; // y - переменная для выхода из цикла проверки цвета
                        addCost = 0;
                        tempIndex = 0;
                        if (choice == 1) // поиск по марке
                        {
                            searchMarka = NewMarka();
                            ClearScreen();
                            for (int i = 0; i < size; i++)
                            {
                                if (searchMarka == cars[i].marka)
                                {
                                    // tempIndex - порядковый номер машины найденной клиентом в базе
                                    tempIndex = i+1;
                                    Console.WriteLine(cars[i].CarComposition(i+1));
                                    x++; // x - счетчик машин в выборе клиента
                                }
                            }
                           

                        }
                        if (choice == 2) // поиск по году выпуска
                        {
                            while (true)
                            {
                                Console.WriteLine("\nНужно ввести начало и конец интервала поиска. ");
                                yearEditionA = NewYearEdition();
                                yearEditionB = NewYearEdition();
                                if (yearEditionA > yearEditionB)
                                {
                                    Console.WriteLine("Неверный год выпуска. Введите заново");
                                    continue;
                                }
                                break;
                            }
                            ClearScreen();
                            for (int i = yearEditionA; i < yearEditionB + 1; i++)
                            {
                                for (int j = 0; j < size; j++)
                                {
                                    if (cars[j].yearEdition == i)
                                    {
                                        tempIndex = j + 1;
                                        Console.WriteLine(cars[j].CarComposition(j+1));
                                        x++; // x - счетчик машин в выборе клиента
                                    }
                                }
                            }
                            

                        }
                        if (choice == 3) // поиск по мощности
                        {
                            while (true)
                            {
                                Console.WriteLine("\nНужно ввести начало и конец интервала поиска. ");
                                powerA = NewPower();
                                powerB = NewPower();
                                if (powerA > powerB)
                                {
                                    Console.WriteLine("Неверно введена мощность. Попробуйте заново");
                                    continue;
                                }
                                break;
                            }
                            ClearScreen();
                            for (int i = powerA; i < powerB + 1; i++)
                            {
                                for (int j = 0; j < size; j++)
                                {
                                    if (cars[j].power == i)
                                    {
                                        tempIndex = j + 1;
                                        Console.WriteLine(cars[j].CarComposition(j+1));
                                        x++; // x - счетчик машин в выборе клиента
                                    }
                                }
                            }
                          

                        }
                        if (choice == 4) // поиск по цвету
                        {
                            searchColor = NewColor();
                            ClearScreen();    
                            for (int i = 0; i < size; i++)
                            {
                                if (cars[i].color == searchColor)
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
                                // choiseYN - выбор да/нет
                                choiseYN = Console.ReadLine();
                                if(choiseYN.ToUpper() == "ДА")
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
                                    ClearScreen();
                                    Console.WriteLine("\nНа выбранной Вами машине установлены колеса:");
                                    Console.WriteLine(wheels[tempIndex - 1].WheelComposition());
                                    Console.WriteLine("Будете менять (да/нет)?");
                                    choiseYN = Console.ReadLine();
                                    if (choiseYN.ToUpper() == "ДА")
                                    {
                                        Console.WriteLine("\nСтоимость изменения радиуса на один размер - 500$");
                                        newRadius = NewRadius();
                                        addCost += (newRadius - wheels[tempIndex-1].radius)*500; 
                                        wheels[tempIndex-1].radius = newRadius;
                                        cars[tempIndex - 1].cost += addCost;
                                        
                                        Console.WriteLine("\nСтоимость изменения типа диска - 1000$ ");
                                        newTypeDisk = NewTypeDisc();
                                        if (wheels[tempIndex - 1].typeDisk != newTypeDisk)
                                        {
                                        addCost += 1000; 
                                        wheels[tempIndex - 1].typeDisk = newTypeDisk;
                                        cars[tempIndex - 1].cost += addCost;
                                        }
                                        
                                        Console.WriteLine("\nСтоимость изменения типа резины - 1000$ ");
                                        newTypeTyre = NewTypeTyre();
                                        if (wheels[tempIndex - 1].typeTyre != newTypeTyre)
                                        {
                                        addCost += 1000; 
                                        wheels[tempIndex - 1].typeTyre = newTypeTyre;
                                        cars[tempIndex - 1].cost += addCost;
                                        }
                                       
                                    }
                                    ClearScreen();
                                    Console.WriteLine("\nОпции на выбранной Вами машине:");
                                    Console.WriteLine(options[tempIndex - 1].OptionComposition());
                                    Console.WriteLine("Будете менять (да/нет)?");
                                    choiseYN = Console.ReadLine();
                                    if (choiseYN.ToUpper() == "ДА")
                                    { 
                                         Console.WriteLine("\nИзменение наличия кондиционера - 500$");
                                         newConditioner = NewConditioner();
                                         if (options[tempIndex - 1].conditioner != newConditioner)
                                         addCost += 500; 
                                         options[tempIndex - 1].conditioner = newConditioner;
                                         cars[tempIndex - 1].cost += addCost;
                                        
                                         Console.WriteLine("\nИзменение наличия Зимнего пакета - 500$");
                                         newHeat = NewHeat();
                                         if (options[tempIndex - 1].heat != newHeat)
                                         {
                                         addCost += 500; 
                                         options[tempIndex - 1].heat = newHeat;
                                         cars[tempIndex - 1].cost += addCost;
                                         }
                                        
                                         Console.WriteLine("\nИзменение наличия навигация - 500$");
                                         newNavigation = NewNavigation();
                                         if (options[tempIndex - 1].navigation != newNavigation)
                                         {
                                         addCost += 500; 
                                         options[tempIndex - 1].navigation = newNavigation;
                                         cars[tempIndex - 1].cost += addCost;
                                         }
                                        
                                    }
                                    ClearScreen();
                                    Console.WriteLine("\nВаш итоговый автомобиль:");
                                    PrintAvto(tempIndex-1);
                                    Console.WriteLine($"\n{user}, укажите как будете брать авто: \n1 - за наличные \n2 - в кредит");
                                    choice = Convert.ToInt32(Console.ReadLine());
                                    if (choice == 1)
                                    {
                                        Console.WriteLine("\nПроходите в кассу, расплачивайтесь. \nВтечение получаса мы подготовим Ваш автомобиль и выдадим его Вам. \nПоздравляем с покупкой!");
                                    }
                                    else Credit();
                                    return;
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