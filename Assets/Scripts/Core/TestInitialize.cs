using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TestInitialize
{
    // �����̐ݒ�
    //https://gu-cho.com/entry/unity-screen-size/
    [RuntimeInitializeOnLoadMethod]
    static void OnRuntimeMethodLoad()
    {
        //Debug.Log("After Scene is loaded and game is running");
        // �X�N���[���T�C�Y�̎w��
        Screen.SetResolution(1440, 810, false);
    }
}