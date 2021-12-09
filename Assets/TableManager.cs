using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;

public class TableManager : MonoBehaviour
{
    public List<TableForTwo> TablesForTwo;
    public List<TableForFour> TablesForFour;
    public List<TableForEight> TablesForEight;

    public bool badWeather;
    public bool liveMusic;

    public GameObject addGuestPanel;

    public TMP_InputField guestAmmount;

    private Queue<int> guestQueue;
    private Registry reg;

    private void Awake()
    {
        reg = FindObjectOfType<Registry>();
    }

    private void Start()
    {
        guestQueue = new Queue<int>();
    }

    public void ToggleAddGuestPanel()
    {
        addGuestPanel.SetActive(!addGuestPanel.activeSelf);
    }
    
    public void AddGuest()
    {
        bool allocated = false;
        if (Convert.ToInt32(guestAmmount.text) > 2 && Convert.ToInt32(guestAmmount.text) < 5)
        {
            foreach (var tb in TablesForFour)
            {
                if (tb.isAvailable && !allocated)
                {
                    tb.Occupy();
                    addGuestPanel.SetActive(false);
                    allocated = true;
                    break;
                }
            }

            foreach (var tb in TablesForEight)
            {
                if (tb.isAvailable && !allocated)
                {
                    tb.Occupy();
                    addGuestPanel.SetActive(false);
                    allocated = true;
                    break;
                }
            }

            if (!allocated)
            {
                addGuestPanel.SetActive(false);
                if (badWeather)
                {
                    if (liveMusic)
                    {
                        Debug.Log($"Restaurant full, it will take around {reg.avgTimeOnMusicAndBadWeather} minutes for a table to be available for your party");
                    }
                    else
                    {
                        Debug.Log($"Restaurant full, it will take around {reg.avgTimeOnBadWeather} minutes for a table to be available for your party");
                    }
                    
                }
                else if (liveMusic)
                {
                    Debug.Log($"Restaurant full, it will take around {reg.avgTimeOnMusic} minutes for a table to be available for your party");
                }
                else
                {
                    Debug.Log($"Restaurant full, it will take around {reg.avgTime} minutes for a table to be available for your party");
                }
                guestQueue.Enqueue(Convert.ToInt32(guestAmmount.text));
            }
        }
        else if (Convert.ToInt32(guestAmmount.text) > 4 && Convert.ToInt32(guestAmmount.text) < 9)
        {
            foreach (var tb in TablesForEight)
            {
                if (tb.isAvailable && !allocated)
                {
                    tb.Occupy();
                    addGuestPanel.SetActive(false);
                    allocated = true;
                    break;
                }
            }

            if (!allocated)
            {
                addGuestPanel.SetActive(false);
                if (badWeather)
                {
                    if (liveMusic)
                    {
                        Debug.Log($"Restaurant full, it will take around {reg.avgTimeOnMusicAndBadWeather} minutes for a table to be available for your party");
                    }
                    else
                    {
                        Debug.Log($"Restaurant full, it will take around {reg.avgTimeOnBadWeather} minutes for a table to be available for your party");
                    }
                    
                }
                else if (liveMusic)
                {
                    Debug.Log($"Restaurant full, it will take around {reg.avgTimeOnMusic} minutes for a table to be available for your party");
                }
                else
                {
                    Debug.Log($"Restaurant full, it will take around {reg.avgTime} minutes for a table to be available for your party");
                }
                guestQueue.Enqueue(Convert.ToInt32(guestAmmount.text));
            }
        }
        else if(Convert.ToInt32(guestAmmount.text) > 0 && Convert.ToInt32(guestAmmount.text) < 3)
        {
            foreach (var tb in TablesForTwo)
            {
                if (tb.isAvailable && !allocated)
                {
                    tb.Occupy();
                    addGuestPanel.SetActive(false);
                    allocated = true;
                    break;
                }
            }
            foreach (var tb in TablesForFour)
            {
                if (tb.isAvailable && !allocated)
                {
                    tb.Occupy();
                    addGuestPanel.SetActive(false);
                    allocated = true;
                    break;
                }
            }

            foreach (var tb in TablesForEight)
            {
                if (tb.isAvailable && !allocated)
                {
                    tb.Occupy();
                    addGuestPanel.SetActive(false);
                    allocated = true;
                    break;
                }
            }

            if (!allocated)
            {
                addGuestPanel.SetActive(false);
                if (badWeather)
                {
                    if (liveMusic)
                    {
                        Debug.Log($"Restaurant full, it will take around {reg.avgTimeOnMusicAndBadWeather} minutes for a table to be available for your party");
                    }
                    else
                    {
                        Debug.Log($"Restaurant full, it will take around {reg.avgTimeOnBadWeather} minutes for a table to be available for your party");
                    }
                    
                }
                else if (liveMusic)
                {
                    Debug.Log($"Restaurant full, it will take around {reg.avgTimeOnMusic} minutes for a table to be available for your party");
                }
                else
                {
                    Debug.Log($"Restaurant full, it will take around {reg.avgTime} minutes for a table to be available for your party");
                }
                guestQueue.Enqueue(Convert.ToInt32(guestAmmount.text));
            }
        }
        else if(Convert.ToInt32(guestAmmount.text) > 8 || Convert.ToInt32(guestAmmount.text) < 1)
        {
            Debug.Log("Guest number must be between 1 and 8");
        }
        else
        {
            addGuestPanel.SetActive(false);
            if (badWeather)
            {
                if (liveMusic)
                {
                    Debug.Log($"Restaurant full, it will take around {reg.avgTimeOnMusicAndBadWeather} minutes for a table to be available for your party");
                }
                else
                {
                    Debug.Log($"Restaurant full, it will take around {reg.avgTimeOnBadWeather} minutes for a table to be available for your party");
                }
                    
            }
            else if (liveMusic)
            {
                Debug.Log($"Restaurant full, it will take around {reg.avgTimeOnMusic} minutes for a table to be available for your party");
            }
            else
            {
                Debug.Log($"Restaurant full, it will take around {reg.avgTime} minutes for a table to be available for your party");
            }
            guestQueue.Enqueue(Convert.ToInt32(guestAmmount.text));
        }
        
    }

