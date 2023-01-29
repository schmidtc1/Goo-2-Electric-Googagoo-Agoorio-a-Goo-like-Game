using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhipWeapon : MonoBehaviour
{
    [SerializeField] float timeToAttack = 4f;
    float timer;
    bool facingRight = true;
    private Vector3 movementVectorWhip;

    [SerializeField] GameObject GooProjectileLeft;
    [SerializeField] GameObject GooProjectileRight;

    PlayerMove playerMove;
    [SerializeField] Vector2 whipAttackSize = new Vector2(1f, 1f);
    [SerializeField] int whipDamage = 1;

    // Start is called before the first frame update
    void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    // Update is called once per frame
    void Update()
    {
        movementVectorWhip.x = Input.GetAxisRaw("Horizontal");
        movementVectorWhip.y = Input.GetAxisRaw("Vertical");
        if (movementVectorWhip.x > 0 && !facingRight)
        {
            FlipWeapon();
        }
        if (movementVectorWhip.x < 0 && facingRight)
        {
            FlipWeapon();
        }

        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            Attack();
        }

    }

    private void Attack()
    {
        //Debug.Log("PEW");
        timer = timeToAttack;

        if (playerMove.lastHorizontalVector > 0)
        {
            GooProjectileRight.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(GooProjectileRight.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else {
            GooProjectileLeft.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(GooProjectileLeft.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            //Debug.Log(colliders[i].gameObject.name);
            Enemy e = colliders[i].GetComponent<Enemy>();
            if (e != null)
            {
                colliders[i].GetComponent<Enemy>().TakeDamage(whipDamage);
            }
        }
    }

    public void FlipWeapon()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
