using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class Registry : MonoBehaviour
{
    /// <summary>
    /// N: Normal
    /// BW: Bad Weather
    /// M: Music
    /// BWM: Bad weather and music
    /// </summary>
    public List<int> timeDatadsetN;
    public List<int> timeDatadsetBW;
    public List<int> timeDatadsetM;
    public List<int> timeDatadsetBWM;
    
    
    public double avgTimeOnBadWeather;
    public double avgTimeOnMusic;
    public double avgTimeOnMusicAndBadWeather;
    public double avgTime;

    private void Awake()
    {
        //Normal
        if (PlayerPrefs.HasKey("timeRegistryN"))
        {
            var json = PlayerPrefs.GetString("timeRegistryN");
            timeDatadsetN = JsonUtility.FromJson<List<int>>(json);
            Debug.Log("Loaded");
            Debug.Log(json);
            avgTime = ListAvg(timeDatadsetN);
        }
        else
        {
            timeDatadsetN = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                timeDatadsetN.Add(Random.Range(30,40));
            }
            //PlayerPrefs.SetString("timeRegistryN", JsonUtility.ToJson(timeDatadsetN));
            avgTime = ListAvg(timeDatadsetN);
        }
        
        //Bad Weather
        if (PlayerPrefs.HasKey("timeRegistryBW"))
        {
            var json = PlayerPrefs.GetString("timeRegistryBW");
            timeDatadsetBW = JsonUtility.FromJson<List<int>>(json);
            Debug.Log("Loaded");
            Debug.Log(json);
            avgTimeOnBadWeather = ListAvg(timeDatadsetBW);
        }
        else
        {
            timeDatadsetBW = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                timeDatadsetBW.Add(Random.Range(35,50));
            }
            //PlayerPrefs.SetString("timeRegistryBW", JsonUtility.ToJson(timeDatadsetBW));
            avgTimeOnBadWeather = ListAvg(timeDatadsetBW);
        }
        
        //Bad Weather and Music
        if (PlayerPrefs.HasKey("timeRegistryBWM"))
        {
            var json = PlayerPrefs.GetString("timeRegistryBWM");
            timeDatadsetBWM = JsonUtility.FromJson<List<int>>(json);
            Debug.Log("Loaded");
            Debug.Log(json);    
            avgTimeOnMusicAndBadWeather = ListAvg(timeDatadsetBWM);
        }
        else
        {
            timeDatadsetBWM = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                timeDatadsetBWM.Add(Random.Range(35,50));
            }
            //PlayerPrefs.SetString("timeRegistryBWM", JsonUtility.ToJson(timeDatadsetBWM));
            avgTimeOnMusicAndBadWeather = ListAvg(timeDatadsetBWM);
        }
        
        //Music
        if (PlayerPrefs.HasKey("timeRegistryM"))
        {
            var json = PlayerPrefs.GetString("timeRegistryM");
            timeDatadsetM = JsonUtility.FromJson<List<int>>(json);
            Debug.Log("Loaded");
            Debug.Log(json);
            avgTimeOnMusic = ListAvg(timeDatadsetM);
        }
        else
        {
            timeDatadsetM = new List<int>();
            for (int i = 0; i < 100; i++)
            {
                timeDatadsetM.Add(Random.Range(45,65));
            }
            //PlayerPrefs.SetString("timeRegistryM", JsonUtility.ToJson(timeDatadsetM));
            avgTimeOnMusic = ListAvg(timeDatadsetM);
        }
        
        
    }

    public void registerNormal(int i)
    {
        
        timeDatadsetN.Add(i);
        //PlayerPrefs.SetString("timeRegistryN", JsonUtility.ToJson(timeDatadsetN));
        avgTime = ListAvg(timeDatadsetN);
    }

    public void registerBW(int i)
    {
        timeDatadsetBW.Add(i);
        //PlayerPrefs.SetString("timeRegistryBW", JsonUtility.ToJson(timeDatadsetBW));
        avgTime = ListAvg(timeDatadsetBW);
    }

    public void registerBWM(int i)
    {
        timeDatadsetBWM.Add(i);
        //PlayerPrefs.SetString("timeRegistryBWM", JsonUtility.ToJson(timeDatadsetBWM));
        avgTime = ListAvg(timeDatadsetBWM);
    }

    public void registerM(int i)
    {
        timeDatadsetM.Add(i);
        //PlayerPrefs.SetString("timeRegistryM", JsonUtility.ToJson(timeDatadsetM));
        avgTime = ListAvg(timeDatadsetM);
    }

    private double ListAvg(List<int> ls)
    {
        double avg = 0;
        avg = ls.Average();
        return avg;
    }
}
