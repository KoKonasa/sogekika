using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TopManager : MonoBehaviour
{
    public AudioClip sound1;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound1);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            LoadManager.Load();
            SceneManager.LoadScene("ModeSelect");
        }
        
    }
}
