using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

//https://qiita.com/2dgames_jp/items/b3d7d204895d67742d0c
public class ModeSelectButton : MonoBehaviour
{
    public GameObject[] buttonObjects = new GameObject[3];
    bool Mode1ButtonClicked = false, Mode2ButtonClicked = false, Mode3ButtonClicked = false;
    int index = -1;

    public AudioClip sound1;
    AudioSource audioSource;

    void Awake()
    {
        // Setup buttonObjects
        buttonObjects[0] = GameObject.Find("Mode1Button");
        buttonObjects[1] = GameObject.Find("Mode2Button");
        buttonObjects[2] = GameObject.Find("Mode3Button");
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        bool isPressedLeft = Input.GetKeyDown(KeyCode.UpArrow);
        bool isPressedRight = Input.GetKeyDown(KeyCode.DownArrow);
        // Left
        if (isPressedLeft && !isPressedRight)
        {
            index = index == -1 ? 0 : (index + 2) % 3;
            EventSystem.current.SetSelectedGameObject(buttonObjects[index]);
            audioSource.PlayOneShot(sound1);
        }
        // Right
        if (!isPressedLeft && isPressedRight)
        {
            index = index == -1 ? 0 : (index + 1) % 3;
            EventSystem.current.SetSelectedGameObject(buttonObjects[index]);
            audioSource.PlayOneShot(sound1);
        }
    }
    // Mode1
    public void OnClickMode1Button()
    {
        // Take precautions in case the button is pressed more than once.
        if (Mode1ButtonClicked) return;
        Mode1ButtonClicked = true;

        SceneManager.LoadScene("Mode1");
    }
    // Mode2
    public void OnClickMode2Button()
    {
        // Take precautions in case the button is pressed more than once.
        if (Mode2ButtonClicked) return;
        Mode2ButtonClicked = true;

        SceneManager.LoadScene("Mode2");
    }
    //Mode3
    public void OnClickMode3Button()
    {
        if (Mode3ButtonClicked) return;
        Mode3ButtonClicked = true;

        SceneManager.LoadScene("Mode3");
    }


}