using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Windows;

namespace TestTask {
	class Weather { 
		public string City { get; set; }
		public Days Day { get; set; }
		public double Temperature { get; set; }
		public double Humidity { get; set; }
		public int Pressure { get; set; }
		public double WindSpeed { get; set; }
		public string Main { get; set; }

		public Weather(string city, Days day) {
			City = city;
			Day = day;

			GetWeatherAsync();
		}

		private void GetWeatherAsync() {
			JToken token = null;

			try {
				WebRequest request = WebRequest.Create($"http://api.openweathermap.org/data/2.5/forecast?q={City}&appid=181c03e3317918d2edd707f820314b97&lang=ua");
				WebResponse response = request.GetResponse();
				string apiResponse;
				using (Stream stream = response.GetResponseStream()) {
					using (StreamReader reader = new StreamReader(stream)) {
						apiResponse = reader.ReadToEnd();
					}
				}
				response.Close();

				int date = Convert.ToInt32(JObject.Parse(apiResponse).SelectToken("list[0].dt")) + ((int) Day * 86400);

				int i = 0;

				while (token == null) {
					if (Convert.ToInt32(JObject.Parse(apiResponse).SelectToken($"list[{i}].dt")) == date) {
						token = JObject.Parse(apiResponse).SelectToken($"list[{i}]");
					}

					i++;
				}
			}
			catch (Exception ex) {
				MessageBox.Show(ex.Message);
			}

			Temperature = Convert.ToDouble(token.SelectToken("main.temp"));
			Humidity = Convert.ToDouble(token.SelectToken("main.humidity"));
			Pressure = Convert.ToInt32(token.SelectToken("main.pressure"));
			WindSpeed = Convert.ToDouble(token.SelectToken("wind.speed"));
			Main = token.SelectToken("weather[0].main").ToString();
		}
	}
}
