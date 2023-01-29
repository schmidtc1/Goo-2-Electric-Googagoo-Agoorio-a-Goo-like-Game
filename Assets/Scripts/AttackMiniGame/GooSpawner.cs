using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GooSpawner : MonoBehaviour
{
    float minGravity = -0.5f;
    float maxGravity = -1.2f;
    float timeToSpawn = 3f;
    float timer = 0;
    public GameObject goo;
    public GameController gameController_;
    void CreateGoo()
    {
        GameObject newGoo = Instantiate(goo);
        newGoo.transform.position = this.transform.position;
        float offset = Random.Range(-10f, 10.0f);
        newGoo.transform.position = new Vector2(newGoo.transform.position.x + offset, newGoo.transform.position.y);
        ConstantForce2D gooForce = newGoo.GetComponent<ConstantForce2D>();
        timer = timeToSpawn;
        gooForce.force = new Vector2(0, Random.Range(minGravity,maxGravity));
        gooForce.torque = Random.Range(100, 350);
        gooScript temp = newGoo.gameObject.GetComponent<gooScript>();
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
        if(timer <= 0)
        {
            CreateGoo();
        }
    }
}
