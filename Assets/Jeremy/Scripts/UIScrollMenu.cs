using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollMenu : MonoBehaviour
{
    bool firstrun =  true;

    [SerializeField]
    private GameObject textTemplate;

    private List<GameObject> textItems;

    void Start()
    {
        textItems = new List<GameObject>();
    }

    public void LogText(string newTextString, Color newColor)
    {

        GameObject newPanel = Instantiate(textTemplate) as GameObject;
        newPanel.SetActive(true);
        Color bg;
        bg.a = 1;
        bg.r = 55;
        bg.g = 55;
        bg.b = 55;

        newPanel.GetComponent<Image>().color = bg;
        Text text = newPanel.GetComponentInChildren<Text>();
        text.text=newTextString;
        text.color = newColor;
        newPanel.transform.SetParent(textTemplate.transform.parent, false);

        textItems.Add(newPanel.gameObject);
    }

    public void SLogText()
    {
        if (firstrun)
        {
            List<string> myLogs = db.returnRun();

            Color myColor;
            myColor.a = 1;
            myColor.r = 52;
            myColor.g = 73;
            myColor.b = 94;

            if (myLogs.Count != 0)
            {
                foreach (string x in myLogs)
                {
                    LogText(x, myColor);
                }
            }
            firstrun = false;
        }
    }

    public void easyadd()
    {
        if (!firstrun)
        {
            string last = db.returnLast();

            Color myColor;
            myColor.a = 1;
            myColor.r = 52;
            myColor.g = 73;
            myColor.b = 94;
            LogText(last, myColor);
        }
    }

}
