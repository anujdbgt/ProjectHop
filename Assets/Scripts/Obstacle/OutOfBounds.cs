using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    public Transform camPosition;
    public float yPosition;

    GameObject mainCamera;

    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        camPosition = mainCamera.transform;
    }
    private void Update()
    {
        MoveWithCam();
    }
    void MoveWithCam()
    {
        float xPos = camPosition.position.x;
        transform.position = new Vector3(xPos, yPosition, transform.position.z);
    }
}
