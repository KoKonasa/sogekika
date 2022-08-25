using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    float fall_speed;
    public float speed_controll;
    public GameObject explosionPrefab;
    public int score;
    public int del_score;
    //public AudioClip sound1;
    //AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        this.fall_speed = speed_controll + speed_controll * Random.value;
        transform.rotation = Quaternion.Euler(-90, 0, 0);
        //Component���擾
        //audioSource = GetComponent<AudioSource>();
        //������O�ɃI�u�W�F�N�g���j�󂳂�Ă��܂��A�G�t�F�N�g�ɉ�������

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        //https://3dcg-school.pro/unity-object-move-beginner/#Addforce-2
        transform.Translate(0, 0, -fall_speed * Time.deltaTime, Space.World);


        if (transform.position.z > 20f || transform.position.z < -3f)
        {
            GameObject.Find("Canvas").GetComponent<UIController>().AddScore(del_score);
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider coll)
    {
        // �����G�t�F�N�g�𐶐�����	
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        //��(sound1)��炷
        //audioSource.PlayOneShot(sound1);
        GameObject.Find("Canvas").GetComponent<UIController>().AddScore(score);
        Destroy(coll.gameObject);
        Destroy(gameObject);

    }
}