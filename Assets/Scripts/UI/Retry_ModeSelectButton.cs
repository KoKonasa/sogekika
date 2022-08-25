using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//https://qiita.com/2dgames_jp/items/b3d7d204895d67742d0c
public class Retry_ModeSelectButton : MonoBehaviour
{
    public GameObject[] buttonObjects = new GameObject[2];
    bool RetryButtonClicked = false, ModeSelectButtonClicked = false;
    int index = -1;

    public AudioClip sound1;
    AudioSource audioSource;

    void Awake()
    {
        // Setup buttonObjects
        buttonObjects[0] = GameObject.Find("RetryButton");
        buttonObjects[1] = GameObject.Find("ModeSelectButton");
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        bool isPressedLeft = Input.GetKeyDown(KeyCode.LeftArrow);
        bool isPressedRight = Input.GetKeyDown(KeyCode.RightArrow);
        // Left
        if (isPressedLeft && !isPressedRight)
        {
            index = index == -1 ? 0 : (index + 1) % 2;
            EventSystem.current.SetSelectedGameObject(buttonObjects[index]);
            audioSource.PlayOneShot(sound1);
        }
        // Right
        if (!isPressedLeft && isPressedRight)
        {
            index = index == -1 ? 0 : (index + 1) % 2;
            EventSystem.current.SetSelectedGameObject(buttonObjects[index]);
            audioSource.PlayOneShot(sound1);
        }
    }
    // Retry
    public void OnClickRetryButton()
    {
        // Take precautions in case the button is pressed more than once.
        if (RetryButtonClicked) return;
        RetryButtonClicked = true;

        // Delete save data file
        //File.Delete(Application.persistentDataPath + "/save/data.dat");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //SceneManager.LoadScene("Mode1");
    }
    // Mode Select
    public void OnClickModeSelectButton()
    {
        // Take precautions in case the button is pressed more than once.
        if (ModeSelectButtonClicked) return;
        ModeSelectButtonClicked = true;
        LoadManager.Load();
        SceneManager.LoadScene("ModeSelect");
    }
}
