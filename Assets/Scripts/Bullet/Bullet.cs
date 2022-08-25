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
        //‰æ–ÊŠO‚Ì’e‚ðÁ‚·
        if (transform.position.z > 6f || transform.position.z < -7f)
        {
            Destroy(gameObject);
        }
        //ˆê’èŽžŠÔ‚ÅÁ‚·
        time += Time.deltaTime;
        if (time > life_time)
        {
            Destroy(gameObject);
        }
    }
}
