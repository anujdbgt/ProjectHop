using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    float lengthX, lengthY, startposX, startposY;
    public GameObject cam;
    public float parallaxEffectX;
    public float parallaxEffectY;
    public float transitionSpeed;
    void Start()
    {
        startposX = transform.position.x;
        startposY = transform.position.y;
        lengthX = GetComponent<SpriteRenderer>().bounds.size.x;
        lengthY = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        float tempX = (cam.transform.position.x * (1 - parallaxEffectX));
        float distX = (cam.transform.position.x * parallaxEffectX);
        float tempY = (cam.transform.position.y * (1 - parallaxEffectX));
        float distY = (cam.transform.position.y * parallaxEffectY);
        transform.position = new Vector3(startposX + distX, startposY + distY, transform.position.z);
        //transform.position = Vector3.Lerp(transform.position, new Vector3(startposX + distX, startposY + distY, transform.position.z), Time.deltaTime * transitionSpeed);

        if (tempX > startposX + lengthX) startposX += lengthX;
        else if (tempX < startposX - lengthX) startposX -= lengthX;
    }
}
