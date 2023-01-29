using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMove : MonoBehaviour
{
    Rigidbody2D rgbd2d;
    [HideInInspector]
    public Vector3 movementVector;
    bool facingRight = true;
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
        movementVector.y = Input.GetAxisRaw("Vertical");

        if (movementVector.x != 0) {
            lastHorizontalVector = movementVector.x;
        }
        if (movementVector.y != 0) {
            lastVerticalVector = movementVector.y;
        }

        movementVector *= speed;

        rgbd2d.velocity = movementVector;

        if (movementVector.x > 0 && !facingRight)
        {
            Flip();
        }
        if (movementVector.x < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
