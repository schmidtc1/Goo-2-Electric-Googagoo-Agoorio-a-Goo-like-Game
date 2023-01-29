using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTimer : MonoBehaviour
{
    float timer;

    [SerializeField] GameObject AnimationSprite;

    // Start is called before the first frame update
    void Start()
    {
        AnimationSprite.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        timer = 2f;
        AnimationSprite.SetActive(true);

        timer -= Time.deltaTime;
        if (timer < 0f)
        { 
            AnimationSprite.SetActive(false);
        }
    }

}
