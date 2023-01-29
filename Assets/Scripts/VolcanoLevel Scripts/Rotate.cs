using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform orb;
    public float radius;
 
    private Transform pivot;
    public GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();
        pivot = orb.transform;
        transform.parent = pivot;
        transform.position += Vector3.up * radius;
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKey(KeyCode.Q)) {
        //     curAngle += 0.7f;
        // }
        // else if (Input.GetKey(KeyCode.E)) {
        //     curAngle -= 0.7f;
        // }
        if (!manager.gameOver) {
            Vector3 orbVector = Camera.main.WorldToScreenPoint(orb.position);
            orbVector = Input.mousePosition - orbVector;
            float angle = Mathf.Atan2(orbVector.y, orbVector.x) * Mathf.Rad2Deg;
    
            pivot.position = orb.position;
            pivot.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        }
    }
}
