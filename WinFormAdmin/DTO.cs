﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormAdmin
{
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

		public static readonly string TYPE_PROMPT = "Enter A for Acoustic, or D for Digital.";

		public static ClsAllPianos AddPiano (char type)
		{
			return new ClsAllPianos()
			{
				Type = Char.ToUpper(type)
			};
		}

		public string GetTypeName ()
		{
			if (Char.ToUpper(Type) == 'D')
			{
				return "Digital";
			} else if (Char.ToUpper(Type) == 'A')
			{
				return "Acoustic";
			}
			return "Error";
		}
	}
}
