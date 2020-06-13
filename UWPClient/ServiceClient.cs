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

		internal async static Task<ClsAllPianos> GetPianoAsync(int prID)
		{
			using (HttpClient lcHttpClient = new HttpClient())
			{
				return JsonConvert.DeserializeObject<ClsAllPianos>(await lcHttpClient.GetStringAsync("http://localhost:60064/api/PianoStore/GetPiano?ID=" + prID));
			}
		}

		private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
		{
			using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl))
			using (lcReqMessage.Content = new StringContent(JsonConvert.SerializeObject(prItem), Encoding.UTF8, "application/json"))
			using (HttpClient lcHttpClient = new HttpClient())
			{
				HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage);
				return await lcRespMessage.Content.ReadAsStringAsync();
			}
		}

		internal async static Task<string> InsertOrderAsync(ClsOrder prOrder)
		{
			return await InsertOrUpdateAsync(prOrder, "http://localhost:60064/api/PianoStore/PostOrder", "POST");
		}
	}
}
