using UnityEngine;
using UnityEngine.UI;
using System.Data;
using Mono.Data.Sqlite;
using System;
using System.IO;
using System.Collections.Generic;

public class db : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        makeRunTable();
        makeSumTable();
        //returnSum();
        //Debug.Log("datetime test: "+(int)DateTime.Now.DayOfWeek);
        //addRun("arms", "30");
        //List<string> info = returnRun();
        //Debug.Log("return run: " + info[0]);

    }

    void makeRunTable()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/rundb";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open();

        IDbCommand dbcmd;
        IDataReader reader;

        dbcmd = dbcon.CreateCommand();
        string q_createTable =
            "CREATE TABLE IF NOT EXISTS runs (runid INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, date DATE NOT NULL, type TEXT NOT NULL, time TEXT NOT NULL)";
        string deleteTable =
            "DROP TABLE runs";

        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();

        dbcon.Close();
    }

    void makeSumTable()
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/rundb";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open(); 
        
        IDbCommand dbcmd;
        IDataReader reader;
        

        dbcmd = dbcon.CreateCommand();
        string q_createTable = 
            "CREATE TABLE IF NOT EXISTS summary (sumid INTEGER PRIMARY KEY AUTOINCREMENT NOT NULL, last DATE NOT NULL, day INTEGER NOT NULL, monArms TEXT NOT NULL, monLegs TEXT NOT NULL, monCore TEXT NOT NULL, tuesArms TEXT NOT NULL, tuesLegs TEXT NOT NULL, tuesCore TEXT NOT NULL, wedArms TEXT NOT NULL, wedLegs TEXT NOT NULL, wedCore TEXT NOT NULL, thursArms TEXT NOT NULL, thursLegs TEXT NOT NULL, thursCore TEXT NOT NULL, friArms TEXT NOT NULL, friLegs TEXT NOT NULL, friCore TEXT NOT NULL, satArms TEXT NOT NULL, satLegs TEXT NOT NULL, satCore TEXT NOT NULL, sunArms TEXT NOT NULL, sunLegs TEXT NOT NULL, sunCore TEXT NOT NULL)";
        string deleteTable =
            "DROP TABLE summary";

        dbcmd.CommandText = q_createTable;
        reader = dbcmd.ExecuteReader();
        //addRun("legs", "40");
        IDbCommand cmnd = dbcon.CreateCommand();
        cmnd.CommandText = "INSERT INTO summary (last, day, monArms, monLegs, monCore, tuesArms, tuesLegs, tuesCore, wedArms, wedLegs, wedCore, thursArms, thursLegs, thursCore, friArms, friLegs, friCore, satArms, satLegs, satCore, sunArms, sunLegs, sunCore) VALUES ( date('now','localtime'), " + (int)DateTime.Now.DayOfWeek +",'00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00','00-00.00')";
        cmnd.ExecuteNonQuery();
        IDbCommand cmnd_read = dbcon.CreateCommand();
        string query ="SELECT * FROM summary";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();
        /*while (reader.Read()){
            Debug.Log("sid: " + reader[0].ToString());
            Debug.Log("last exercise: " + reader[1].ToString());
            Debug.Log("day: " + reader[2].ToString());
            Debug.Log("monlegs: " + reader[3].ToString());
        }
        */
        
        dbcon.Close();
    }

    public static List<string> returnRun()
    {
        List<string> ret = new List<string>();
        
        string connection = "URI=file:" + Application.persistentDataPath + "/rundb";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open(); 
        
        IDataReader reader;
        IDbCommand cmnd_read = dbcon.CreateCommand();
        string query ="SELECT * FROM runs";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();
        while (reader.Read())
        {
            ret.Add(reader[1].ToString() + "," + reader[2].ToString() + "," +
                  reader[3].ToString());
        }


        dbcon.Close();
        return ret;
    }

    public static string returnSum()
    {

        string ret = "";
        string connection = "URI=file:" + Application.persistentDataPath + "/rundb";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open(); 
        
        IDataReader reader;
        IDbCommand cmnd_read = dbcon.CreateCommand();
        string query ="SELECT * FROM summary WHERE sumid = 1";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();
        while (reader.Read())
        {
            ret = reader[0].ToString() + "," + reader[1].ToString() + "," + reader[2].ToString() + "," +
                  reader[3].ToString() + "," + reader[4].ToString() + "," + reader[5].ToString() + "," +
                  reader[6].ToString() + "," + reader[7].ToString() + "," + reader[8].ToString() + "," +
                  reader[9].ToString() + "," + reader[10].ToString() + "," + reader[11].ToString() + "," +
                  reader[12].ToString() + "," + reader[13].ToString() + "," + reader[14].ToString() + "," +
                  reader[15].ToString() + "," + reader[16].ToString() + "," + reader[17].ToString() + "," +
                  reader[18].ToString() + "," + reader[19].ToString() + "," + reader[20].ToString() + "," +
                  reader[21].ToString() + "," + reader[22].ToString() + "," + reader[23].ToString();
        }

        dbcon.Close();
        return ret;
    }

    public static void addRun(string rType, string rTime)
    {
        string connection = "URI=file:" + Application.persistentDataPath + "/rundb";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open(); 
        
        IDataReader reader;
        IDbCommand cmnd = dbcon.CreateCommand();
        cmnd.CommandText = "INSERT INTO runs (date, type, time) VALUES (datetime('now','localtime'), '"+rType+"', '"+rTime+"')";
        cmnd.ExecuteNonQuery();
        IDbCommand cmnd_read = dbcon.CreateCommand();
        string query ="SELECT * FROM runs";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();
        /*
        while (reader.Read()){
         Debug.Log("rid: " + reader[0].ToString());
         Debug.Log("date: " + reader[1].ToString());
         Debug.Log("type: " + reader[2].ToString());
         Debug.Log("time: " + reader[3].ToString());
        }
        */

        dbcon.Close();
    }

    public static void update(string day, string monArms, string monLegs, string monCore, string tuesArms, string tuesLegs, string tuesCore, string wedArms, string wedLegs, string wedCore, string thursArms, string thursLegs, string thursCore, string friArms, string friLegs, string friCore, string satArms, string satLegs, string satCore, string sunArms, string sunLegs, string sunCore)
    {

        
        string connection = "URI=file:" + Application.persistentDataPath + "/rundb";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open(); 

        IDataReader reader;
        IDbCommand cmnd_read = dbcon.CreateCommand();
        string query ="UPDATE summary SET last = datetime('now','localtime') WHERE sumid = 1";
        cmnd_read.CommandText = query; 
        reader = cmnd_read.ExecuteReader();
        reader.Close();
        dbcon.Close();
        dbcon.Open(); 
        
        cmnd_read = dbcon.CreateCommand();

        

        query ="UPDATE summary SET day = "+ day + ", monArms = "+monArms + ", monLegs = "+monLegs+", monCore ="+monCore+", tuesArms = "+
            tuesArms +", tuesLegs =" + tuesLegs + ", tuesCore =" + tuesCore + ", wedArms = " + wedArms + ", wedLegs = " + wedLegs +
            ", wedCore = " + wedCore + ", thursArms = " + thursArms + ", thursLegs = " + thursLegs + ", thursCore = " + thursCore +
            ", friArms = " + friArms + ", friLegs = " + friLegs + ", friCore = " + friCore + ", satArms = " + satArms + ", satLegs = " +
            satLegs + ", satCore = " + satCore + ", sunArms = " + sunArms + ", sunLegs = " + sunLegs + ", sunCore = " + sunCore +
            " WHERE sumid = 1";

        cmnd_read.CommandText = query; 
        reader = cmnd_read.ExecuteReader();
        dbcon.Close();
    }

    public static string returnLast()
    {
        string ret = "";
        string connection = "URI=file:" + Application.persistentDataPath + "/rundb";
        IDbConnection dbcon = new SqliteConnection(connection);
        dbcon.Open(); 
        
        IDataReader reader;
        IDbCommand cmnd_read = dbcon.CreateCommand();
        string query ="SELECT * FROM runs WHERE runid = (SELECT MAX(runid) FROM runs)";
        cmnd_read.CommandText = query;
        reader = cmnd_read.ExecuteReader();
        while (reader.Read())
        {
            ret = reader[0].ToString() + "," + reader[1].ToString() + "," + reader[2].ToString() + "," +
                  reader[3].ToString();
        }

        dbcon.Close();
        return ret; 
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
