using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using static UWPClient.DTO;

namespace UWPClient
{
	class ServiceClient
	{
		internal async static Task<List<string>> GetManufacturerNamesAsync()
		{
			using (HttpClient lcHttpClient = new HttpClient())
			{
				return JsonConvert.DeserializeObject<List<string>>(await lcHttpClient.GetStringAsync("http://localhost:60064/api/PianoStore/GetManufacturerNames/"));
			}
		}

		internal async static Task<ClsManufacturer> GetManufacturerAsync(string prManufacturerName)
		{
			using (HttpClient lcHttpClient = new HttpClient())
			{
				return JsonConvert.DeserializeObject<ClsManufacturer>(await lcHttpClient.GetStringAsync("http://localhost:60064/api/PianoStore/GetManufacturer?Name=" + prManufacturerName));
			}
		}

		internal async static Task<List<ClsAllPianos>> GetAllPianosAsync(string prManufacturerName)
		{
			using (HttpClient lcHttpClient = new HttpClient())
			{
				return JsonConvert.DeserializeObject<List<ClsAllPianos>>(await lcHttpClient.GetStringAsync("http://localhost:60064/api/PianoStore/GetAllPianos?Manufacturer=" + prManufacturerName));
			}
		}
	}
}
