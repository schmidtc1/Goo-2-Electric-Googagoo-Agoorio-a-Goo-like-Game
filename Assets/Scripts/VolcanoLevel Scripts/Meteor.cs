using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    private Rigidbody2D rb;
    public GameManager manager;
    public GameObject goo;
    public float speed;
    public Vector2 direction;
    public float timer;
    public float despawn;
    // Start is called before the first frame update
    void Start()
    {
        goo = GameObject.Find("goo");
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = GetComponent<Rigidbody2D>();
        direction = new Vector2(Random.Range(-3, 3), 2.8f);
        speed = 0.006f;
        timer = 0.0f;
        despawn = 7.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (!manager.gameOver && !Input.GetKey(KeyCode.Space)) {
            transform.Translate(direction * speed, Space.World);
        }
        else if (!manager.gameOver && Input.GetKey(KeyCode.Space)) {
            transform.position = Vector3.MoveTowards(transform.position, goo.transform.position, 0.02f);
        }
        if (timer >= despawn) {
            Destroy(gameObject);
            manager.counter--;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Barrier" || collision.gameObject.tag == "Blob") {
            Vector2 loc = transform.position;
            direction = Vector2.Reflect(direction, (loc - collision.contacts[0].point).normalized);
        }
        if (collision.gameObject.tag == "Player") {
            manager.gameOver = true;
            Debug.Log("LOSER");
        }
    }
}
