using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemy : MonoBehaviour
{
    public Transform rightSensor, leftSensor;
    public float raycastDistance = 0.03f;
    public int speed = 2;
    public float raycastOriginOffset = 0.33f;

    Rigidbody2D enemy;

    private void Start()
    {
        enemy = GetComponent<Rigidbody2D>();
        enemy.velocity = Vector2.right * speed;
    }
    private void Update()
    {
        //Moving Right Change to Left
        if(!rightRaycast() && leftRaycast())
        {
            enemy.velocity = Vector2.left * speed;
        }
        // Moving Left Change to Right
        else if(rightRaycast() && !leftRaycast())
        {
            enemy.velocity = Vector2.right * speed;
        }
    }

    bool rightRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(rightSensor.position.x + raycastOriginOffset, transform.position.y), Vector2.down , raycastDistance);
        Debug.DrawRay(new Vector2(rightSensor.position.x, transform.position.y), Vector2.down, Color.red); ;
        return hit;
    }
    bool leftRaycast()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(leftSensor.position.x + raycastOriginOffset, transform.position.y), Vector2.down, raycastDistance);
        Debug.DrawRay(new Vector2(rightSensor.position.x, transform.position.y), Vector2.down, Color.red); ;
        return hit;
    }
}
