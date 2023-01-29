using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] Vector2 spawnArea;
    [SerializeField] float spawnTimer;
    [SerializeField] GameObject player;
    Character playerCharacter;
    float speedMultiplier;

    float timer;

    private void Awake()
    {
        playerCharacter = player.GetComponent<Character>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <0f && GameObject.FindGameObjectsWithTag("Enemy").Length < 200) 
        {
            SpawnEnemy();
            timer = spawnTimer;
        }
        if(timer <0f && GameObject.FindGameObjectsWithTag("Enemy").Length >= 100) 
        {
            Debug.Log("100 Enemies reached");
        }
        //if (timer <0f)
        //{
        //    SpawnEnemy();
        //    timer = spawnTimer;
        //}
    }

    private void SpawnEnemy()
    {
        float pos_x = UnityEngine.Random.Range(player.transform.position.x - spawnArea.x, player.transform.position.x + spawnArea.x);
        float pos_y = UnityEngine.Random.Range(player.transform.position.y - spawnArea.y, player.transform.position.y + spawnArea.y);

        while (pos_x > player.transform.position.x - 5 && pos_x < player.transform.position.x + 5)
        {
            pos_x = UnityEngine.Random.Range(player.transform.position.x - spawnArea.x, player.transform.position.x + spawnArea.x);
        }
        while (pos_y > player.transform.position.y - 4 && pos_y < player.transform.position.y + 4)
        {
            pos_y = UnityEngine.Random.Range(player.transform.position.y - spawnArea.y, player.transform.position.y + spawnArea.y);
        }

        Vector3 position = new Vector3(
            //UnityEngine.Random.Range(player.transform.position.x - spawnArea.x, player.transform.position.x + spawnArea.x), 
            //UnityEngine.Random.Range(player.transform.position.y - spawnArea.y, player.transform.position.y + spawnArea.y), 
            pos_x, pos_y,
            0f);
        GameObject newEnemy = Instantiate(enemy);
        newEnemy.transform.position = position;
        newEnemy.GetComponent<Enemy>().SetTarget(player);
        newEnemy.GetComponent<Enemy>().speed *= 1 + speedMultiplier;
    }

    public void DifficultyUp()
    {
        spawnTimer *= 1 - ((float)Character.weakenScore / 50);
        speedMultiplier = (float)Character.weakenScore / 25;
    }

}
