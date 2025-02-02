﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormAdmin
{
	public partial class frmOrders : Form
	{

		private static readonly frmOrders _instance = new frmOrders();
		public static frmOrders Instance
		{
			get { return _instance; }
		}


		public frmOrders()
		{
			InitializeComponent();
		}

		private void frmOrders_Load(object sender, EventArgs e)
		{
			
		}

		public static void Run()
		{
			Instance.Show();
			Instance.UpdateDisplay();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			frmManufacturers.Instance.Show();
			_instance.Hide();
		}

		public async void UpdateDisplay ()
		{
			List<ClsOrder> _orders = await ServiceClient.GetOrdersAsync();
			lstOrders.Items.Clear();
			decimal totalValue = 0;
			if(_orders != null)
			{
				foreach (ClsOrder lcOrder in _orders)
				{
					ClsAllPianos _piano = await ServiceClient.GetPianoAsync(lcOrder.ProductID);
					string[] columns = { lcOrder.ID.ToString(), lcOrder.Name, lcOrder.Email, lcOrder.Phone, _piano.Name.ToString(), lcOrder.Date.ToString(), "$" + lcOrder.Total };
					ListViewItem item = new ListViewItem(columns);
					lstOrders.Items.Add(item);
					totalValue += lcOrder.Total;
				}
			}
			lblTotal.Text = "Total Value: $" + totalValue.ToString();
			
		}

		private async void btnDelete_Click(object sender, EventArgs e)
		{
			if (lstOrders.SelectedItems.Count > 0)
			{
				int lcID = Convert.ToInt32(lstOrders.SelectedItems[0].Text);
				var confirmation = MessageBox.Show("Are you sure you want to delete this order?", "Confirm Deletion", MessageBoxButtons.YesNo);
				if (confirmation == DialogResult.Yes)
				{
					MessageBox.Show(await ServiceClient.DeleteOrderAsync(lcID));
					UpdateDisplay();
				}
			}
		}
	}
}
