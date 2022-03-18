using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV1.Models
{
    class Predskolak : Osoba
    {
        private static Predskolak instance = null;
        private Predskolak(int vek, PohlaviEnum pohlavi, string jmeno) : base(vek, pohlavi, jmeno)
        {
            Vek = vek;
            Pohlavi = pohlavi;
            Jmeno = jmeno;
        }

        public static Predskolak Instance(int vek, PohlaviEnum pohlavi, string jmeno)
        {
            if (instance == null)
                instance = new Predskolak(vek, pohlavi, jmeno);
            return instance;
        }

        public override string ToString()
        {
            return $"Predskolak {base.ToString()}";
        }
    }
}
