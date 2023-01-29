using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetTotalScores : MonoBehaviour
{
    public static int healScore;
    public static int attackScore;
    public static int weakScore;
    public static int spellScore;

    Text stats;

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        stats.text = "Attack: " + attackScore + "\n" + 
            "Weaken: " + weakScore + "\n" + 
                "Heal: " + healScore + "\n" + 
                    "Spell: " + spellScore;
        
    }
}
