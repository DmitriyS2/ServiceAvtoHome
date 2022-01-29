using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAvtoHome
{
    internal class Avto
    {
        public string color;
        public string type;
        public int yearEdition;
        public string Print() 
        {
            return color + " " + type + " " + yearEdition;
        }
        
  
  
       


    }
}
