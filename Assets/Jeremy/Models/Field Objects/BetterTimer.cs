using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BetterTimer : MonoBehaviour
{
    public static BetterTimer instance;

    public Text timeCounter;

    private TimeSpan timePlaying;
    private bool timerGoing;

    private float elapsedTime;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    private void Start()
    {
        timeCounter.text = "00:00:00";
        timerGoing = false;
    }

    public void startTimer()
    {
        timerGoing = true;
        elapsedTime = 0f;

        StartCoroutine(UpdateTimer());
    }

    public void EndTimer()
    {
        timerGoing = false;
    }

    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        { 
            elapsedTime += Time.deltaTime;
            timePlaying = TimeSpan.FromSeconds(elapsedTime);
            string timeExerStr =
                timePlaying.ToString("mm':'ss'.'ff");
            timeCounter.text = timeExerStr;

            //Debug.Log(timePlaying);

            yield return null;
        }
    }

    public void getTimeSpan(Text Target)
    {
        Target.text = timePlaying.ToString("mm':'ss'.'ff");
    }

}
