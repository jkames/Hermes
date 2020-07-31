using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunLog : MonoBehaviour
{
    [SerializeField]
    private string myText;
    [SerializeField]
    private Color myColor;

    [SerializeField]
    public UIScrollMenu uiControl;

    public void LogText()
    {
        uiControl.LogText(myText, myColor);
    }
}
