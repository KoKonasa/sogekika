using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;
using System.Linq;

public static class LoadManager
{
    public static void Load()
    {
        string saveFolderPath = Application.persistentDataPath + "/save";
        string saveFilePath = saveFolderPath + "/data.dat";


        if (!File.Exists(saveFilePath))
        {
            Debug.Log("No save data file.");
            SceneManager.LoadScene("DemoScene");
            return;
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Open(saveFilePath, FileMode.Open);

        // Input
        SaveData saveData = (SaveData)bf.Deserialize(file);



        // GameObject player = GameObject.FindGameObjectWithTag("Player");
        //GameManager.instance.playerPosition = saveData.playerPosition;
        GameManager.instance.bestscore1 = saveData.bestScore1;
        GameManager.instance.bestscore2 = saveData.bestScore2;
        GameManager.instance.bestscore3 = saveData.bestScore3;
 

        file.Close();
    }
}