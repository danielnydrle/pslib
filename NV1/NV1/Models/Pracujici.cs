using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV1.Models
{
    class Pracujici : Osoba
    {
        public static List<Pracujici> instances = new List<Pracujici>();
        private Pracujici(int vek, PohlaviEnum pohlavi, string jmeno) : base(vek, pohlavi, jmeno)
        {
            Vek = vek;
            Pohlavi = pohlavi;
            Jmeno = jmeno;
        }

        public static Pracujici Instance(int vek, PohlaviEnum pohlavi, string jmeno)
        {
            Pracujici instance = instances.Single(p => p.Vek == vek && p.Pohlavi == pohlavi && p.Vek == vek);
            if (instance != null)
                return instance;
            instance = new Pracujici(vek, pohlavi, jmeno);
            instances.Add(instance);
            return instance;
        }

        public override string ToString()
        {
            return $"Pracujici {base.ToString()}";
        }
    }
}
