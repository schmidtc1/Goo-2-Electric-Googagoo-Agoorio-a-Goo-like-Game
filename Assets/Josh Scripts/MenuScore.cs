using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuScore : MonoBehaviour
{
    private TextMeshProUGUI scoreCounterText;

    // Start is called before the first frame update
    private void Awake()
    {
        scoreCounterText = GetComponent<TextMeshProUGUI>();
        scoreCounterText.text = "Score: " + Character.weakenScore;
    }

    // Update is called once per frame
    void Update()
    {
        //scoreCounterText.text = "Score: " + Character.score;
    }
}
