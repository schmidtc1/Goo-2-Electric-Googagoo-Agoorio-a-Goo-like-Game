using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NaturePlayerMove5 : MonoBehaviour
{
    [SerializeField] private GameObject goo;
    Rigidbody2D rgbd2d;
    [HideInInspector]
    public Vector3 movementVector;
    [HideInInspector]
    public float lastHorizontalVector;
    [HideInInspector]
    public float lastVerticalVector;


    [SerializeField] float speed = 3f;

    private void Awake()
    {
        rgbd2d = GetComponent<Rigidbody2D>();
        movementVector = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        movementVector.x = Input.GetAxisRaw("Horizontal");
        movementVector.y = movementVector.x / 2.2f;

        if (movementVector.x > 0) {
            Vector3 scaleChange = new Vector3(0.9998f,0.9998f,0f);
            goo.transform.localScale = Vector3.Scale(goo.transform.localScale, scaleChange);
            //goo.transform.localScale *= scaleChange;
            speed *= 0.99986f;
        }

        if (movementVector.x >= 0) 
        {
            movementVector *= speed;

            rgbd2d.velocity = movementVector;
        }

    }

}
