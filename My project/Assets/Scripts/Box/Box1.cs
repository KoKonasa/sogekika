using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box1 : MonoBehaviour
{

    float fall_speed;
    public float speed_controll;
    // Start is called before the first frame update
    void Start()
    {
        this.fall_speed = speed_controll + speed_controll * Random.value;

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        transform.Translate(0, 0, -fall_speed * Time.deltaTime, Space.World);

        if (transform.position.z > 20f || transform.position.z < -3f)
        {
            Destroy(gameObject);
        }
    }
}