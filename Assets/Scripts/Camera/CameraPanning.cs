using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.InputSystem;
public class CameraPanning : MonoBehaviour
{
    public GameObject cinCam1;
    public GameObject cinCam2;
    public float sizeToIncrease;
    public float maxOrthoSize = 22f;

    float currentSize;
    CinemachineVirtualCamera cam1, cam2;
    PlayerInput playerInput;

    //True - Normal Camera, False For Increased Camera FOV
    bool cameraState = true;
    bool camPanTrigger = false;
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        cam1 = cinCam1.GetComponent<CinemachineVirtualCamera>();
        if(cinCam2 != null)
        {
            cam2 = cinCam2.GetComponent<CinemachineVirtualCamera>();
        }
        currentSize = cam1.m_Lens.OrthographicSize;
    }

    // Update is called once per frame
    void Update()
    {
        if(cinCam2 != null)
        {
            if (camPanTrigger)
            {
                if (cameraState)
                {
                    if (cam1.m_Lens.OrthographicSize < maxOrthoSize)
                    {
                        playerInput.enabled = false;
                        cam1.m_Lens.OrthographicSize += sizeToIncrease * Time.deltaTime;
                    }
                    else
                    {
                        cam2.Priority = cam1.Priority + 1;
                        playerInput.enabled = true;
                        cameraState = false;
                        camPanTrigger = false;
                    }

                }
                else
                {
                    if (cam1.m_Lens.OrthographicSize > currentSize)
                    {
                        playerInput.enabled = false;
                        cam2.Priority = cam1.Priority - 1;
                        cam1.m_Lens.OrthographicSize -= sizeToIncrease * Time.deltaTime;

                    }
                    else
                    {
                        playerInput.enabled = true;
                        cameraState = true;
                        camPanTrigger = false;
                    }

                }
            }
        }
        
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CameraPan")
        {
            camPanTrigger = true;
        }
    }
}
