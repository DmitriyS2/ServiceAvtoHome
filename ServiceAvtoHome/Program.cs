using ServiceAvtoHome;
using System;
using static ServiceAvtoHome.SimpleData;

namespace ServiceAvtoHome
{
    class Program
    {
        public static int MenuInt(string menu)
        {
            Console.WriteLine(menu);
            return Convert.ToInt32(Console.ReadLine());
        }

        public static string MenuString(string menu)
        {
            Console.WriteLine(menu);
            return Console.ReadLine();
        }
                
        public static string NewLineParametr(string phrase, List<string>masLine)
        {
            while (true)
            {
                newLineParametr = MenuString(phrase);
                if (masLine.Contains(newLineParametr.ToUpper()) == true) return newLineParametr.ToUpper();
                else Console.WriteLine(masPhrases[25]);
            }
        }
                               
        public static int NewNumberParametr(string phrase, int border1, int border2)
        {
            while (true)
            {
                newNumberParametr = MenuInt(phrase);
                if (newNumberParametr >= border1 && newNumberParametr <= border2) return newNumberParametr;
            }
        }
        
        public static void AddNewAvto()
        {             
            Console.Clear();
            size++;
            cars.Add(new Avto { marka = NewLineParametr(masPhrases[0], masMarka), type = NewLineParametr(masPhrases[1], masType), color = NewLineParametr(masPhrases[3], masColor), power = NewNumberParametr(masPhrases[4], 100, 300), yearEdition = NewNumberParametr(masPhrases[2], 2000, 2021), cost = NewNumberParametr(masPhrases[5], 10000, 30000) });
            wheels.Add(new Wheel { radius = NewNumberParametr(masPhrases[6], 16, 21), typeDisk = NewLineParametr(masPhrases[7], masDisk), typeTyre = NewLineParametr(masPhrases[8], masTyre) });
            options.Add(new Option { conditioner = NewLineParametr(masPhrases[9], masYN), heat = NewLineParametr(masPhrases[10], masYN), navigation = NewLineParametr(masPhrases[11], masYN) });
            Console.WriteLine(masPhrases[38]);
            PrintAvto(size-1);            
            Pause();
        }

        public static void PrintAvto(int i)
        {
            Console.WriteLine(cars[i].CarComposition(i + 1));
            Console.WriteLine(wheels[i].WheelComposition());
            Console.WriteLine(options[i].OptionComposition());
        }

        public static void ChangeCost()
        {            
                Console.Clear();
                nomerAvto = NewNumberParametr(masPhrases[12], 1, size);                
                PrintAvto(nomerAvto-1);
                cars[nomerAvto - 1].cost = NewNumberParametr(masPhrases[5], 10000, 30000);
            Pause();             
        }

        public static void Credit()
        {
            CreateCredit(cars[tempIndex - 1].cost);
            Console.Clear();
            Console.WriteLine(masPhrases[16]);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(credits[i].CreditComposition());
            }            
            choice = NewNumberParametr(masPhrases[14], 1, 3);             
            Console.WriteLine(credits[0].CreditAnswer(choice) + masPhrases[17]);
            Pause();
        }

        public static void Pause(string? hello= null)
        {
            Console.WriteLine(hello);
            Console.WriteLine(masPhrases[19]);
            Console.ReadLine();
            Console.Clear();
        }

        public static void FindAvto(int i, ref int tempIndex, ref int counterCustomerAvto)
        {           
            tempIndex = i + 1;
            Console.WriteLine(cars[i].CarComposition(i + 1));
            counterCustomerAvto++;
            
        }

        public static void SearchCar (string phrase1, string phrase2, string phrase3, int border1, int border2)
        {
            while (true)
            {
                Console.WriteLine(phrase1);
                borderA = NewNumberParametr(phrase2, border1, border2);
                borderB = NewNumberParametr(phrase2, border1, border2);
                if (borderA > borderB)
                {
                    Console.WriteLine(phrase3);
                    continue;
                }
                break;
            }
            Console.Clear();            
        }

        public static void AddCost(int add, ref string oldN, string newN)
        {           
            oldN = newN;
            cars[tempIndex - 1].cost += add;
        }

        public static void AddCost(int add, ref int oldN, int newN)
        {            
            oldN = newN;
            cars[tempIndex - 1].cost += add;
        }

        public static void SearchMarkaColor(string phrase1, List<string>masN, ref string parametr)
        {
            searchParametr = NewLineParametr(phrase1, masN);
            Console.Clear();
            for (int i = 0; i < size; i++) if (parametr == searchParametr) FindAvto(i, ref tempIndex, ref counterCustomerAvto);
        }

