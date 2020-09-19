using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour
{

    public GameObject bullet;
    public float speed;
    public int timeToShoot;
    public int timeToDeactive;

    float animSync = 0.40f; // Animation Sample/60
    Animator ani;
    Vector3 bulletPosition;
    Rigidbody2D rb;
    SpriteRenderer bulletSprite;

    void Start()
    {
        rb = bullet.GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        bulletSprite = bullet.GetComponent<SpriteRenderer>();
        Debug.Log(bullet.transform.localPosition.x);
        //BulletPositioning();
        InvokeRepeating("Shooting", timeToShoot, timeToShoot);
    }


    void Update()
    {
    }
    
    void Addvelocity()
    {
        if (this.GetComponent<SpriteRenderer>().flipX == false)
        {
            rb.velocity = Vector2.left * speed;
        }
        else
        {
            rb.velocity = Vector2.right * speed;
            bulletSprite.flipX = true;
        }
            
    }

    void ActivateBullet()
    {
        bullet.SetActive(true);
    }
    void DeactivateBullet()
    {
        bullet.SetActive(false);
    }
    void Shooting()
    {
        DeactivateBullet();
        BulletPositioning();
        StartCoroutine(AnimationShootingWithDelay());
        StartCoroutine(DeactivateWithDelay());
    }

    IEnumerator DeactivateWithDelay()
    {
        yield return new WaitForSeconds(timeToDeactive);
        DeactivateBullet();
    }
    IEnumerator AnimationShootingWithDelay()
    {
        ani.SetTrigger("Shooting");
        yield return new WaitForSeconds(animSync);
        ActivateBullet();
        Addvelocity();
    }

    void BulletPositioning()
    {
        if(this.GetComponent<SpriteRenderer>().flipX == false)
        {
            bulletPosition = bullet.transform.localPosition;
        }
        else
        {
            Debug.Log(bullet.transform.localPosition.x);
            bulletPosition = bullet.transform.localPosition;
            Debug.Log(bulletPosition.x);
            bulletPosition.x =+ 1;
            bullet.transform.localPosition = bulletPosition;
            bulletPosition = bullet.transform.localPosition;
        }
        
    }
}
