using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorBounce : MonoBehaviour
{
    public GameObject target;
    public bool deflected;

    public Rigidbody2D rb;
    Vector3 lastVelocity;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("goo");
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            GameObject.Destroy(target);
        }
        else if (collision.gameObject.tag == "Barrier") {
            deflected = true;
            float speed = lastVelocity.magnitude;
            Vector3 direction = Vector3.Reflect(lastVelocity.normalized, collision.contacts[0].normal);

            rb.velocity = direction * Mathf.Max(speed, 0f);
        }
        Debug.Log("COLLIDE");
    }
}
