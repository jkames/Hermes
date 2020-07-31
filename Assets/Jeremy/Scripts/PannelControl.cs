using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PannelControl : MonoBehaviour
{
    public GameObject Panel;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    //Testing method
    public void OpenPannel()
    {
        if(Panel != null)
        {
            Panel.transform.localScale = new Vector3(1, 
                (Panel.transform.localScale.y - 1)* -1, 1);
                

            //bool isActive = Panel.activeSelf;
            //Panel.SetActive(!isActive);
        }
    }
}
