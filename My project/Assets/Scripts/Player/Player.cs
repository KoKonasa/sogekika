using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //回転速度
    [Range(0f, 9000f)] public float rotationSpeed = 1f;
    //左右方向の最大角度(左右対称のため最大のみ)
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
        //左矢印キーが押されたとき
        //https://qiita.com/yando/items/c406690c9ad87ecfc8e5
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //横左方向の角度の範囲を指定
            if (rotation_y < -max_rotation_y)
            {
                //範囲外のときreturnして処理させない
                return;
            }
            //現在の回転角度を変更
            rotation_y -= rotationSpeed * Time.deltaTime;
            //y軸を軸に左回りにrotationSpeed度回転
            transform.rotation = Quaternion.Euler(20, rotation_y, 0);
        }
        //右矢印キーが押されたとき
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //横右方向の角度の範囲を指定
            if (rotation_y > max_rotation_y)
            {
                //範囲外のときreturnして処理させない
                return;
            }
            //現在の回転角度を変更
            rotation_y += rotationSpeed * Time.deltaTime;
            //y軸を軸に左回りにrotationSpeed度回転
            transform.rotation = Quaternion.Euler(20, rotation_y, 0);
        }
    }
}
