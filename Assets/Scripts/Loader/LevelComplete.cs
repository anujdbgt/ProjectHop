using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelComplete : MonoBehaviour
{
    public void LevelCompleted()
    {
        if(PlayerPrefs.GetInt("CurrentLevel") < SceneManager.GetActiveScene().buildIndex + 1)
        {
            PlayerPrefs.SetInt("CurrentLevel", SceneManager.GetActiveScene().buildIndex + 1);
        }
        LevelLoaderScript.LoadLevel.LoadNextLevel();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        LevelCompleted();
    }
}