    public void AddGuestFromQueue()
    {
        if (guestQueue.Count < 1)
        {
            return;
        }
        int _guestAmmount = guestQueue.Dequeue();
        bool allocated = false;
        if (_guestAmmount > 2 && _guestAmmount < 5)
        {
            foreach (var tb in TablesForFour)
            {
                if (tb.isAvailable && !allocated)
                {
                    tb.Occupy();
                    addGuestPanel.SetActive(false);
                    allocated = true;
                    break;
                }
            }

            foreach (var tb in TablesForEight)
            {
                if (tb.isAvailable && !allocated)
                {
                    tb.Occupy();
                    addGuestPanel.SetActive(false);
                    allocated = true;
                    break;
                }
            }
        }
        else if (_guestAmmount > 4 && _guestAmmount < 9)
        {
            foreach (var tb in TablesForEight)
            {
                if (tb.isAvailable && !allocated)
                {
                    tb.Occupy();
                    addGuestPanel.SetActive(false);
                    allocated = true;
                    break;
                }
            }
        }
        else if(_guestAmmount > 0 && _guestAmmount < 3)
        {
            foreach (var tb in TablesForTwo)
            {
                if (tb.isAvailable && !allocated)
                {
                    tb.Occupy();
                    addGuestPanel.SetActive(false);
                    allocated = true;
                    break;
                }
            }
            foreach (var tb in TablesForFour)
            {
                if (tb.isAvailable && !allocated)
                {
                    tb.Occupy();
                    addGuestPanel.SetActive(false);
                    allocated = true;
                    break;
                }
            }

            foreach (var tb in TablesForEight)
            {
                if (tb.isAvailable && !allocated)
                {
                    tb.Occupy();
                    addGuestPanel.SetActive(false);
                    allocated = true;
                    break;
                }
            }
        }
    }
    
    public void CloseOutsideTables()
    {
        foreach (TableForTwo tb in TablesForTwo)
        {
            if (tb.isOutsude)
            {
                tb.Occupy();
            }
        }

        foreach (var tb in TablesForFour)
        {
            if (tb.isOutsude)
            {
                tb.Occupy();
            }
        }

        foreach (var tb in TablesForEight)
        {
            if (tb.isOutsude)
            {
                tb.Occupy();
            }
        }
    }
    public void OpenOutsideTables()
        {
            foreach (TableForTwo tb in TablesForTwo)
            {
                if (tb.isOutsude)
                {
                    tb.Unocuppy();
                }
            }

            foreach (var tb in TablesForFour)
            {
                if (tb.isOutsude)
                {
                    tb.Unocuppy();
                }
            }

            foreach (var tb in TablesForEight)
            {
                if (tb.isOutsude)
                {
                    tb.Unocuppy();
                }
            }
        }

    public void RegisterTime(int time)
    {
        if (badWeather)
        {
            if (liveMusic)
            {
                reg.registerBWM(time);
            }
            else
            {
                reg.registerBW(time);
            }
        }
        else if(liveMusic)
        {
            reg.registerM(time);
        }
        else
        {
            reg.registerNormal(time);
        }
    }
}
