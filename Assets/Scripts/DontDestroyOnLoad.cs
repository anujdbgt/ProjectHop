﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DontDestroyOnLoad : MonoBehaviour
{

    private void Awake()
    {
        var objects = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == this.name);
        Debug.Log("Don't Destory On load : " + objects.Count());
        if (objects.Count() > 2)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
