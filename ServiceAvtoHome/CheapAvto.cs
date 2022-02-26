using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAvtoHome
{
    internal class CheapAvto:Avto
    {
        public event Action addAvto;

        public void StartAdd()
        {
            addAvto?.Invoke();
        }       
        
    }
}
