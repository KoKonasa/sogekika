using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float life_time ;
    float time = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //��ʊO�̒e������
        if (transform.position.z > 6f || transform.position.z < -7f)
        {
            Destroy(gameObject);
        }
        //��莞�Ԃŏ���
        time += Time.deltaTime;
        if (time > life_time)
        {
            Destroy(gameObject);
        }
    }
}
