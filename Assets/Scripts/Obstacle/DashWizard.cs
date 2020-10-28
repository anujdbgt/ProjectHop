using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DashWizard : MonoBehaviour
{
    public float raycastDistance;
    public Transform rightSensor;
    public Transform leftSensor;
    public int speed;
    public int timeToDestroy;

    Animator ani;
    Rigidbody2D rb;
    int direction = -1;
    bool movementStarted = false;

    AudioSource dashSound;
    void Start()
    {
        dashSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

        if (GetComponent<SpriteRenderer>().flipX)
        {
            direction = 1;
        }
    }
    
    void Update()
    {
        if(PlayerCheck() && !movementStarted)
        {
            ani.SetTrigger("Dash");
            dashSound.Play();
            rb.velocity = speed * Vector2.right * direction;
            movementStarted = true;
        }
    }

    bool PlayerCheck()
    {
        if (!GetComponent<SpriteRenderer>().flipX)
        {
            if (CheckLeftCollision().collider != null)
            {
                if (CheckLeftCollision().collider.tag == "Player")
                {
                    return true;
                }
                else
                    return false;
            }
            else
                return false;
        }
        else
        {
            if(CheckRightCollision().collider != null)
            {
                if (CheckRightCollision().collider.tag == "Player")
                {
                    return true;
                }
                else
                    return false;
            }
        }

        return false;
    }
    RaycastHit2D CheckLeftCollision()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(leftSensor.position.x, leftSensor.position.y), Vector2.right * direction, raycastDistance);
        Debug.DrawRay(new Vector2(leftSensor.position.x, leftSensor.position.y), Vector2.right * direction, Color.red);
        return hit;
    }
    RaycastHit2D CheckRightCollision()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(rightSensor.position.x, rightSensor.position.y), Vector2.right * direction, raycastDistance);
        Debug.DrawRay(new Vector2(rightSensor.position.x, rightSensor.position.y), Vector2.right * direction, Color.red);
        return hit;
    }

    IEnumerator DestoryAfterDelay()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(this);
    }
}
