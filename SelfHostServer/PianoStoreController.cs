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
		public List<string> GetManufacturerNames()
		{
			DataTable lcResult = ClsDBConnection.GetDataTable("SELECT manufacturerID FROM manufacturer", null);
			List<string> lcNames = new List<string>();
			foreach(DataRow dr in lcResult.Rows)
			{
				lcNames.Add((string)dr[0]);
			}
			return lcNames;
		}

		public ClsManufacturer GetManufacturer (string name)
		{
			Dictionary<string, Object> par = new Dictionary<string, object>(1);
			par.Add("Name", name);
			DataTable lcResult = ClsDBConnection.GetDataTable("SELECT * from manufacturer WHERE manufacturerID = @Name", par);
			if (lcResult.Rows.Count > 0)
			{
				return new ClsManufacturer()
				{
					Name = (string)lcResult.Rows[0]["manufacturerID"],
					Description = (string)lcResult.Rows[0]["description"]
				};
			} else
			{
				return null;
			}
		}

		public List<ClsAllPianos> GetAllPianos (string manufacturer)
		{
			Dictionary<string, Object> par = new Dictionary<string, object>(1);
			par.Add("Manufacturer", manufacturer);
			DataTable lcResult = ClsDBConnection.GetDataTable("SELECT * from piano WHERE manufacturerID = @Manufacturer", par);
			List<ClsAllPianos> lcPianos = new List<ClsAllPianos>();
			if(lcResult.Rows.Count > 0)
			{
				foreach (DataRow dr in lcResult.Rows)
				{
					ClsAllPianos lcPiano = new ClsAllPianos();
					lcPiano.Name = (string)dr["name"];
					lcPiano.Description = (string)dr["description"];
					lcPiano.Finish = dr["finish"] is DBNull ? null : (string)dr["finish"];
					lcPiano.Stand = dr["stand"] is DBNull ? null : (string)dr["stand"];
					lcPiano.Price = (decimal)dr["price"];
					lcPiano.Keys = (int)dr["keys"];
					lcPiano.Voices = (int)dr["voices"];
					lcPiano.Instock = (bool)dr["instock"];
					lcPiano.Type = dr["type"].ToString()[0];
					lcPiano.Style = dr["style"] is DBNull ? null : (string)dr["style"];
					lcPiano.DateModified = (DateTime)dr["dateModified"];
					lcPiano.ManufacturerID = (string)dr["manufacturerID"];
					lcPianos.Add(lcPiano);
				}
				return lcPianos;
			}
			return null;
		}
	}
}
