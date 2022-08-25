using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Generate : MonoBehaviour
{
    public GameObject enemy1_prefab;
    public float generate_time;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("GenEnemy1", 1, generate_time);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void GenEnemy1()
    {
        Instantiate(enemy1_prefab, new Vector3(Random.Range(-5f, 5f), 0, 10), Quaternion.identity);
    }
}
