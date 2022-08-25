using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //��]���x
    [Range(0f, 9000f)] public float rotationSpeed = 1f;
    //���E�����̍ő�p�x(���E�Ώ̂̂��ߍő�̂�)
    [Range(0f, 180f)] public float max_rotation_y = 180f;
    private float rotation_y = 0f;


    //public AudioClip sound1;
    //AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(20, 0, 0);
        //audioSource = GetComponent<AudioSource>();
        //audioSource.PlayOneShot(sound1);

    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f))
        {
            return;
        }
        //�����L�[�������ꂽ�Ƃ�
        //https://qiita.com/yando/items/c406690c9ad87ecfc8e5
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //���������̊p�x�͈̔͂��w��
            if (rotation_y < -max_rotation_y)
            {
                //�͈͊O�̂Ƃ�return���ď��������Ȃ�
                return;
            }
            //���݂̉�]�p�x��ύX
            rotation_y -= rotationSpeed * Time.deltaTime;
            //y�������ɍ�����rotationSpeed�x��]
            transform.rotation = Quaternion.Euler(20, rotation_y, 0);
        }
        //�E���L�[�������ꂽ�Ƃ�
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //���E�����̊p�x�͈̔͂��w��
            if (rotation_y > max_rotation_y)
            {
                //�͈͊O�̂Ƃ�return���ď��������Ȃ�
                return;
            }
            //���݂̉�]�p�x��ύX
            rotation_y += rotationSpeed * Time.deltaTime;
            //y�������ɍ�����rotationSpeed�x��]
            transform.rotation = Quaternion.Euler(20, rotation_y, 0);
        }
    }
}
