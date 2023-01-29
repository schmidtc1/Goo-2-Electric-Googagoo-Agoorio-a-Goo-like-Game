using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject heart1;
    public GameObject heart2;
    public int score;
    static public int attackScore;
    public int health;
    void OnMouseDown(Collider2D collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            health--;
            Destroy(collision.gameObject);
         }
        if(collision.gameObject.tag == "Goo")
        {
            score++;
            Destroy(collision.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        heart1.SetActive(true);
        heart2.SetActive(true);
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshPro scoreText_ = scoreText.gameObject.GetComponent<TextMeshPro>();
        scoreText_.text = score.ToString();
        if(health == 2)
        {
            heart1.gameObject.SetActive(false);
        }
        if(health == 1)
        {
            heart2.gameObject.SetActive(false);
        }
        if(health <= 0)
        {
            GetTotalScores.attackScore += score;
            SceneManager.LoadScene("AttackGameLose");
        }
    }
}
