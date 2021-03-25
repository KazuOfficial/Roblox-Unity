using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public void HomeRobloxia()
    {
        SceneManager.LoadScene("SampleScene", LoadSceneMode.Single);
    }

    public void Crossroads()
    {
        SceneManager.LoadScene("Crossroads", LoadSceneMode.Single);
    }

    public void YoricksRestingPlace()
    {
        SceneManager.LoadScene("Yorick's Resting Place", LoadSceneMode.Single);
    }

    public void Play()
    {
        SceneManager.LoadScene("Play", LoadSceneMode.Single);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
