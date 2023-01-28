using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordBox : MonoBehaviour
{
    string text;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("goo");
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null) {
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, 0.01f);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        // On Overlap (trigger): Do some thing to Goo
            // Destroy him/lose a life/end round
            
        GameObject.Destroy(target);
    }
}
