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
		public List<string> GetArtistNames()
		{
			DataTable lcResult = ClsDBConnection.GetDataTable("SELECT Name FROM Artist", null);
			List<string> lcNames = new List<string>();
			foreach(DataRow dr in lcResult.Rows)
			{
				lcNames.Add((string)dr[0]);
			}
			return lcNames;
		}
	}
}
