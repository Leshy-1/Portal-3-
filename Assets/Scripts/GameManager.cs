using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField]
    int timeToEnd;

    bool isGamePaused = false;

    bool isGameFinished = false;
    bool isGameWon = false;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (timeToEnd <= 0)
        {
            timeToEnd = 60;
        }
        InvokeRepeating("Stopper", 2, 1);
    }

    void Stopper()
    {
        timeToEnd--;
        Debug.Log("Time" + timeToEnd + "s");
        if (timeToEnd == 0)
        {
            timeToEnd = 0;
            isGameFinished = true;
        }
        if (isGameFinished)
        {
            EndGame();
        }
    }

    public void PauseGame()
    {
        Debug.Log("Game is paused");
        Time.timeScale = 0;
        isGamePaused = true;
    }
    public void ResumeGame()
    {
        Debug.Log("Game is resumed");
        Time.timeScale = 1;
        isGamePaused = false;
    }

    void CheckPause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }


        }

    }
    public void EndGame()
    {
        CancelInvoke("Stopper");

        if (isGameWon)
        {
            Debug.Log("You won!");
        }
        else
        {
            Debug.Log("You lost :< Reload?");
        }

        
    }
    void Update()
    {
        CheckPause();
    }
}
