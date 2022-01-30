using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAvtoHome
{
    internal class Avto
    {
        public string? color;
        public string? type;
        public int yearEdition;
        public int power;
        public int cost;
        public string? marka;
        public string KomponovkaCar()
        {
            return "\nМарка "+ marka + "\nЦвет " + color + "\nТип кузова " + type + "\nГод выпуска " + yearEdition + "\nМощность " + power + " л.с.\nЦена" + cost + " $";
        }
        
  
  
       


    }
}
