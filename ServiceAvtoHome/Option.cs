using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAvtoHome
{
    internal class Option
    {
        public bool conditioner; // кондиционер
        public bool heat; // подогрев
        public bool navigation; // навигация
        public string KomponovkaOption()
        {
            return "\nКондиционер " + conditioner + "\nЗимний пакет " + heat + "\nСистема навигации " + navigation + "\n";
        }
    }
}
