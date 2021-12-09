using System;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RealWorldWeather : MonoBehaviour {

	/*
		In order to use this API, you need to register on the website.

		Source: https://openweathermap.org

		Request by city: api.openweathermap.org/data/2.5/weather?q={city id}&appid={your api key}
		Request by lat-long: api.openweathermap.org/data/2.5/weather?lat={lat}&lon={lon}&appid={your api key}

		Api response docs: https://openweathermap.org/current
	*/

	public string apiKey = "YOUR-API-KEY-GOES-HERE";

	public string city;
	public bool useLatLng = false;
	public string latitude;
	public string longitude;

	public Text weatherText;

	public void GetRealWeather () {
		string uri = "api.openweathermap.org/data/2.5/weather?";
		if (useLatLng) {
			uri += "lat=" + latitude + "&lon=" + longitude + "&appid=" + apiKey;
		} else {
			uri += "q=" + city + "&appid=" + apiKey;
		}
		StartCoroutine (GetWeatherCoroutine (uri));
	}

	// ReSharper disable Unity.PerformanceAnalysis
	IEnumerator GetWeatherCoroutine (string uri) {
		using (UnityWebRequest webRequest = UnityWebRequest.Get (uri)) {
			yield return webRequest.SendWebRequest ();
			if (webRequest.isNetworkError) {
				Debug.Log ("Web request error: " + webRequest.error);
			} else {
				ParseJson (webRequest.downloadHandler.text);
			}
		}
	}

	WeatherStatus ParseJson (string json) {
		WeatherStatus weather = new WeatherStatus ();
		try {
			dynamic obj = JObject.Parse (json);

			weather.weatherId = obj.weather[0].id;
			weather.main = obj.weather[0].main;
			weather.description = obj.weather[0].description;
			weather.temperature = obj.main.temp;
			weather.pressure = obj.main.pressure;
			weather.windSpeed = obj.wind.speed;
		} catch (Exception e) {
			Debug.Log (e.StackTrace);
		}
		
		Debug.Log ("Temp in °C: " + weather.Celsius ());
		Debug.Log ("Wind speed: " + weather.windSpeed);
		
		Debug.Log(weather.weatherId);
		Debug.Log(weather.main);
		Debug.Log(weather.description);

		weatherText.text = weather.main;
		if (weather.main == "Snow" || weather.main == "Rain" || weather.main == "Extreme")
		{
			FindObjectOfType<TableManager>().CloseOutsideTables();
			FindObjectOfType<TableManager>().badWeather = true;
		}
		else if (FindObjectOfType<TableManager>().badWeather)
		{
			FindObjectOfType<TableManager>().badWeather = false;
			FindObjectOfType<TableManager>().OpenOutsideTables();
		}

		return weather;
	}

}