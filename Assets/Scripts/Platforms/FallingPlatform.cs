using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float timeToFall = 3f;
    public float platformFallingVelocity;
    float fallTime;
    Rigidbody2D platform;

    private void Awake()
    {
        fallTime = timeToFall;
    }
    private void Start()
    {
        platform = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            StartCoroutine(FallAfterSeconds());
        }
    }

    IEnumerator FallAfterSeconds()
    {
        yield return new WaitForSeconds(timeToFall);
    //    if(fallTime > 0)
    //    {
    //        fallTime -= Time.deltaTime;
    //    }
    //    else if (fallTime <= 0)
    //    {
            platform.velocity = Vector2.down * platformFallingVelocity;
    //   }
    }
}
