using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject meteor;
    public GameObject blob;
    public Camera cam;
    public int max;
    public int counter;
    public bool gameOver;
    public int score;
    public int lifetime;
    public float timer;
    public float spawnTime;
    // Start is called before the first frame update
    void Start()
    {
        meteor = (GameObject) Resources.Load("Meteor", typeof(GameObject));
        blob = (GameObject) Resources.Load("Blob", typeof(GameObject));
        cam = Camera.main;
        gameOver = false;
        max = 30;
        counter = 0;
        score = 0;
        lifetime = 8;
        timer = 0.0f;
        spawnTime = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        // spawn meteors between -12 and 9, below 5
        if (!gameOver) {
            timer += Time.deltaTime;
            if (timer >= spawnTime && !Input.GetKey(KeyCode.Space)) {
                if (counter < max && !gameOver) {
                    int x = Random.Range(0, 12);
                    int y = 13;
                    Instantiate(meteor, new Vector3(x, y, 0), Quaternion.identity);
                    x = Random.Range(0, 12);
                    Instantiate(meteor, new Vector3(x, y, 0), Quaternion.identity);
                    x = Random.Range(0, 12);
                    Instantiate(blob, new Vector3(x, y, 0), Quaternion.identity);
                    counter++;
                }
                timer = 0.0f;
            }
        }
        if (gameOver) {
            EndGame();
        }
    }

    public void EndGame() {
        SceneManager.LoadScene("EndVolcanoLevel");
    }
}
