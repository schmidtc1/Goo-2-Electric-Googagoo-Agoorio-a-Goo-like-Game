using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    private Text scoreCounterText;

    // Start is called before the first frame update
    private void Awake()
    {
        scoreCounterText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreCounterText.text = "Score: " + Character.weakenScore;
    }
}
