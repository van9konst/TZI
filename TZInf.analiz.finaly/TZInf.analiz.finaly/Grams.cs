using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TZInf.analiz.finaly
{
    class Grams
    {
        public string Name;
        public int Counted;
        public bool addStatus;
        public Grams(string n, int c)
        {
            Name = n;
            Counted = c;
            addStatus = false;
        }
    }
}
