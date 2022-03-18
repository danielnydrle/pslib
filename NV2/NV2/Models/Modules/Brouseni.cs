using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV2.Models.Modules
{
	internal class Brouseni : Modul
	{
		public override string Nazev { get => "Brouseni"; }

		protected override void VypisPraci()
		{
			Console.WriteLine("Brouseni");
		}
	}
}
