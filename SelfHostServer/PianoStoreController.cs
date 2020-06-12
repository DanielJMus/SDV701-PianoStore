using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SelfHostServer
{
	public class PianoStoreController : System.Web.Http.ApiController
	{
		public List<string> GetManufacturers()
		{
			DataTable lcResult = ClsDBConnection.GetDataTable("SELECT manufacturerID FROM manufacturer", null);
			List<string> lcNames = new List<string>();
			foreach(DataRow dr in lcResult.Rows)
			{
				lcNames.Add((string)dr[0]);
			}
			return lcNames;
		}
	}
}
