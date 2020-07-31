using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JsonScriptD : MonoBehaviour
{
    string filename = "data.json";
    string path;

    GameData gameData = new GameData();

    // Start is called before the first frame update
    void Start()
    {
        path = Application.persistentDataPath + "/" + filename;
        Debug.Log(path);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
            SaveData();

        if (Input.GetKeyDown(KeyCode.R))
            ReadData();
    }

    void SaveData()
    {
        string contents = JsonUtility.ToJson(gameData, true);
        System.IO.File.WriteAllText(path, contents);
    }

    void ReadData()
    {

    }
}
