using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class assento : MonoBehaviour
{
    public Toggle toggle;
    public List<Toggle> otherSeats;
    [SerializeField] public Sprite lamp;
    private float helper;
    private Coroutine timeoutCoroutine;
    private TableManager tm;
    public Table tb;
    private void Awake()
    {
        toggle = GetComponent<Toggle>();
        tm = FindObjectOfType<TableManager>();
    }

    public void Occupy()
    {
        if (tb.isOutsude && tm.badWeather)
            return;
        
        if (toggle.isOn == true)
        {
            timeoutCoroutine = StartCoroutine(personDisocupyTimeout((Random.Range(20, 30) + (tm.badWeather ? 0:(Random.Range(3,10))) +(tm.liveMusic ? (Random.Range(0,10)):0) ) * 60));
        }
        else
        {
            StopCoroutine(timeoutCoroutine);
        }
    }

    public void uncoupy()
    {
        toggle.isOn = false;
    }

    private IEnumerator personDisocupyTimeout(int Time)
    {
        //Debug.Log($"This person will take {Time/60} minutes to eat and leave");
        yield return new WaitForSeconds(Time);
        tb.Unocuppy(Time);
    }

}
