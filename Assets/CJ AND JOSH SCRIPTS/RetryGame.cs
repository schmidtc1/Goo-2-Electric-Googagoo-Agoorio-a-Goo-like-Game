using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RetryGame : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Agoorio");
    }

    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
