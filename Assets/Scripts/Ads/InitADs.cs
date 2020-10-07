using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class InitADs : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        MobileAds.Initialize(initStatus => { });
    }
}
