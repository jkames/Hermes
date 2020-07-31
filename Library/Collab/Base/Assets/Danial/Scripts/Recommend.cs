using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recommend : MonoBehaviour
{
    [SerializeField] InputField Summary;
    int currentTime = 0;
    int weather = 0;
    string[] times;

    private void Start()
    {
        //string[] tokens = db.returnSum().Split(',');

        TimeSpan[] Arms = new TimeSpan[7];
        TimeSpan[] Legs = new TimeSpan[7];
        TimeSpan[] Core = new TimeSpan[7];

        for (int i = 0; i < 7; i++)
        {
            //Arms[i] = TimeSpan.Parse(tokens[3 + i]);
            //Legs[i] = TimeSpan.Parse(tokens[4 + i]);
            //Core[i] = TimeSpan.Parse(tokens[5 + i]);
        }


        //DateTime prev = DateTime.Parse(tokens[1]);

        //Debug.Log(prev);


        /*
                Summary.text = "Last workout date: " + tokens[1] + 
                    "\nDay of week: " + (System.DayOfWeek)System.Convert.ToInt32(tokens[2]) +
                    "\nMonday: Arms-" + tokens[3] + "  Legs-" + tokens[4] + "  Core-" + tokens[5] +
                    "\nMonday: Arms-" + tokens[3] + "  Legs-" + tokens[4] + "  Core-" + tokens[5] +
                    "\nMonday: Arms-" + tokens[3] + "  Legs-" + tokens[4] + "  Core-" + tokens[5] +
                    "\nMonday: Arms-" + tokens[3] + "  Legs-" + tokens[4] + "  Core-" + tokens[5] +
                    "\nMonday: Arms-" + tokens[3] + "  Legs-" + tokens[4] + "  Core-" + tokens[5] +
                    "\nMonday: Arms-" + tokens[3] + "  Legs-" + tokens[4] + "  Core-" + tokens[5] +
                    "\nMonday: Arms-" + tokens[3] + "  Legs-" + tokens[4] + "  Core-" + tokens[5] +
                    */
    }


    public void rec()
    {
        currentTime = System.DateTime.Now.Hour;
        Debug.Log(currentTime);
        Debug.Log(weather);
        Debug.Log(times);
        if (times != null)
        {

        }
    }


    public void setWeather(InputField Source)
    {
        weather = System.Convert.ToInt32(Source.text);
        rec();
    }
}
