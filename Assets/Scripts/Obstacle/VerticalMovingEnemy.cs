using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingEnemy : MonoBehaviour
{
    public Transform upSensor, downSensor;
    public Transform upWallCheck, downWallCheck;
    public float raycastDistance = 0.03f;
    public int speed = 2;
    public float raycastOriginOffset = 0.33f;
    public enum Directions
    {
        Up,
        Down
    };

    public Directions StartingDirection;

    Rigidbody2D enemy;
    SpriteRenderer slime;

    private void Awake()
    {
        slime = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        enemy.gravityScale = 0;
        if (StartingDirection == Directions.Up)
        {
            enemy.velocity = Vector2.up * speed;
            slime.flipX = false;
        }
        else
        {
            enemy.velocity = Vector2.down * speed;
            slime.flipX = true;
        }
    }
    private void Update()
    {
        if ((!upFloorTest() && downFloorTest()) || UpWallCheck() && !HittingPlayer1() && !HittingPlayer2() && !HittingPlayer3() && !HittingPlayer4())
        {
            enemy.velocity = Vector2.down * speed;
            slime.flipX = true;
        }
        // Moving Down Change to Up

        else if ((upFloorTest() && !downFloorTest()) || DownWallCheck() && !HittingPlayer1() && !HittingPlayer2() && !HittingPlayer3() && !HittingPlayer4())
        {
            enemy.velocity = Vector2.up * speed;
            slime.flipX = false;
        }
    }

    bool upFloorTest()
    {
        if (slime.flipY)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, upSensor.position.y + raycastOriginOffset), Vector2.right, raycastDistance);
            Debug.DrawRay(new Vector2(transform.position.x, upSensor.position.y), Vector2.right, Color.red);
            return hit;
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, upSensor.position.y + raycastOriginOffset), Vector2.left, raycastDistance);
            Debug.DrawRay(new Vector2(transform.position.x, upSensor.position.y), Vector2.left, Color.red);
            return hit;
        }
        
    }
    bool downFloorTest()
    {
        if (slime.flipY)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, downSensor.position.y + raycastOriginOffset), Vector2.right, raycastDistance);
            Debug.DrawRay(new Vector2(transform.position.x, downSensor.position.y), Vector2.right, Color.red);
            return hit;
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, downSensor.position.y + raycastOriginOffset), Vector2.left, raycastDistance);
            Debug.DrawRay(new Vector2(transform.position.x, downSensor.position.y), Vector2.left, Color.red);
            return hit;
        }
        
    }

    bool UpWallCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, upSensor.position.y + raycastOriginOffset), Vector2.up, raycastDistance);
        Debug.DrawRay(new Vector2(transform.position.x, upSensor.position.y), Vector2.up, Color.red);
        return hit;
    }
    
    bool DownWallCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, downSensor.position.y + raycastOriginOffset), Vector2.down, raycastDistance);
        Debug.DrawRay(new Vector2(transform.position.x, downSensor.position.y), Vector2.down, Color.red);
        return hit;
    }

    RaycastHit2D upFloorTestKill()
    {
        if (slime.flipY)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, upSensor.position.y + raycastOriginOffset), Vector2.right, raycastDistance);
            Debug.DrawRay(new Vector2(transform.position.x, upSensor.position.y), Vector2.right, Color.red);
            return hit;
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, upSensor.position.y + raycastOriginOffset), Vector2.left, raycastDistance);
            Debug.DrawRay(new Vector2(transform.position.x, upSensor.position.y), Vector2.left, Color.red);
            return hit;
        }

    }
    RaycastHit2D downFloorTestKill()
    {
        if (slime.flipY)
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, downSensor.position.y + raycastOriginOffset), Vector2.right, raycastDistance);
            Debug.DrawRay(new Vector2(transform.position.x, downSensor.position.y), Vector2.right, Color.red);
            return hit;
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, downSensor.position.y + raycastOriginOffset), Vector2.left, raycastDistance);
            Debug.DrawRay(new Vector2(transform.position.x, downSensor.position.y), Vector2.left, Color.red);
            return hit;
        }

    }

    RaycastHit2D UpWallCheckKill()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, upSensor.position.y + raycastOriginOffset), Vector2.up, raycastDistance);
        Debug.DrawRay(new Vector2(transform.position.x, upSensor.position.y), Vector2.up, Color.red);
        return hit;
    }

    RaycastHit2D DownWallCheckKill()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, downSensor.position.y + raycastOriginOffset), Vector2.down, raycastDistance);
        Debug.DrawRay(new Vector2(transform.position.x, downSensor.position.y), Vector2.down, Color.red);
        return hit;
    }

    bool HittingPlayer1()
    {
        //if (upFloorTestKill().collider != null || downFloorTestKill().collider != null || UpWallCheckKill().collider != null || DownWallCheckKill().collider != null)
        //{
        //    if (upFloorTestKill().collider.tag == "Player" || downFloorTestKill().collider.tag == "Player" || UpWallCheckKill().collider.tag == "Player" || DownWallCheckKill().collider.tag == "Player")
        //    {
        //        return true;
        //    }
        //    else return false;
        //}
        //else return false;
        if (upFloorTestKill().collider != null)
        {
            if (upFloorTestKill().collider.tag == "Player")
            {
                return true;
            }
            else return false;
        }
        else return false;
    }
    bool HittingPlayer2()
    {
        if (downFloorTestKill().collider != null)
        {
            if (downFloorTestKill().collider.tag == "Player")
            {
                return true;
            }
            else return false;
        } else return false;
    }
    bool HittingPlayer3()
    {
        if (UpWallCheckKill().collider != null)
        {
            if (UpWallCheckKill().collider.tag == "Player")
            {
                return true;
            }
            else return false;
        } else return false;
    }
    bool HittingPlayer4()
    {
        if (DownWallCheckKill().collider != null)
        {
            if (DownWallCheckKill().collider.tag == "Player")
            {
                return true;
            }
            else return false;
        }
        else return false;
    }
        
    
}
