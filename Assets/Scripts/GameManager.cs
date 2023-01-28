using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject meteor;
    public int max;
    public int counter;
    // Start is called before the first frame update
    void Start()
    {
        meteor = GameObject.Find("Meteor");
        max = 10;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // spawn meteors between -12 and 9, below 5
        int x = Random.Range(-11, 8);
        int y = 4;
        if (counter < max) {
            Instantiate(meteor);
            counter++;
        }

    }
}
