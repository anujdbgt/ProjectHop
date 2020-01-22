using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    public void StartANewGame()
    {
        LevelLoaderScript.LoadLevel.StartNewGame();
    }
}
