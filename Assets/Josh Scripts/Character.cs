using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character : MonoBehaviour
{
    [SerializeField] public int maxHp = 100;
    [SerializeField] public int currentHp = 100;
    [SerializeField] StatusBar hpBar;
    public static int weakenScore = 0;
    int currScore = 0;

    [SerializeField] EnemiesManager manager;

    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Debug.Log("GAME OVER");
        }

        hpBar.SetState(currentHp, maxHp);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currScore != weakenScore)
        {
            currScore = weakenScore;
            manager.DifficultyUp();
        }

        if (currentHp <= 0)
        {
            SceneManager.LoadScene("WeakenMenu");
            GetTotalScores.weakScore += weakenScore;
        }
    }
}
