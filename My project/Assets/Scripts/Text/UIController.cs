using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
	public int score = 0;
	GameObject scoreText;
	//private TextMeshProUGUI scoregui;

	public void AddScore(int score)
	{
		if (Mathf.Approximately(Time.timeScale, 0f))
		{
			return;
		}
		if (score > 0)
		{
			this.score += score;
		}
		else if (this.score + score >= 0)
        {
			this.score += score;
        }
	}

	void Start()
	{
		this.scoreText = GameObject.Find("Score");

	}

	void Update()
	{
		//scoregui.text = "Score:" + score;
		scoreText.GetComponent<TextMeshProUGUI>().text = "Score\n" + " " + score.ToString("0000"); 
	}

}