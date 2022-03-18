using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV1.Models
{
    class Osoba
    {
        private int vek;
        public int Vek { get => vek; protected set => vek = value; }
        private PohlaviEnum pohlavi;
        public PohlaviEnum Pohlavi { get => pohlavi; protected set => pohlavi = value; }
        private string jmeno;
        public string Jmeno { get => jmeno; protected set => jmeno = value; }

        public Osoba(int vek, PohlaviEnum pohlavi, string jmeno)
        {
            Vek = vek;
            Pohlavi = pohlavi;
            Jmeno = jmeno;
        }

        public static Osoba? GetInstance(int vek, PohlaviEnum pohlavi, string jmeno)
        {
            switch (vek)
            {
                case < 0:
                    return null;
                case <= 7:
                    return Predskolak.Instance(vek, pohlavi, jmeno);
                case <= 19:
                    return Skolak.Instance(vek, pohlavi, jmeno);
                case <= 65:
                    return Pracujici.Instance(vek, pohlavi, jmeno);
                case > 65:
                    return new Duchodce(vek, pohlavi, jmeno);
                default:
                    return null;
            }
        }

        public Osoba Starnuti(int roky)
        {
            return new Osoba(Vek + roky, Pohlavi, Jmeno);
        }

        public override string ToString()
        {
            return $"{Pohlavi}: {Jmeno} ({Vek})";
        }
    }
}
