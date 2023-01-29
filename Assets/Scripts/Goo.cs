using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goo : MonoBehaviour
{
    public GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Meteor") {
            Debug.Log("LOSER");
            manager.gameOver = true;
        }
    }
}
