using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public GameObject scorepanel;
    public GameObject infopage;
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void OpenScore()
    {
        scorepanel.SetActive(true);
    }
    public void CloseScore()
    {
        scorepanel.SetActive(false);
    }
    public void OpenInfoPage()
    {
        infopage.SetActive(!infopage.activeInHierarchy);
    }
}