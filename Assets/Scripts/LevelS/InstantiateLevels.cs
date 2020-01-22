using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateLevels : MonoBehaviour
{
    public GameObject levelTile;
    public GameObject levelParent;

    int levelCount;
    GameObject level;
    private void Awake()
    {
        levelCount = PlayerPrefs.GetInt("CurrentLevel");
        for (int i = 0; i < levelCount; i++)
        {
            level = Instantiate(levelTile);
            level.name = "Level" + i;
            level.transform.SetParent(levelParent.transform);
        }
    }
}
