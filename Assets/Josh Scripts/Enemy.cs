using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform targetDestination;
    GameObject targetGameobject;
    Character targetCharacter;
    [SerializeField] public float speed;
    public Sprite scientistLessVest;
    public Sprite scientistAlmostNoVest;
    public Sprite scientistNoMoreVest;

    Rigidbody2D rgdbd2d;

    [SerializeField] int hp = 4;
    [SerializeField] int damage = 1;

    // Start is called before the first frame update
    void Awake()
    {
        rgdbd2d = GetComponent<Rigidbody2D>();
        //targetGameobject = targetDestination.gameObject;
    }

    public void SetTarget(GameObject target)
    {
        targetGameobject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate() 
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        rgdbd2d.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameobject)
        {
            Attack();
        }
    }

    private void Attack()
    {
        //Debug.Log("Attack");
        if (targetCharacter == null)
        {
            targetCharacter = targetGameobject.GetComponent<Character>();
        }

        targetCharacter.TakeDamage(damage);
        
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        speed *= 0.6f;

        if (hp == 3) {
            gameObject.GetComponent<SpriteRenderer>().sprite = scientistLessVest;
        }
        else if (hp == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = scientistAlmostNoVest;
        }
        else if (hp == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = scientistNoMoreVest;
        }
        else if (hp < 1)
        {
            Destroy(gameObject);
            Character.weakenScore += 1;
        }
    }

}
