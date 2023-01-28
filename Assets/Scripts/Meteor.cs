using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public GameObject target;
    public bool deflected;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("goo");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && !deflected) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.01f);
        }
        else if (deflected) {
            transform.position = Vector3.MoveTowards(transform.position, -target.transform.position, 0.01f);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            GameObject.Destroy(target);
        }
        else if (collision.gameObject.tag == "Barrier") {
            deflected = true;
        }
        Debug.Log("COLLIDE");
    }
}
