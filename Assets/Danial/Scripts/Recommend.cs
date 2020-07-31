using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Recommend : MonoBehaviour
{

    int lookback = 3;

    [SerializeField] InputField Summary;
    [SerializeField] InputField Recom;

    [SerializeField] Text label;
    [SerializeField] Text time;
    [SerializeField] Dropdown safety;

    [SerializeField] Text info;

    int currentTime = 0;
    int weather = 0;
    TimeSpan[] Arms = new TimeSpan[7];
    TimeSpan[] Legs = new TimeSpan[7];
    TimeSpan[] Core = new TimeSpan[7];

    public void save()
    {
        if (safety.interactable == false)
        {
            db.addRun(label.text, time.text);
            int today = (int)System.DateTime.Now.DayOfWeek;


            if(label.text == "Arms")
            {
                Arms[today] += TimeSpan.ParseExact(time.text, "mm':'ss'.'ff", null);
            }
            else if(label.text == "Legs")
            {
                Legs[today] += TimeSpan.ParseExact(time.text, "mm':'ss'.'ff", null);
            }
            else
            {
                Core[today] += TimeSpan.ParseExact(time.text, "mm':'ss'.'ff", null);
            }



            List<string> dead = new List<string>();

            for(int add = 1; add<8; add++)
            {
                dead.Add("'" + Arms[add % 7].ToString("mm'-'ss'.'ff") + "'");
                dead.Add("'" + Legs[add % 7].ToString("mm'-'ss'.'ff") + "'");
                dead.Add("'" + Core[add % 7].ToString("mm'-'ss'.'ff") + "'");
            }

           db.update(((int)System.DateTime.Now.DayOfWeek).ToString(),
                dead[0],dead[1],dead[2],
                dead[3], dead[4], dead[5],
                dead[6], dead[7], dead[8],
                dead[9], dead[10], dead[11],
                dead[12], dead[13], dead[14],
                dead[15], dead[16], dead[17],
                dead[18], dead[19], dead[20]);
            
            parse();
            rec();
        }
    }

    public void rec()
    {
        string settext = "";
        if (lookback > 6) lookback = 6;
        currentTime = System.DateTime.Now.Hour;
        int today = (int)System.DateTime.Now.DayOfWeek + 7;
        if (weather != 0)
        {
            TimeSpan[] all = { TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero };

            for(int x = 0; x < lookback; x++)
            {
                all[0] += Arms[(today - x) % 7];
                all[1] += Legs[(today - x) % 7];
                all[2] += Core[(today - x) % 7];
            }

            if (weather >= 800 && ((currentTime >= 6 && currentTime < 11)||(currentTime >= 13 && currentTime < 18)))
            {
                settext = "Current conditons seem perfect to exercise outside.";
            }
            else
            {
                settext = "Due to current conditions we suggest indoor exercise.";
            }

            string[] toName = { "Arms", "Legs", "Core" };


            TimeSpan min = all[0];
            int posmin = 0;

            for(int z = 1; z < all.Length; z++)
            {
                if(all[z]< min)
                {
                    min = all[z];
                    posmin = z;
                }
            }

            settext += "\nWe recommend you work out your " + toName[posmin] + ".\n ";
            Recom.text = settext;
        }
    }


    public void setWeather(InputField Source)
    {
        weather = System.Convert.ToInt32(Source.text);
        parse();
        rec();
    }


    public void parse()
    {
        string[] tokens = db.returnSum().Split(',');

        for (int i = 1; i < 7; i++)
        {
            Arms[i] = TimeSpan.ParseExact(tokens[i*3], "mm'-'ss'.'ff", null);
            Legs[i] = TimeSpan.ParseExact(tokens[1 + i*3], "mm'-'ss'.'ff", null);
            Core[i] = TimeSpan.ParseExact(tokens[2 + i*3], "mm'-'ss'.'ff", null);
        }

        Arms[0] = TimeSpan.ParseExact(tokens[21], "mm'-'ss'.'ff", null);
        Legs[0] = TimeSpan.ParseExact(tokens[22], "mm'-'ss'.'ff", null);
        Core[0] = TimeSpan.ParseExact(tokens[23], "mm'-'ss'.'ff", null);

        DateTime prev = DateTime.Parse(tokens[1]);

        DateTime here = System.DateTime.Now;

        TimeSpan diff = here - prev;

        int start = (int)DateTime.Now.DayOfWeek;


        if(prev.Day != here.Day && diff.Days < 1) {
            Arms[start] = TimeSpan.Zero;
            Legs[start] = TimeSpan.Zero;
            Core[start] = TimeSpan.Zero;
        }
        else
        {
            for (int j = diff.Days; j > 0; j--)
            {
                Arms[start] = TimeSpan.Zero;
                Legs[start] = TimeSpan.Zero;
                Core[start] = TimeSpan.Zero;
                start--;
                if (start == -1) start = 6;
            }
        }

        string[] Days = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"};

        string sendit = "Last workout date: " + tokens[1] +
            "\nDay of week: " + (System.DayOfWeek)System.Convert.ToInt32(tokens[2]);

        for (int k = 1; k < 8; k++)
        {
            sendit += "\n" + Days[k%7] + ": Arms-" + Arms[k % 7].ToString("mm':'ss'.'ff") + "  Legs-" + Legs[k % 7].ToString("mm':'ss'.'ff") + "  Core-" + Core[k % 7].ToString("mm':'ss'.'ff"); 
        }

        Summary.text = sendit + "\n";
    }
}
