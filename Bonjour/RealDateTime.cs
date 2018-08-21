using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bonjour
{
    class RealDateTime : IDateTime
    {
        public DateTime date
        {
            get
            {
                return DateTime.Now;
            }
        }
    }
}
