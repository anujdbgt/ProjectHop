using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
#if TESTING_MODE
    public static bool GamePaused = false;
#else
    public static bool GamePaused = true;
#endif

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
        GamePaused = false;
    }
}
