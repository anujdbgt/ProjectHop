using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static bool GamePaused;

    public void PauseResumeProcess()
    {
        if (GamePaused)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f;
        GamePaused = true;
    }
    void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}
