using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    GameObject highscore_text;
    public AudioClip sound1;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        this.highscore_text = GameObject.Find("HighScoreText");
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound1);
    }

    // Update is called once per frame
    void Update()
    {
        highscore_text.GetComponent<TextMeshProUGUI>().text = GameManager.instance.bestscore1 + "\n" + GameManager.instance.bestscore2 + "\n" + GameManager.instance.bestscore3;
    }
}
