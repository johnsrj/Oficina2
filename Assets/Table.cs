using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    public List<assento> assentos;
    public bool isOutsude;
    public bool isAvailable;
    private SpriteRenderer spriteRenderer;
    private TableManager tm;


    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Color.green;
        isAvailable = true;
        tm = FindObjectOfType<TableManager>();
    }

    public void Occupy()
    {
        isAvailable = false;
        spriteRenderer.color = Color.red;
        foreach (var seat in assentos)
        {
            seat.toggle.isOn = true;
        }
    }

    public void Unocuppy(int time)
    {
        isAvailable = true;
        spriteRenderer.color = Color.green;
        foreach (var seat in assentos)
        {
            seat.toggle.isOn = false;
        }

        tm.RegisterTime(time);
        tm.AddGuestFromQueue();
    }
    public void Unocuppy()
    {
        isAvailable = true;
        spriteRenderer.color = Color.green;
        foreach (var seat in assentos)
        {
            seat.toggle.isOn = false;
        }
        tm.AddGuestFromQueue();
    }
}
