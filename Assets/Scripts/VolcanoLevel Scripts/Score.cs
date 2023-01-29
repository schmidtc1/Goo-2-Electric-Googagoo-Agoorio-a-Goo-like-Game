using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public GameObject scoreUI;
    public TextMeshPro scoreCount;
    public bool timerOn = false;
    public GameManager manager;


    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        scoreCount = GameObject.Find("Score").GetComponent<TextMeshPro>();
        countDownTimer();
    }

    void countDownTimer()
    {
        if (!manager.gameOver)
        {
            scoreCount.text = "Score: " + manager.score.ToString();
            Invoke("countDownTimer", 1.0f);
        }
        else
        {
            scoreCount.text = "Final Score: " + manager.score.ToString();
        }
    }
}