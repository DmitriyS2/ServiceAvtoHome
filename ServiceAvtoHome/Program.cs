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
                
        public static string NewParametr(string phrase, List<string>masLine)
        {
            while (true)
            {
                newLineParametr = MenuString(phrase);
                if (masLine.Contains(newLineParametr.ToUpper()) == true) return newLineParametr.ToUpper();
                else Console.WriteLine(masPhrases[25]);
            }
        }
                               
        public static int NewParametr(string phrase, int border1, int border2)
        {
            while (true)
            {
                newNumberParametr = MenuInt(phrase);
                if (newNumberParametr >= border1 && newNumberParametr <= border2) return newNumberParametr;
                else Console.WriteLine(masPhrases[25]);
            }
        }
        
        public static void AddNewAvto()
        {             
            Console.Clear();
            size++;
            cars.Add(new Avto { marka = NewParametr(masPhrases[0], masMarka), type = NewParametr(masPhrases[1], masType), color = NewParametr(masPhrases[3], masColor), power = NewParametr(masPhrases[4], 100, 300), yearEdition = NewParametr(masPhrases[2], 2000, 2021), cost = NewParametr(masPhrases[5], 10000, 30000) });
            wheels.Add(new Wheel { radius = NewParametr(masPhrases[6], 16, 21), typeDisk = NewParametr(masPhrases[7], masDisk), typeTyre = NewParametr(masPhrases[8], masTyre) });
            options.Add(new Option { conditioner = NewParametr(masPhrases[9], masYN), heat = NewParametr(masPhrases[10], masYN), navigation = NewParametr(masPhrases[11], masYN) });
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
                nomerAvto = NewParametr(masPhrases[12], 1, size);                
                PrintAvto(nomerAvto-1);
                cars[nomerAvto - 1].cost = NewParametr(masPhrases[5], 10000, 30000);
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
            choice = NewParametr(masPhrases[14], 1, 3);             
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
                borderA = NewParametr(phrase2, border1, border2);
                borderB = NewParametr(phrase2, border1, border2);
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

        public static void SearchIndex(string phrase1, ref int tempIndex)
        {
            while (true)
            {
                tempIndex = MenuInt(phrase1);
                if (tempIndex >= 1 && tempIndex <= size) return;
            }
        }


        public static void ChangeCarParametr(int add, string phrase1, string phrase2, List<string>masN, ref string parametr)
        {
            Console.WriteLine(phrase1);
            newTypeDisk = NewParametr(phrase2, masN);
            if (parametr != newTypeDisk) AddCost(add, ref parametr, newTypeDisk);
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
                            searchMarka = NewParametr(masPhrases[0], masMarka);
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
                            searchColor = NewParametr(masPhrases[3], masColor);
                            Console.Clear();    
                            for (int i = 0; i < size; i++) if (cars[i].color == searchColor) FindAvto(i, ref tempIndex, ref counterCustomerAvto);  
                        }
                        if(choice > 0 && choice<5)
                        {
                            if (counterCustomerAvto == 0) Console.WriteLine(masPhrases[26]);
                            else {                                
                                // choiseYN - выбор да/нет
                                choiseYN = NewParametr(masPhrases[27], masYN);
                                if(choiseYN == "ДА")
                                {
                                    if (counterCustomerAvto > 1) SearchIndex(masPhrases[28], ref tempIndex);     
                                    Console.Clear();
                                    Console.WriteLine(masPhrases[29]);
                                    Console.WriteLine(wheels[tempIndex - 1].WheelComposition());                                    
                                    choiseYN = NewParametr(masPhrases[27], masYN);
                                    if (choiseYN == "НЕТ")
                                    {
                                        Console.WriteLine(masPhrases[30]);
                                        newRadius = NewParametr(masPhrases[6], 16, 21);
                                        AddCost(((newRadius - wheels[tempIndex - 1].radius) * 500), ref wheels[tempIndex - 1].radius, newRadius);

                                        ChangeCarParametr(1000, masPhrases[31], masPhrases[7], masDisk, ref wheels[tempIndex - 1].typeDisk);                                                                              

                                        ChangeCarParametr(1000, masPhrases[32], masPhrases[8], masTyre, ref wheels[tempIndex - 1].typeTyre); 
                                    }
                                    Console.Clear();
                                    Console.WriteLine(masPhrases[33]);
                                    Console.WriteLine(options[tempIndex - 1].OptionComposition());
                                    choiseYN = NewParametr(masPhrases[27], masYN);
                                    if (choiseYN == "НЕТ")
                                    {
                                        ChangeCarParametr(500, masPhrases[34], masPhrases[9], masYN, ref options[tempIndex - 1].conditioner);
                                        ChangeCarParametr(500, masPhrases[35], masPhrases[10], masYN, ref options[tempIndex - 1].heat);
                                        ChangeCarParametr(500, masPhrases[36], masPhrases[11], masYN, ref options[tempIndex - 1].navigation);                                      
                                    }
                                    Console.Clear();
                                    Console.WriteLine(masPhrases[37]);
                                    PrintAvto(tempIndex-1);
                                    choice = NewParametr(masPhrases[15], 1, 2);                                    
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