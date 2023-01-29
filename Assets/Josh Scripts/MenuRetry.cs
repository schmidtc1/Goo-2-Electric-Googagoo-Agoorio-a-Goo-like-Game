using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuRetry : MonoBehaviour
{
    public void RetryGame()
    {
        Character.weakenScore = 0;
        SceneManager.LoadScene("WeakenGame");
    }
    public void ExitGame() {
        SceneManager.LoadScene("Lobby");
    }
}
