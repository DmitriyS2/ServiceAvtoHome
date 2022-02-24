using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAvtoHome
{
    internal class Option
    {
        public string? conditioner; // кондиционер
        public string? heat; // подогрев
        public string? navigation; // навигация

        public string OptionComposition() => "\nКондиционер " + conditioner + "\nЗимний пакет " + heat + "\nСистема навигации " + navigation + "\n";
    }
}
