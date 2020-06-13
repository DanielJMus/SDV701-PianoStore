using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfHostServer
{

	public class ClsOrder
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public string Phone { get; set; }
		public int ProductID { get; set; }
		public DateTime Date { get; set; }
		public decimal Total { get; set; }
	}

	public class ClsManufacturer
	{
		public string Name { get; set; }
		public string Description { get; set; }

		public List<ClsAllPianos> PianoList { get; set; }
	}

	public class ClsAllPianos
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Finish { get; set; }
		public string Stand { get; set; }
		public decimal Price { get; set; }
		public int Keys { get; set; }
		public int Voices { get; set; }
		public bool Instock { get; set; }
		public char Type { get; set; }
		public string Style { get; set; }
		public DateTime DateModified { get; set; }
		public string ManufacturerID { get; set; }

		public static ClsAllPianos AddPiano(char type)
		{
			return new ClsAllPianos()
			{
				Type = Char.ToUpper(type)
			};
		}
	}
}
