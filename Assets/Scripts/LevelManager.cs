using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] float vehiclesDestroyed;
    [SerializeField] GameObject gameWinPanel;
    [SerializeField] GameObject pausePanel;

    private void Start()
    {
        gameWinPanel.SetActive(false);
        pausePanel.SetActive(false);

        Time.timeScale = 1.0f;
    }

    public void VehiclesDestroyedTrack()
    {
        vehiclesDestroyed++;
    }

    void NextLevel()
    {
        if(vehiclesDestroyed >= 7f)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.buildIndex + 1);
        }
    }
    void GameWin()
    {
        if (vehiclesDestroyed == 8f)
        {
            gameWinPanel?.SetActive(true);
        }
    }

    void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            print("Paused");
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1.0f;
        pausePanel.SetActive(false);   
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        NextLevel();
        GameWin();
        Pause();
    }
}
