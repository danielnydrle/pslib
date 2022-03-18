using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV4.Models
{
	internal class Prijimac
	{
		public Guid Id { get; set; }

		public Prijimac()
		{
			Id = Guid.NewGuid();
		}

		public void PrihlasSeKOdberu(string vysilacId, string typVysilani)
		{
			Smerovac.ZaregistrujPrijimacKOdberu(Id, vysilacId, typVysilani);
		}

		public void OdeberSeZOdberu(string vysilacId, string typVysilani)
		{
			Smerovac.OdeberPrijimacZOdberu(Id, vysilacId, typVysilani);
		}

		public void PrehrajZpravu()
		{
			Console.Write($"Prijimac {Id}\n\t ");
			Console.Write(Smerovac.ZiskejOdebiraneVysilaniPrijimace(Id) != null
				? $"{Smerovac.ZiskejOdebiraneVysilaniPrijimace(Id).ToString()}"
				: "Vysilani neni k dispozici."
			);
			Console.Write("\n\n");
		}
	}
}
