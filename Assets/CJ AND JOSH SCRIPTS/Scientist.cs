using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scientist : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite one;
    public Sprite two;
    public Sprite three;
    public Sprite four;
    public Sprite five;

    public int maxHealth;
    public int currHealth;
    public int attack;
    public int maxAttack;
    public int num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(num == 1)
        {
            maxHealth = 50;
            maxAttack = 10;
            spriteRenderer.sprite = one;
        }
        if(num == 2)
        {
            maxHealth = 75;
            maxAttack = 15;
            spriteRenderer.sprite = two;
        }
        if (num == 3)
        {
            maxHealth = 100;
            maxAttack = 20;
            spriteRenderer.sprite = three;
        }
        if (num == 4)
        {
            maxHealth = 125;
            maxAttack = 25;
            spriteRenderer.sprite = four;
        }
        if(num == 5)
        {
            maxHealth = 150;
            maxAttack = 30;
            spriteRenderer.sprite = five;
        }
    }
}