        static void Main(string[] args)
        {
            CreateCatalogAvto();
            
            while (true)
            {
                Console.Clear();
                choice = MenuInt (masPhrases[20]);               
                if (choice==1) // admin
                {
                    user = "admin";                   
                    Pause($"\nДобрый день, {user}!");                    
                    while (true)
                    {
                        choice = MenuInt (masPhrases[21]);                                   
                        if (choice == 1) // печать всех авто
                        {
                            Console.Clear();
                            for (int i = 0; i < size; i++)
                            {
                                PrintAvto(i);
                            }
                            Pause();
                        }
                        if (choice == 2) AddNewAvto();// добавить авто в каталог
                        if (choice == 3) ChangeCost();// изменить цену авто
                        if (choice == 4)
                        {
                            Console.Clear();
                            break;
                        }
                    }
                }
                if (choice==2) // клиент
                {
                    user = MenuString(masPhrases[22]);                                  
                    Pause($"\nДобрый день, {user}!");
                    while (true)
                    {
                        choice = MenuInt (masPhrases[23]);                        
                        counterCustomerAvto = 0; // счетчик машин в выборе клиента                        
                        tempIndex = 0; // порядковый номер машины найденной клиентом в базе
                        if (choice == 1) // поиск по марке
                        {
                            searchMarka = NewLineParametr(masPhrases[0], masMarka);
                            Console.Clear();
                            for (int i = 0; i < size; i++) if (searchMarka == cars[i].marka) FindAvto(i, ref tempIndex, ref counterCustomerAvto);   
                        }
                        if (choice == 2) // поиск по году выпуска
                        {
                            SearchCar(masPhrases[24], masPhrases[2], masPhrases[25], 2000, 2021);
                            for (int i = borderA; i < borderB + 1; i++)
                            {
                                 for (int j = 0; j < size; j++) if (cars[j].yearEdition == i) FindAvto(j, ref tempIndex, ref counterCustomerAvto);  
                            }                           
                        }
                        if (choice == 3) // поиск по мощности
                        {
                            SearchCar(masPhrases[24], masPhrases[4], masPhrases[25], 100, 300);                          
                            for (int i = borderA; i < borderB + 1; i++)
                            {
                                for (int j = 0; j < size; j++) if (cars[j].power == i) FindAvto(j, ref tempIndex, ref counterCustomerAvto);
                            }                         
                        }
                        if (choice == 4) // поиск по цвету
                        {
                            searchColor = NewLineParametr(masPhrases[3], masColor);
                            Console.Clear();    
                            for (int i = 0; i < size; i++) if (cars[i].color == searchColor) FindAvto(i, ref tempIndex, ref counterCustomerAvto);  
                        }
                        if(choice > 0 && choice<5)
                        {
                            if (counterCustomerAvto == 0) Console.WriteLine(masPhrases[26]);
                            else {                                
                                // choiseYN - выбор да/нет
                                choiseYN = NewLineParametr(masPhrases[27], masYN);
                                if(choiseYN.ToUpper() == "ДА")
                                {
                                    if (counterCustomerAvto > 1)
                                    {
                                        while (true)
                                        {                                           
                                            tempIndex = MenuInt(masPhrases[28]);
                                            if (tempIndex >= 1 && tempIndex <= size) break;
                                        }
                                    }
                                    Console.Clear();
                                    Console.WriteLine(masPhrases[29]);
                                    Console.WriteLine(wheels[tempIndex - 1].WheelComposition());                                    
                                    choiseYN = NewLineParametr(masPhrases[27], masYN);
                                    if (choiseYN.ToUpper() == "НЕТ")
                                    {
                                        Console.WriteLine(masPhrases[30]);
                                        newRadius = NewNumberParametr(masPhrases[6], 16, 21);
                                        AddCost(((newRadius - wheels[tempIndex - 1].radius) * 500), ref wheels[tempIndex - 1].radius, newRadius);                                        
                                        
                                        Console.WriteLine(masPhrases[31]);
                                        newTypeDisk = NewLineParametr(masPhrases[7], masDisk);
                                        if (wheels[tempIndex - 1].typeDisk != newTypeDisk) AddCost(1000, ref wheels[tempIndex - 1].typeDisk, newTypeDisk);                                      
                                        
                                        Console.WriteLine(masPhrases[32]);
                                        newTypeTyre = NewLineParametr(masPhrases[8], masTyre);
                                        if (wheels[tempIndex - 1].typeTyre != newTypeTyre) AddCost(1000, ref wheels[tempIndex - 1].typeTyre, newTypeTyre);                                        
                                       
                                    }
                                    Console.Clear();
                                    Console.WriteLine(masPhrases[33]);
                                    Console.WriteLine(options[tempIndex - 1].OptionComposition());
                                    choiseYN = NewLineParametr(masPhrases[27], masYN);
                                    if (choiseYN.ToUpper() == "НЕТ")
                                    { 
                                         Console.WriteLine(masPhrases[34]);
                                         newConditioner = NewLineParametr(masPhrases[9], masYN);
                                         if (options[tempIndex - 1].conditioner != newConditioner) AddCost(500, ref options[tempIndex - 1].conditioner, newConditioner);                                        
                                        
                                         Console.WriteLine(masPhrases[35]);
                                         newHeat = NewLineParametr(masPhrases[10], masYN);
                                         if (options[tempIndex - 1].heat != newHeat) AddCost(500, ref options[tempIndex - 1].heat, newHeat);                                        
                                        
                                         Console.WriteLine(masPhrases[36]);
                                         newNavigation = NewLineParametr(masPhrases[11], masYN);
                                         if (options[tempIndex - 1].navigation != newNavigation) AddCost(500, ref options[tempIndex - 1].navigation, newNavigation);                                       
                                    }
                                    Console.Clear();
                                    Console.WriteLine(masPhrases[37]);
                                    PrintAvto(tempIndex-1);
                                    choice = NewNumberParametr(masPhrases[15], 1, 2);                                    
                                    if (choice == 1) Console.WriteLine(masPhrases[18]+masPhrases[17]);                           
                                    else Credit();
                                    return;
                                }
                            }
                        }
                        if (choice == 5) break;
                    }
                }
                if (choice==3) break;
            }
        }
    }
}