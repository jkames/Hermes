﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON;
 
public class Weatheronly : MonoBehaviour
{
    [SerializeField] InputField myWeatherLabel;
 
    string Lat;
    string Long;
    string currentCity;
 
    //retrieved from weather API
    string retrievedCountry;
    string retrievedCity;
    int conditionID;
    string conditionName;
    string conditionImage;
 
 
    IEnumerator SendRequest()
    {
        
        //get the current weather
        WWW request = new WWW("http://api.openweathermap.org/data/2.5/weather?lat=" + Lat + "&lon=" + Long + "&appid=3acb838b17fdfccab5aa1b192c9b4e39"); //get our weather
        yield return request;
 
        if (request.error == null || request.error == "")
        {
            var N = JSON.Parse(request.text);
 
            retrievedCountry = N["sys"]["country"].Value; //get the country
            retrievedCity = N["name"].Value; //get the city
 
            string temp = N["main"]["temp"].Value; //get the temperature
            float tempTemp; //variable to hold the parsed temperature
            float.TryParse(temp, out tempTemp); //parse the temperature
            float finalTemp = Mathf.Round((tempTemp - 273.0f)*10)/10; //holds the actual converted temperature
 
            int.TryParse(N["weather"][0]["id"].Value, out conditionID); //get the current condition ID
            //conditionName = N["weather"][0]["main"].Value; //get the current condition Name
            conditionName = N["weather"][0]["description"].Value; //get the current condition Description
            conditionImage = N["weather"][0]["icon"].Value; //get the current condition Image

            //put all the retrieved stuff in the label

            myWeatherLabel.text =
                "" + conditionID;

        }
        else
        {
            Debug.Log("WWW error: " + request.error);
        }
    }
	
	public void trig(InputField Target){
		if(Target.text != "location services not enabled" && Target.text != "location services are initializing" && Target.text != "Waiting for location ...."){
            string[] tokens = Target.text.Split(',');
			Lat = tokens[1];
			Long = tokens[0];
			StartCoroutine(SendRequest());
		}
	}
}
 