using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeManager : MonoBehaviour
{
    private float currentScale = 1f;
    public float scaleSpeed = 5;
    float timer;
    [SerializeField] GameObject AnimationSprite;

    void Start()
    {
        AnimationSprite.SetActive(false);
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, 1, 1), Time.deltaTime * scaleSpeed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        currentScale *= 1.05f;

        ScoreScript.scoreValue += 50;
        GetTotalScores.healScore += 50;

        GameManagerG.instance.SpawnFood();

        Destroy(other.gameObject);

        timer = 0.5f;
        AnimationSprite.SetActive(true);


    }


    void Update()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(currentScale, currentScale, 1), 
        Time.deltaTime * scaleSpeed);
        
        timer -= Time.deltaTime;
        if (timer < 0f)
        { 
            AnimationSprite.SetActive(false);
        }

    }
}
