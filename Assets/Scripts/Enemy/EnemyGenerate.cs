using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerate : MonoBehaviour
{
    public GameObject box1;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public float generate_time;
    public float box_value;
    public float enemy1_value;
    public float enemy2_value;
    public float enemy3_value;

    public AudioClip sound1;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenEnemy", 1, generate_time);
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(sound1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenEnemy()
    {
        float value = Random.value;
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        if (value <= box_value)
        {
            Instantiate(box1, new Vector3(Random.Range(-5f, 5f), 0, 10), Quaternion.identity);
        }
        else if (value <= enemy1_value)
        {
            Instantiate(enemy1, new Vector3(Random.Range(-5f, 5f), 0, 10), Quaternion.identity);
        }
        else if (value <= enemy2_value)
        {
            Instantiate(enemy2, new Vector3(Random.Range(-5f, 5f), 0, 10), Quaternion.identity);
        }
        else
        {
            Instantiate(enemy3, new Vector3(Random.Range(-5f, 5f), 0, 10), Quaternion.identity);
        }
    }
}
