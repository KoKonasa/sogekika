using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//�K�v
using TMPro;


public class Timer_3 : MonoBehaviour
{
    //�@�g�[�^������
    private float totalTime = 0f;
    //�@���ԁi���j
    [SerializeField]
    private int minute;
    //�@���ԁi�b�j
    [SerializeField]
    private float seconds;
    //�@�O��Update���̕b��
    private float oldSeconds;
    GameObject timer;
    GameObject score_text;
    UIController UIController;
    GameObject retrybutton;
    GameObject modeselectbutton;
    GameObject sound;
    public enum ChatColor : uint
    {
        RED = 0xFF0000FF,// ��
        GRN = 0x00FF00FF,// ��
        BLR = 0x0000FFFF,// ��
    }
    // Start is called before the first frame update

    void Start()
    {
        totalTime = minute * 60 + seconds;
        oldSeconds = 0f;
        this.timer = GameObject.Find("Timer");
        this.score_text = GameObject.Find("Text");
        GameObject obj = GameObject.Find("Canvas");
        UIController = obj.GetComponent<UIController>();
        this.retrybutton = GameObject.Find("RetryButton");
        this.modeselectbutton = GameObject.Find("ModeSelectButton");
        retrybutton.SetActive(false);
        modeselectbutton.SetActive(false);
        this.sound = GameObject.Find("Canvas");
    }

    // Update is called once per frame
    void Update()
    {
        //�@��U�g�[�^���̐������Ԃ��v���G
        totalTime += Time.deltaTime;

        //�@�Đݒ�
        minute = (int)totalTime / 60;
        seconds = totalTime - minute * 60;

        //�@�^�C�}�[�\���pUI�e�L�X�g�Ɏ��Ԃ�\������
        if ((int)seconds != (int)oldSeconds)
        {
            //timerText.text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
            timer.GetComponent<TextMeshProUGUI>().text = minute.ToString("00") + ":" + ((int)seconds).ToString("00");
        }
        oldSeconds = seconds;
    }
    public void Mode3Score()
    {
        GameObject obj = GameObject.Find("Canvas");
        UIController = obj.GetComponent<UIController>();
        sound.GetComponent<Retry_ModeSelectButton>().enabled = true;
        retrybutton.SetActive(true);
        modeselectbutton.SetActive(true);
        //score_text.GetComponent<TextMeshProUGUI>().text = "Score" + UIController.score +"\n" + "Highscore" + GameManager.instance.bestscore1;
        //https://gametukurikata.com/program/stop
        Time.timeScale = 0f;
        if (UIController.score > GameManager.instance.bestscore3)
        {
        GameManager.instance.bestscore3 = UIController.score;
        //https://qiita.com/AllNight/items/eb91d73d29b19dd68a38
        //m_Message.text = $"<color=#{ChatColor.RED:X}>���b�Z�[�W</color>";
        //https://baba-s.hatenablog.com/entry/2018/08/17/090100
        score_text.GetComponent<TextMeshProUGUI>().text = "Score " + UIController.score + "\n" + "Highscore " + GameManager.instance.bestscore3 + "\n" + $"<color=#{ChatColor.RED:X}>High Score Updated</color>";
        SaveManager.Save();
        }
        else
        {
        score_text.GetComponent<TextMeshProUGUI>().text = "Score " + UIController.score + "\n" + "Highscore " + GameManager.instance.bestscore3;
        }
        
    }
    
}
