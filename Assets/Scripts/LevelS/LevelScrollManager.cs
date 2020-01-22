using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelScrollManager : MonoBehaviour
{
    public GameObject levelContainer;
    public int sizeToIncrease = 140;

    float newSize;
    float containerSizeMultiplier;
    float containerSize;
    RectTransform containerRect;

    int columns = 5;
    GameObject[] levels;
    int levelCount;
    private void Awake()
    {
        containerRect = levelContainer.GetComponent<RectTransform>();
    }
    private void Start()
    {
        levels = GameObject.FindGameObjectsWithTag("Level");
        levelCount = levels.Length;
        if(levelCount%columns != 0)
        {
            containerSizeMultiplier = (columns - (levelCount % columns) + levelCount) / columns;
        }
        else
        {
            containerSizeMultiplier = levelCount / columns;
        }
        if(levelCount > columns)
        {
            newSize = containerRect.sizeDelta.y + (sizeToIncrease * containerSizeMultiplier);
            containerRect.sizeDelta = new Vector2(containerRect.sizeDelta.x, newSize);
        }
        
    }
}
