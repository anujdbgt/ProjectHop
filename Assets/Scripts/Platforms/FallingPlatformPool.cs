using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatformPool : MonoBehaviour
{
    List<Transform> fallingPlatforms = new List<Transform>();

    int timeBeforeEveryCheck = 5;
    int timeToReappear = 10;
    void Start()
    {
        foreach (Transform item in transform)
        {
            fallingPlatforms.Add(item);
        }
    }

    void Update()
    {
        StartCoroutine(ActivatingChildren());
    }

    IEnumerator ActivatingChildren()
    {
        yield return new WaitForSeconds(timeBeforeEveryCheck);
        Debug.Log("Checking");
        for (int i = 0; i < fallingPlatforms.Count; i++)
        {
            if (!fallingPlatforms[i].gameObject.activeSelf)
            {
                yield return new WaitForSeconds(timeToReappear);
                fallingPlatforms[i].gameObject.SetActive(true);
            }
        }
    }
}
