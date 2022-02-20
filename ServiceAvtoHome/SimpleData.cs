namespace ServiceAvtoHome
{
    internal static class SimpleData
    {
        public static string? user, searchMarka, searchColor, newTypeDisk, newTypeTyre, newConditioner, newHeat, newNavigation, choiseYN, newLineParametr, searchParametr, newParametr;
        public static int choice, nomerAvto, counterCustomerAvto, borderA, borderB, tempIndex, newRadius, newNumberParametr;
        public static int size = 10;

        public static List<string> masMarka = new() { "FORD", "AUDI", "BMW", "OPEL", "MAZDA", "LADA", "MITSUBISHI", "NISSAN", "TOYOTA", "LEXUS", "FIAT", "RENAULT", "MERCEDES BENZ" };
        public static List<string> masType = new() { "СЕДАН", "ХЭТЧБЕК", "УНИВЕРСАЛ", "КУПЕ", "SUV" };
        public static List<string> masColor = new() { "БЕЛЫЙ", "ЧЕРНЫЙ", "СЕРЕБРИСТЫЙ", "КРАСНЫЙ", "СИНИЙ" };
        public static List<string> masYN = new() { "ДА", "НЕТ" };
        public static List<string> masDisk = new() { "ЛИТОЙ", "ШТАМП" };
        public static List<string> masTyre = new() { "ЗИМА", "ЛЕТО" };
        public static string[] masBank = { "СберБанк", "ВТБ", "АльфаБанк", "Тинькофф", "РайффайзенБанк", "АкБарсБанк" };
        public static string[] masPhrases =
        {
            "\nВведите марку авто (FORD, AUDI, BMW, OPEL, MAZDA, LADA, MITSUBISHI, NISSAN, TOYOTA, LEXUS, FIAT, RENAULT, MERCEDES BENZ)",//0
            "\nВведите тип кузова (Седан, Хэтчбек, Универсал, Купе, SUV)",
            "\nВведите год выпуска (в интервале 2000 - 2021)",
            "\nВведите цвет кузова (белый, черный, серебристый, красный, синий)",
            "\nВведите мощность (в интервале 100 - 300 л.с.)",
            "\nВведите цену (в интервале 10000 - 30000$)", //5
            "\nВведите радиус диска (в интервале 16 - 21)",
            "\nВведите тип диска (литой или штамп)",
            "\nВведите сезонность резины (зима или лето)",
            "\nВведите наличие кондиционера (да или нет)",
            "\nВведите наличие зимнего пакета (да или нет)",//10
            "\nВведите наличие навигации (да или нет)",
            "\nВведите порядковый номер авто",
            "\nВведите новую цену ",
            "\nКакое предложение выбираете(1,2,3)?",
            "\nУкажите как будете брать авто: \n1 - за наличные \n2 - в кредит",//15
            "\nДля Вас есть три предложения по автокредиту:\n",
            "\nВтечение получаса мы подготовим Ваш автомобиль и выдадим его Вам. \nПоздравляем с покупкой!",
            "\nПроходите в кассу, расплачивайтесь.",
            "\nДля продолжения нажмите любую клавишу",
            "Введите Ваш статус \n1 - администратор \n2 - клиент \n3 - СТОП ",//20
            "Что необходимо сделать: \n 1 - Вывести на экран все имеющиеся авто на складе \n 2 - добавить авто в каталог \n 3 - изменить цену авто \n 4 - выход",
            "\nКак к Вам обращаться?",
            "\nПо какому параметру будем искать авто: \n 1 - марка авто \n 2 - год выпуска (2000-2021) \n 3 - мощность в л.с.(100-300) \n 4 - цвет \n 5 - выход",
            "\nНужно ввести начало и конец интервала поиска. ",
            "\nНеверное значение. Введите заново", //25
            "\nК сожалению, у нас нет такой машины",
            "\nВы останавливаетесь на этом выборе(да/нет)? ",
            "\nНайдено несколько машин. Введите номер авто в базе, который Вы планируете брать",
            "\nНа выбранной Вами машине установлены колеса:",
            "\nСтоимость изменения радиуса на один размер - 500$",//30
            "\nСтоимость изменения типа диска - 1000$ ",
            "\nСтоимость изменения типа резины - 1000$ ",
            "\nОпции на выбранной Вами машине:",
            "\nИзменение наличия кондиционера - 500$",
            "\nИзменение наличия Зимнего пакета - 500$",//35
            "\nИзменение наличия навигации - 500$",
            "\nВаш итоговый автомобиль:",
            "\nДобавлена новая машина в каталог",

        };
        public static List<Avto> cars = new();
        public static List<Wheel> wheels = new();
        public static List<Option> options = new();
        public static List<Credit> credits = new();
        private static Random rand = new();

        public static List<Avto> CreateCatalogAvto()
        {
            for (int i = 0; i < size; i++)
            {
                cars.Add(new Avto { marka = masMarka[rand.Next(0, 12)], color = masColor[rand.Next(0, 4)], type = masType[rand.Next(0, 4)], yearEdition = rand.Next(2000, 2021), power = rand.Next(2, 6) * 50, cost = rand.Next(10, 30) * 1000 });
                wheels.Add(new Wheel { radius = 16, typeTyre = masTyre[1], typeDisk = masDisk[1] });
                options.Add(new Option { conditioner = masYN[1], heat = masYN[1], navigation = masYN[1] });
            }
            return cars;
        }

        public static List<Credit> CreateCredit(int cost)
        {
            for (int i = 0; i < 3; i++)
            {
                credits.Add(new Credit { totalCredit = 0, bankName = masBank[rand.Next(0, 5)], firstPayment = rand.Next(0, 5), rate = rand.Next(5, 10), sumCredit = 0, payment = 0, periodCredit = rand.Next(1, 3) });
                credits[i].sumCredit = cost * (10 - credits[i].firstPayment) / 10;
                credits[i].totalCredit = credits[i].sumCredit;
                for (int j = 1; j < credits[i].periodCredit; j++) credits[i].totalCredit = credits[i].totalCredit * (100 + credits[i].rate) / 100;
                credits[i].payment = credits[i].totalCredit / credits[i].periodCredit / 12;
            }

            return credits;
        }

    }
}
