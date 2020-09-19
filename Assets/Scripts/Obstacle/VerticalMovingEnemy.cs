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
        if ((!upFloorTest() && downFloorTest()) || UpWallCheck())
        {
            enemy.velocity = Vector2.down * speed;
            slime.flipX = true;
        }
        // Moving Down Change to Up

        else if ((upFloorTest() && !downFloorTest()) || DownWallCheck())
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

}
