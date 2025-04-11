using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("yooooooooooooooooooo");
            if (isPaused)
            {
                ResumeGame();
                
            }
            else
            {
                PauseGame();
            }
        }
    }
   public void T(){
    print("aaaaaaaaaaaaaaaaaaaaaaaaaaa");
   }
    public void ResumeGame()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f; 
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f; 
        isPaused = true;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Debug.Log("Exiting FUCKING Game.");
        Application.Quit();
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
