using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WinFormAdmin
{
	public static class ServiceClient
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

		internal async static Task<List<ClsAllPianos>> GetAllPianosAsync (string prManufacturerName)
		{
			using (HttpClient lcHttpClient = new HttpClient())
			{
				return JsonConvert.DeserializeObject<List<ClsAllPianos>>(await lcHttpClient.GetStringAsync("http://localhost:60064/api/PianoStore/GetAllPianos?Manufacturer=" + prManufacturerName));
			}
		}

		private async static Task<string> InsertOrUpdateAsync<TItem>(TItem prItem, string prUrl, string prRequest)
		{ 
			using (HttpRequestMessage lcReqMessage = new HttpRequestMessage(new HttpMethod(prRequest), prUrl)) 
			using (lcReqMessage.Content = new StringContent(JsonConvert.SerializeObject(prItem), Encoding.UTF8, "application/json")) 
			using (HttpClient lcHttpClient = new HttpClient()) { 
				HttpResponseMessage lcRespMessage = await lcHttpClient.SendAsync(lcReqMessage); 
				return await lcRespMessage.Content.ReadAsStringAsync(); 
			} 
		}

		// INSERT
		internal async static Task<string> InsertManufacturerAsync(ClsManufacturer prManufacturer)
		{
			return await InsertOrUpdateAsync(prManufacturer, "http://localhost:60064/api/PianoStore/PostManufacturer", "POST");
		}

		// UPDATE
		internal async static Task<string> UpdateManufacturerAsync(ClsManufacturer prManufacturer)
		{
			return await InsertOrUpdateAsync(prManufacturer, "http://localhost:60064/api/PianoStore/PutManufacturer", "PUT");
		}

		// DELETE
		internal async static Task<string> DeleteManufacturerAsync(string prManufacturerName)
		{
			using (HttpClient lcHttpClient = new HttpClient())
			{
				HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync("http://localhost:60064/api/PianoStore/DeleteManufacturer?Manufacturer=" + prManufacturerName);
				return await lcRespMessage.Content.ReadAsStringAsync();
			}
		}

		// GET PIANO

		internal async static Task<ClsAllPianos> GetPianoAsync(int prID)
		{
			using (HttpClient lcHttpClient = new HttpClient())
			{
				return JsonConvert.DeserializeObject<ClsAllPianos>(await lcHttpClient.GetStringAsync("http://localhost:60064/api/PianoStore/GetPiano?ID=" + prID));
			}
		}

		// INSERT
		internal async static Task<string> InsertPianoAsync(ClsAllPianos prPiano)
		{
			return await InsertOrUpdateAsync(prPiano, "http://localhost:60064/api/PianoStore/PostPiano", "POST");
		}

		// UPDATE
		internal async static Task<string> UpdatePianoAsync(ClsAllPianos prPiano)
		{
			return await InsertOrUpdateAsync(prPiano, "http://localhost:60064/api/PianoStore/PutPiano", "PUT");
		}

		// DELETE
		internal async static Task<string> DeletePianoAsync(int prID)
		{
			using (HttpClient lcHttpClient = new HttpClient())
			{
				HttpResponseMessage lcRespMessage = await lcHttpClient.DeleteAsync("http://localhost:60064/api/PianoStore/DeletePiano?ID=" + prID);
				return await lcRespMessage.Content.ReadAsStringAsync();
			}
		}


	}
}
