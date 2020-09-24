using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingAI : MonoBehaviour
{
    public float dsyncBullets;
    public GameObject bullet;
    public float speed;
    public int timeToShoot;
    public int timeToDeactive;

    float animSync = 0.40f; // Animation Sample/60
    Animator ani;
    Vector3 bulletPosition;
    Rigidbody2D rb;
    SpriteRenderer bulletSprite;
    bool canShoot = true;

    void Start()
    {

        bulletPosition = bullet.transform.localPosition;
        rb = bullet.GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        bulletSprite = bullet.GetComponent<SpriteRenderer>();
        BulletPositioning();
        InvokeRepeating("Shooting", timeToShoot, timeToShoot);
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
        if (canShoot)
        {
            canShoot = false;
            DeactivateBullet();
            BulletPositioning();
            StartCoroutine(AnimationShootingWithDelay());
            StartCoroutine(DeactivateWithDelay());
        }
       
    }
    IEnumerator DeactivateWithDelay()
    {
        yield return new WaitForSeconds(timeToDeactive);
        DeactivateBullet();
        canShoot = true;
    }
    IEnumerator AnimationShootingWithDelay()
    {
        yield return new WaitForSeconds(dsyncBullets);
        ani.SetTrigger("Shooting");
        yield return new WaitForSeconds(animSync);
        ActivateBullet();
        Addvelocity();
    }

    void BulletPositioning()
    {
        if (this.GetComponent<SpriteRenderer>().flipX == false)
        {
            bullet.transform.localPosition = bulletPosition;
        }
        if (this.GetComponent<SpriteRenderer>().flipX != false)
        {
            bulletPosition = bullet.transform.localPosition;
            bulletPosition.x =+ 1;
            bullet.transform.localPosition = bulletPosition;
            bulletPosition = bullet.transform.localPosition;
        }
        
    }
}
