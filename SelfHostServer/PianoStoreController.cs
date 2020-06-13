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
					Description = (string)lcResult.Rows[0]["description"],
					PianoList = GetManufacturerPianos(name)
				};
			} else
			{
				return null;
			}
		}

		public List<ClsAllPianos> GetManufacturerPianos(string name)
		{
			Dictionary<string, Object> par = new Dictionary<string, object>();
			par.Add("Name", name);
			DataTable lcResult = ClsDBConnection.GetDataTable("SELECT * FROM piano WHERE manufacturerID = @Name", par);
			List<ClsAllPianos> lcPianos = new List<ClsAllPianos>();
			foreach(DataRow dr in lcResult.Rows)
			{
				lcPianos.Add(DataRow2AllPianos(dr));
			}
			return lcPianos;
		}

		public ClsAllPianos DataRow2AllPianos (DataRow dr)
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
			return lcPiano;
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

		// INSERT MANUFACTURER
		public string PostManufacturer (ClsManufacturer prManufacturer)
		{
			Dictionary<string, Object> par = new Dictionary<string, object>();
			par.Add("Name", prManufacturer.Name);
			par.Add("Description", prManufacturer.Description);
			try
			{
				int lcRecCount = ClsDBConnection.Execute("INSERT INTO manufacturer (manufacturerID, description) VALUES(@Name, @Description)", par);
				if (lcRecCount == 1)
				{
					return "Added manufacturer";
				}
				else
				{
					return "Unexected Manufacturer Insert Count: " + lcRecCount;
				}
			}
			catch (Exception ex)
			{
				return ex.GetBaseException().Message;
			}
		}

		// UPDATE MANUFACTURER
		public string PutManufacturer (ClsManufacturer prManufacturer)
		{
			Dictionary<string, Object> par = new Dictionary<string, object>();
			par.Add("Name", prManufacturer.Name);
			par.Add("Description", prManufacturer.Description);
			try
			{
				int lcRecCount = ClsDBConnection.Execute("UPDATE manufacturer SET description = @Description WHERE manufacturerID = @Name", par);
				if(lcRecCount == 1)
				{
					return "Changes saved successfully";
				} else
				{
					return "Unexpected Manufacturer Update Count: " + lcRecCount;
				}
			} catch (Exception ex)
			{
				return ex.GetBaseException().Message;
			}
		}

		public string DeleteManufacturer (string manufacturer)
		{
			Dictionary<string, Object> par = new Dictionary<string, object>();
			par.Add("Manufacturer", manufacturer);
			try
			{
				int lcRecCount = ClsDBConnection.Execute("DELETE FROM manufacturer WHERE manufacturerID = @Manufacturer", par);

				if(lcRecCount == 1)
				{
					return "Successfully deleted manufacturer";
				} else
				{
					return "Unexpected error, no items deleted";
				}
			} catch (Exception ex)
			{
				return ex.GetBaseException().Message;
			}
		}
	}
}
