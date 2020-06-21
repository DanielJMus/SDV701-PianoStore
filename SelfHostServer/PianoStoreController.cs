using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
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
			DataTable lcResult = ClsDBConnection.GetDataTable("SELECT * FROM piano WHERE manufacturerID = @Name AND instock = 1", par);
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
			lcPiano.ID = (int)dr["listingID"];
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
			DataTable lcResult = ClsDBConnection.GetDataTable("SELECT * from piano WHERE manufacturerID = @Manufacturer AND instock = 1", par);
			List<ClsAllPianos> lcPianos = new List<ClsAllPianos>();
			if(lcResult.Rows.Count > 0)
			{
				foreach (DataRow dr in lcResult.Rows)
				{
					ClsAllPianos lcPiano = new ClsAllPianos();
					lcPiano.ID = (int)dr["listingID"];
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
				return "Error, manufacturer could not be deleted, perhaps orders are still open for it?";
			}
		}

		// GET PIANO

		public ClsAllPianos GetPiano(string ID)
		{
			Dictionary<string, Object> par = new Dictionary<string, object>(1);
			par.Add("ID", ID);
			DataTable lcResult = ClsDBConnection.GetDataTable("SELECT * from piano WHERE listingID = @ID", par);
			if (lcResult.Rows.Count > 0)
			{
				DataRow row = lcResult.Rows[0];
				ClsAllPianos lcPiano = new ClsAllPianos();
				lcPiano.ID = (int)row["listingID"];
				lcPiano.Name = (string)row["name"];
				lcPiano.Description = (string)row["description"];
				lcPiano.Finish = row["finish"] is DBNull ? null : (string)row["finish"];
				lcPiano.Stand = row["stand"] is DBNull ? null : (string)row["stand"];
				lcPiano.Price = (decimal)row["price"];
				lcPiano.Keys = (int)row["keys"];
				lcPiano.Voices = (int)row["voices"];
				lcPiano.Instock = (bool)row["instock"];
				lcPiano.Type = row["type"].ToString()[0];
				lcPiano.Style = row["style"] is DBNull ? null : (string)row["style"];
				lcPiano.DateModified = (DateTime)row["dateModified"];
				lcPiano.ManufacturerID = (string)row["manufacturerID"];
				return lcPiano;
			}
			else
			{
				return null;
			}
		}

		public ClsAllPianos GetPianoInStock(string ID)
		{
			Dictionary<string, Object> par = new Dictionary<string, object>(1);
			par.Add("ID", ID);
			DataTable lcResult = ClsDBConnection.GetDataTable("SELECT * from piano WHERE listingID = @ID AND instock = 1", par);
			if (lcResult.Rows.Count > 0)
			{
				DataRow row = lcResult.Rows[0];
				ClsAllPianos lcPiano = new ClsAllPianos();
				lcPiano.ID = (int)row["listingID"];
				lcPiano.Name = (string)row["name"];
				lcPiano.Description = (string)row["description"];
				lcPiano.Finish = row["finish"] is DBNull ? null : (string)row["finish"];
				lcPiano.Stand = row["stand"] is DBNull ? null : (string)row["stand"];
				lcPiano.Price = (decimal)row["price"];
				lcPiano.Keys = (int)row["keys"];
				lcPiano.Voices = (int)row["voices"];
				lcPiano.Instock = (bool)row["instock"];
				lcPiano.Type = row["type"].ToString()[0];
				lcPiano.Style = row["style"] is DBNull ? null : (string)row["style"];
				lcPiano.DateModified = (DateTime)row["dateModified"];
				lcPiano.ManufacturerID = (string)row["manufacturerID"];
				return lcPiano;
			}
			else
			{
				return null;
			}
		}

		// INSERT PIANO
		public string PostPiano(ClsAllPianos prPiano)
		{
			Dictionary<string, Object> par = new Dictionary<string, object>();
			par.Add("Name", prPiano.Name);
			par.Add("Description", prPiano.Description);
			par.Add("Finish", prPiano.Finish);
			par.Add("Stand", prPiano.Stand);
			par.Add("Price", prPiano.Price);
			par.Add("Keys", prPiano.Keys);
			par.Add("Voices", prPiano.Voices);
			par.Add("InStock", prPiano.Instock);
			par.Add("Type", prPiano.Type);
			par.Add("Style", prPiano.Style);
			par.Add("DateModified", prPiano.DateModified);
			par.Add("ManufacturerID", prPiano.ManufacturerID);
			try
			{
				int lcRecCount = ClsDBConnection.Execute(
					"INSERT INTO piano (name, description, finish, stand, price, keys, voices, instock, type, style, dateModified, manufacturerID) " +
					"VALUES(@Name, @Description, @Finish, @Stand, @Price, @Keys, @Voices, @InStock, @Type, @Style, @DateModified, @ManufacturerID)", par);
				if (lcRecCount == 1)
				{
					return "Added piano listing";
				}
				else
				{
					return "Unexected Piano Insert Count: " + lcRecCount;
				}
			}
			catch (Exception ex)
			{
				return ex.GetBaseException().Message;
			}
		}

		// UPDATE PIANO
		public string PutPiano(ClsAllPianos prPiano)
		{
			Dictionary<string, Object> par = new Dictionary<string, object>();
			par.Add("ID", prPiano.ID);
			par.Add("Name", prPiano.Name);
			par.Add("Description", prPiano.Description);
			par.Add("Finish", prPiano.Finish);
			par.Add("Stand", prPiano.Stand);
			par.Add("Price", prPiano.Price);
			par.Add("Keys", prPiano.Keys);
			par.Add("Voices", prPiano.Voices);
			par.Add("InStock", prPiano.Instock);
			par.Add("Type", prPiano.Type);
			par.Add("Style", prPiano.Style);
			par.Add("DateModified", prPiano.DateModified);
			try
			{
				int lcRecCount = ClsDBConnection.Execute("UPDATE piano SET " +
					"name = @Name, " +
					"description = @Description, " +
					"finish = @Finish, " +
					"stand = @Stand, " +
					"price = @Price, " +
					"keys = @Keys, " +
					"voices = @Voices, " +
					"instock = @InStock, " +
					"type = @Type, " +
					"style = @Style, " +
					"dateModified = @DateModified " +
					"WHERE listingID = @ID", par);
				if (lcRecCount == 1)
				{
					return "Changes saved successfully";
				}
				else
				{
					return "Unexpected Piano Update Count: " + lcRecCount;
				}
			}
			catch (Exception ex)
			{
				return ex.GetBaseException().Message;
			}
		}

		public string DeletePiano(string ID)
		{
			Dictionary<string, Object> par = new Dictionary<string, object>();
			par.Add("ID", ID);
			try
			{
				int lcRecCount = ClsDBConnection.Execute("DELETE FROM piano WHERE listingID = @ID", par);

				if (lcRecCount == 1)
				{
					return "Successfully deleted piano";
				}
				else
				{
					return "Unexpected error, no items deleted";
				}
			}
			catch (Exception ex)
			{
				return "Cannot delete this item, it may be still referenced by other items in the system.";
			}
		}

		public List<ClsOrder> GetAllOrders()
		{
			Dictionary<string, Object> par = new Dictionary<string, object>(1);
			DataTable lcResult = ClsDBConnection.GetDataTable("SELECT * from orders", par);
			List<ClsOrder> lcOrders = new List<ClsOrder>();
			if (lcResult.Rows.Count > 0)
			{
				foreach (DataRow dr in lcResult.Rows)
				{
					ClsOrder lcOrder = new ClsOrder();
					lcOrder.ID = (int)dr["orderID"];
					lcOrder.Name = dr["customerName"] is DBNull ? null : (string)dr["customerName"];
					lcOrder.Email = dr["customerEmail"] is DBNull ? null : (string)dr["customerEmail"];
					lcOrder.Phone = dr["customerPhone"] is DBNull ? null : (string)dr["customerPhone"];
					lcOrder.Total = (decimal)dr["purchasePrice"];
					lcOrder.Date = (DateTime)dr["orderDate"];
					lcOrder.ProductID = (int)dr["listingID"];
					lcOrders.Add(lcOrder);
				}
				return lcOrders;
			}
			return null;
		}

		public string DeleteOrder(int ID)
		{
			Dictionary<string, Object> par = new Dictionary<string, object>();
			par.Add("ID", ID);
			try
			{
				int lcRecCount = ClsDBConnection.Execute("DELETE FROM orders WHERE orderID = @ID", par);

				if (lcRecCount == 1)
				{
					return "Successfully deleted order";
				}
				else
				{
					return "Unexpected error, no items deleted";
				}
			}
			catch (Exception ex)
			{
				return ex.GetBaseException().Message;
			}
		}

		// INSERT ORDER
		public string PostOrder(ClsOrder prOrder)
		{
			Dictionary<string, Object> par = new Dictionary<string, object>();
			par.Add("Name", prOrder.Name);
			par.Add("Email", prOrder.Email);
			par.Add("Phone", prOrder.Phone);
			par.Add("Total", prOrder.Total);
			par.Add("Date", prOrder.Date);
			par.Add("ProductID", prOrder.ProductID);
			try
			{
				int lcRecCount = ClsDBConnection.Execute(
					"INSERT INTO orders (customerName, customerEmail, customerPhone, purchasePrice, orderDate, listingID) " +
					"VALUES(@Name, @Email, @Phone, @Total, @Date, @ProductID)", par);
				if (lcRecCount == 1)
				{
					return "Order placed successfully!";
				}
				else
				{
					return "Unexected Order Insert Count: " + lcRecCount;
				}
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex.GetBaseException().Message);
				return ex.GetBaseException().Message;
			}
		}
	}
}
