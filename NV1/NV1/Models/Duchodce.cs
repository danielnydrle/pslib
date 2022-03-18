using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV1.Models
{
    class Duchodce : Osoba
    {
        public Duchodce(int vek, PohlaviEnum pohlavi, string jmeno) : base(vek, pohlavi, jmeno)
        {
            Vek = vek;
            Pohlavi = pohlavi;
            Jmeno = jmeno;
        }

        public override string ToString()
        {
            return $"Duchodce {base.ToString()}";
        }
    }
}
