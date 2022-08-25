using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    // https://youtu.be/JyrBl-06FAs?list=PLED8667EEZ9aB72WVMHfRHBd6oj9vplRy

    public static GameManager instance { get; private set; }
    // public static GameManager instance = null;  // 非推奨

    public int bestscore1 = 0;
    public int bestscore2 = 0;
    public int bestscore3 = 0;
    //シーン移動時の音はげーむマネージャーに置かない
    //dontdestroyonload
    //public AudioClip sound1;
    //AudioSource audioSource;

    private void Awake()
    {

        // GameManager: シーンが変わっても保持される singleton
        if (!GameManager.instance)
        {
            // 未生成
            GameManager.instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 生成済み
            Destroy(gameObject);
        }
        Time.timeScale = 1f;
 
    }
    //public void Start()
    //{
        //audioSource = GetComponent<AudioSource>();
        //audioSource.PlayOneShot(sound1);
    //}

    private void Update()
    {
        // If there is no save data file, save the game
        if (!File.Exists(Application.persistentDataPath + "/save/data.dat"))
        {
            SaveManager.Save();
            return;
        }

        // Press F1 to return to title 
        if (Input.GetKeyDown(KeyCode.F1))
        {
            // Load TitleScene.unity
            SceneManager.LoadScene("Top");
            return;
        }
        // Press ESC to quit the game
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            return;
        }
    }
}