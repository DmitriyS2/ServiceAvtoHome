using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAvtoHome
{
    internal class Wheel // колесо
    {
        public int radius; // радиус диска
        public string? typeDisk; // тип диска - литье, штамп
        public string? typeTyre; // тип шины - зима,лето

        public string WheelComposition() => "Радиус диска " + radius + "\nТип диска " + typeDisk + "\nСезонность резины " + typeTyre;        
    }
}

