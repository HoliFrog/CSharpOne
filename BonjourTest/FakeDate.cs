using Bonjour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BonjourTest
{
    class FakeDate : IDateTime
    {
        private DateTime data;
        public FakeDate(int year, int month, int day, int hour, int min, int sec)
        {
           this.data = new DateTime(year, month, day, hour, min, sec);
        }
        public DateTime date
        {
            get
            {
                return  data;
            }
            
}
    }
}
