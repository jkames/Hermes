using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//using UnityEngine.UI; // This is so that it should find the Text component
using UnityEngine.Events; // This is so that you can extend the pointer handlers
using UnityEngine.EventSystems; // This is so that you can extend the pointer handlers

public class CusTimer : MonoBehaviour
{

    float timer;
    float seconds;
    float minutes;

    bool racing;

    [SerializeField] Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        racing = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (racing)
        { calculateTime(); }
    }

    void calculateTime()
    {
        timer += Time.deltaTime;
        seconds = (int)(timer % 60);
        minutes = (int)(timer / 60);

        timerText.text = minutes.ToString("00")+ ":" + seconds.ToString("00");
    }

    public void startTimer()
    {
        timer = 0;
        racing = true;
    }

    public void stopTimer()
    {
        racing = false;
    }

}
