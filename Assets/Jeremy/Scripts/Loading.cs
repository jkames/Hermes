using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour
{

    public GameObject Image;

    float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        int sec = (int)timer % 60;

        if (sec > 6)
        {
            Image.SetActive(false);
        }
    }
}
