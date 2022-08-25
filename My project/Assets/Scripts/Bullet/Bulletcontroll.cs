using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletcontroll : MonoBehaviour
{
    //bullet�v���n�u
    public GameObject bullet;
    //�e�����������|�W�V������ۗL����Q�[���I�u�W�F�N�g
    public GameObject bulletPos;
    //�e�ۂ̃X�s�[�h
    public float speed = 1500f;
    public AudioClip sound1;
    AudioSource audioSource;
    public float timeReset;
    private float time;

    void Start()
    {
        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        time += Time.deltaTime;
        if (time > timeReset)
        {
            //�X�y�[�X�������ꂽ�Ƃ�
            if (Input.GetKey(KeyCode.Space))
            {
                //ball���C���X�^���X�����Ĕ���
                GameObject createdBullet = Instantiate(bullet) as GameObject;
                createdBullet.transform.position = bulletPos.transform.position;
                //���˃x�N�g��
                Vector3 force;
                //���˂̌����Ƒ��x������
                force = bulletPos.transform.forward * speed;
                // Rigidbody�ɗ͂������Ĕ���
                createdBullet.GetComponent<Rigidbody>().AddForce(force);
                //Debug.Log(force);
                //��(sound1)��炷
                audioSource.PlayOneShot(sound1);
                time = 0;
            }
        }
    }
}