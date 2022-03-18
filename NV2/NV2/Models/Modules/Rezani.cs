using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NV2.Models.Modules
{
	internal class Rezani : Modul
	{
		public override string Nazev { get => "Rezani"; }

		protected override void VypisPraci()
		{
			Console.WriteLine("Rezani");
		}
	}
}
