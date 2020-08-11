﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform startPoint, endPoint;
    public int speed = 2;
    public bool checkOnX = true;
    public bool checkOnY = true;

    int moveDirection = 1;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        PlatformMovement();
    }
    void PlatformMovement()
    {
        if (checkOnX)
        {
            rb.velocity = Vector2.right * speed * MovementDirection();
            //transform.Translate(Vector2.right * MovementDirection() * speed * Time.deltaTime);
        }
        if (checkOnY)
        {
            rb.velocity = new Vector2(rb.velocity.x, speed * MovementDirection());
            //transform.Translate(Vector2.up * MovementDirection() * speed * Time.deltaTime);
        }
    }
    int MovementDirection()
    {
        if (StartPointReached())
        {
           moveDirection = 1;
        }
        if (EndPointReached())
        {
            moveDirection = -1; ;
        }
        return moveDirection;
    }



    bool StartPointReached()
    {
        if(checkOnX && !checkOnY)
        {
            if ((int)transform.position.x == (int)startPoint.position.x)
            {
                return true;
            }
        }
        if (!checkOnX && checkOnY)
        {
            if ((int)transform.position.y == (int)startPoint.position.y)
            {
                return true;
            }
        }
        if (checkOnX && checkOnY)
        {
            if ((int)transform.position.x == (int)startPoint.position.x && (int)transform.position.y == (int)startPoint.position.y)
            {
                return true;
            }
        }
        return false;
    }
    bool EndPointReached()
    {
        if (checkOnX && !checkOnY)
        {
            if ((int)transform.position.x == (int)endPoint.position.x)
            {
                return true;
            }
        }
        if (!checkOnX && checkOnY)
        {
            if ((int)transform.position.y == (int)endPoint.position.y)
            {
                return true;
            }
        }
        if (checkOnX && checkOnY)
        {
            if ((int)transform.position.x == (int)endPoint.position.x && (int)transform.position.y == (int)endPoint.position.y)
            {
                return true;
            }
        }
        return false;
    }
}
