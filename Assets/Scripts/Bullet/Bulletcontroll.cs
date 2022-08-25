using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletcontroll : MonoBehaviour
{
    //bulletプレハブ
    public GameObject bullet;
    //弾が生成されるポジションを保有するゲームオブジェクト
    public GameObject bulletPos;
    //弾丸のスピード
    public float speed = 1500f;
    public AudioClip sound1;
    AudioSource audioSource;
    public float timeReset;
    private float time;

    void Start()
    {
        //Componentを取得
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
            //スペースが押されたとき
            if (Input.GetKey(KeyCode.Space))
            {
                //ballをインスタンス化して発射
                GameObject createdBullet = Instantiate(bullet) as GameObject;
                createdBullet.transform.position = bulletPos.transform.position;
                //発射ベクトル
                Vector3 force;
                //発射の向きと速度を決定
                force = bulletPos.transform.forward * speed;
                // Rigidbodyに力を加えて発射
                createdBullet.GetComponent<Rigidbody>().AddForce(force);
                //Debug.Log(force);
                //音(sound1)を鳴らす
                audioSource.PlayOneShot(sound1);
                time = 0;
            }
        }
    }
}