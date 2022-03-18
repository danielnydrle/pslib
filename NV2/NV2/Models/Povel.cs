using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NV2.Models.Modul;

namespace NV2.Models
{
	internal class Povel //crate
	{
		public readonly ModulType Modul;
		public readonly int Cas;
		public readonly string Misto;

		public Povel(ModulType modul, int cas, string misto)
		{
			Modul = modul;
			Cas = cas;
			Misto = misto;
		}
	}
}
