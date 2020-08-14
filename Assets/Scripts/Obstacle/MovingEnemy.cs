using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public Transform rightSensor, leftSensor;
    public float raycastDistance = 0.03f;
    public int speed = 2;
    public float raycastOriginOffset = 0.33f;
    public enum Directions
    {
        Right,
        Left
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
        if (StartingDirection == Directions.Right)
        {
            enemy.velocity = Vector2.right * speed;
            slime.flipX = true;
        }
        else
        {
            enemy.velocity = Vector2.left * speed;
            slime.flipX = false;
        }
    }
    private void Update()
    {
        //Moving Right Change to Left
        if(rightWallCheck().collider != null)
        {
            if(rightWallCheck().collider.tag == "SideWall")
            {
                enemy.velocity = Vector2.left * speed;
                slime.flipX = false;
            }
        }
        if(!rightFloorRaycast() && leftFloorRaycast())
        {
            enemy.velocity = Vector2.left * speed;
            slime.flipX = false;
        }
        // Moving Left Change to Right

        else if (rightFloorRaycast() && !leftFloorRaycast())
        {
            enemy.velocity = Vector2.right * speed;
            slime.flipX = true;
        }
        if (leftWallCheck().collider != null)
        {
            if (leftWallCheck().collider.tag == "SideWall")
            {
                enemy.velocity = Vector2.right * speed;
                slime.flipX = true;
            }
        }
    }

    bool rightFloorRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(rightSensor.position.x + raycastOriginOffset, transform.position.y), Vector2.down , raycastDistance);
        Debug.DrawRay(new Vector2(rightSensor.position.x, transform.position.y), Vector2.down, Color.red); ;
        return hit;
    }
    bool leftFloorRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(leftSensor.position.x + raycastOriginOffset, transform.position.y), Vector2.down, raycastDistance);
        Debug.DrawRay(new Vector2(leftSensor.position.x, transform.position.y), Vector2.down, Color.red); ;
        return hit;
    }

    RaycastHit2D rightWallCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(rightSensor.position.x + raycastOriginOffset, transform.position.y), Vector2.right, raycastDistance);
        Debug.DrawRay(new Vector2(rightSensor.position.x, transform.position.y), Vector2.down, Color.red); ;
        return hit;
    }
    RaycastHit2D leftWallCheck()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(leftSensor.position.x + raycastOriginOffset, transform.position.y), Vector2.left, raycastDistance);
        Debug.DrawRay(new Vector2(leftSensor.position.x, transform.position.y), Vector2.down, Color.red); ;
        return hit;
    }


}
