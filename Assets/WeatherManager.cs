using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherManager : MonoBehaviour
{
    private RealWorldWeather rwWeather;

    private void Awake()
    {
        rwWeather = FindObjectOfType<RealWorldWeather>();
    }

    private void Start()
    {
        StartCoroutine(getWeatherevery5min());
    }

    IEnumerator getWeatherevery5min()
    {
        while (true)
        {
            rwWeather.GetRealWeather();
            yield return new WaitForSeconds(60 * 5);
        }
    }
}
