using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverLogic : MonoBehaviour
{
    public Text timerUI;
    int timeLeft = 10;
    public bool timerOn = false;


    // Start is called before the first frame update
    void Start()
    {
        timerOn = true;
        countDownTimer();
    }

    void countDownTimer()
    {
        if (timerOn)
        {
            if (timeLeft > 0)
            {
                timerUI.text = timeLeft.ToString();
                timeLeft--;
                Invoke("countDownTimer", 1.0f);
            }

            else
            {
                SceneManager.LoadScene("TimeOver", LoadSceneMode.Single);
                timerUI.text = "Game Over";
                timeLeft = 0;
                timerOn = false;
            }
        }
    }

}
