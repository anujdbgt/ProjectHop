using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    public float timeToFall = 3f;
    public float platformFallingVelocity;
    public int destroyAfter = 20;
    float fallTime;
    Rigidbody2D platform;

    Transform parentTransform;
    GameObject player;

    private void Awake()
    {
        fallTime = timeToFall;
    }
    private void Start()
    {
        platform = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(player.transform.position.y+ "  " + this.transform.position.y);
        if(collision.gameObject.tag == "Player" && PlayerAbovePlatform())
        {
            StartCoroutine(FallAfterSeconds());
        }
    }

    IEnumerator FallAfterSeconds()
    {
        yield return new WaitForSeconds(timeToFall);
        platform.velocity = Vector2.down * platformFallingVelocity;
        yield return new WaitForSeconds(destroyAfter);
        Destroy(this.gameObject);
    }

    bool PlayerAbovePlatform()
    {
        if (player.transform.position.y > this.transform.position.y)
        {
            return true;
        }
        else return false;
    }
    
}
