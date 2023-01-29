using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerG : MonoBehaviour
{

    public static GameManagerG instance;
    public GameObject[] foodPrefab; 
    public int selector = 0;


    public Vector2 xRange;
    public Vector2 yRange;


    void Awake() 
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 500; i++)
        {
            SpawnFood();
        }
    }

    public void SpawnFood()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(xRange.x, xRange.y), 
            Random.Range(yRange.x, yRange.y), 1);

        if (selector != 0)
        {
            selector--;
        }
        else
        {
            selector++;
        }
        GameObject _food = Instantiate (foodPrefab[selector], spawnPosition, Quaternion.identity);


    }
}
