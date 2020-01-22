using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoaderScript : MonoBehaviour
{
    public static LevelLoaderScript LoadLevel;

    int currentLevelBuildIndex = 1;
    private void Awake()
    {
        LoadLevel = this;
        int currentLevelCount = FindObjectsOfType<LevelLoaderScript>().Length;
        if(currentLevelCount > 1)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("CurrentLevel"))
        {
            PlayerPrefs.SetInt("CurrentLevel", currentLevelBuildIndex);
        }
        else
        {
            currentLevelBuildIndex = PlayerPrefs.GetInt("CurrentLevel");
        }
        LoadAnyLevel(currentLevelBuildIndex);
    }

    public void LoadAnyLevel(int buildIndex)
    {
        SceneManager.LoadScene(buildIndex);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void StartNewGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(1);
    }
}
