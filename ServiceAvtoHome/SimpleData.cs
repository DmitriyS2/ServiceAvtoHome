using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAvtoHome
{
    internal static class SimpleData
    {
        public static string[] masMarka = { "FORD", "AUDI", "BMW", "OPEL", "MAZDA", "LADA", "MITSUBISHI", "NISSAN", "TOYOTA", "LEXUS", "FIAT", "RENAULT", "MERCEDES BENZ" };
        public static string[] masType = { "СЕДАН", "ХЭТЧБЕК", "УНИВЕРСАЛ", "КУПЕ", "SUV" };
        public static string[] masColor = { "БЕЛЫЙ", "ЧЕРНЫЙ", "СЕРЕБРИСТЫЙ", "КРАСНЫЙ", "СИНИЙ" };
        public static string[] masBank = { "СберБанк", "ВТБ", "АльфаБанк", "Тинькофф", "РайффайзенБанк", "АкБарсБанк" };
        public static List<Avto> cars = new List<Avto>();
        public static List<Wheel> wheels = new List<Wheel>();
        public static List<Option> options = new List<Option>();
        public static List<Credit> credits = new List<Credit>();
        private static Random rand = new Random();

        public static List<Avto> CreateCatalogAvto()
        {
            for (int i = 0; i < 10; i++)
            {
                cars.Add(new Avto { marka = masMarka[rand.Next(0, 12)], color = masColor[rand.Next(0, 4)], type = masType[rand.Next(0, 4)], yearEdition = rand.Next(2000, 2021), power = rand.Next(2, 6) * 50, cost = rand.Next(10, 30) * 1000 });
                wheels.Add(new Wheel { radius = 16, typeTyre = "ЛЕТО", typeDisk = "ШТАМП" });
                options.Add(new Option { conditioner = "НЕТ", heat = "НЕТ", navigation = "НЕТ" });
            }
            return cars;
        }

        public static List<Credit> CreateCredit(int cost)
        {
        for (int i=0; i<3;i++)
            {
                credits.Add(new Credit { totalCredit =0, bankName = masBank[rand.Next(0,5)], firstPayment = rand.Next(0,5), rate = rand.Next(5,10), sumCredit = 0,payment=0, periodCredit=rand.Next(1,3)});
                credits[i].sumCredit = cost*(10-credits[i].firstPayment)/10;
                credits[i].totalCredit = credits[i].sumCredit;
                for (int j = 1; j < credits[i].periodCredit; j++) credits[i].totalCredit = credits[i].totalCredit * (100 + credits[i].rate) / 100;
                credits[i].payment = credits[i].totalCredit / credits[i].periodCredit / 12;
            }
       
        return credits;
        }
        
    }
}
