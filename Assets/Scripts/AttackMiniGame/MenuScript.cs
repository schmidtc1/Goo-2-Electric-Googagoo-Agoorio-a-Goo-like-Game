using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("AttackGame");
    }
    public void ExitGame()
    {
        SceneManager.LoadScene("Lobby");
    }
}