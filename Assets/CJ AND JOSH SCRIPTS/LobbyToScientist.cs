using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LobbyToScientist : MonoBehaviour
{
    public void Scientist2()
    {
        SceneManager.LoadScene("WeakenGame");
    }
    public void Scientist3()
    {
        SceneManager.LoadScene("Agoorio");
    }

    public void Scientist4()
    {
        SceneManager.LoadScene("VolcanoLevel");
    }

    public void Scientist5()
    {
        SceneManager.LoadScene("AttackGame");
    }

    public void BreakOut()
    {
        SceneManager.LoadScene("Goo1");
    }
}
