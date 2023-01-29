using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour
{
    float minGravity = -0.4f;
    float maxGravity = -1f;
    float timeToSpawn = 4.721f;
    float timer = 0;
    public GameObject bomb;
    public GameController gameController_;

    void CreateBomb()
    {
        GameObject newBomb = Instantiate(bomb);
        newBomb.transform.position = this.transform.position;
        float offset = Random.Range(-10f, 10.0f);
        newBomb.transform.position = new Vector2(newBomb.transform.position.x + offset, newBomb.transform.position.y);
        ConstantForce2D bombForce = newBomb.GetComponent<ConstantForce2D>();
        timer = timeToSpawn;
        bombForce.force = new Vector2(0, Random.Range(minGravity,maxGravity));
        bombForce.torque = Random.Range(100, 350);
        bombScript temp = newBomb.gameObject.GetComponent<bombScript>();
        temp.gameController = gameController_;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameController_ = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            CreateBomb();
        }
    }
}
