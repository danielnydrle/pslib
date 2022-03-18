using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV1.Models
{
    internal class Skolak : Osoba
    {
        private static int MAX_INSTANCES_AMOUNT = 6;
        private static Skolak[] instances = new Skolak[MAX_INSTANCES_AMOUNT];

        public Skolak(int vek, PohlaviEnum pohlavi, string jmeno) : base(vek, pohlavi, jmeno)
        {
            instances.Append(this);
        }

        public static Skolak Instance(int vek, PohlaviEnum pohlavi, string jmeno)
        {
            if (instances.Length < MAX_INSTANCES_AMOUNT)
            {
                Skolak instance = new Skolak(vek, pohlavi, jmeno);
                instances.Append(instance);
                return instance;
            }

            return null;
        }

        public override string ToString()
        {
            return $"Skolak {base.ToString()}";
        }
    }
}
