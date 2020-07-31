using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class StepCounterTest : MonoBehaviour
{
    public static IntegerControl score;
    [SerializeField] Text stepCount; 
    // Start is called before the first frame update
    void Start()
    {
        stepCount.text = "started";
        if (StepCounter.current != null)
        {
            if (!StepCounter.current.enabled)
            {
                InputSystem.EnableDevice(StepCounter.current);
                stepCount.text = "disabled";
            }
            else
            {
                stepCount.text = "enabled";
            }
            StepCounter.current.samplingFrequency=1;
        }
        else
        {
            enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        int val = StepCounter.current.stepCounter.ReadValue();
        stepCount.text = "Steps: " + val;
    }
}
