using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAvtoHome
{
    internal class Avto
    {
        public static event Action<int> addAvto;

        public static void StartAdd(int N)
        {
            addAvto?.Invoke(N);
        }

        public string? color;
        public string? type;
        public int yearEdition;
        public int power;
        public int cost;
        public string? marka;

        public string CarComposition(int i) => "\nНомер авто в каталоге " + i + "\nМарка "+ marka + "\nЦвет " + color + "\nТип кузова " + type + "\nГод выпуска " + yearEdition + "\nМощность " + power + " л.с.\nЦена " + cost + "$";        
    }
}
