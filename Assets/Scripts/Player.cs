using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;
public class Player : MonoBehaviour
{
    public PlayerInput input;
    public Vector2 slideDistance;

    public float raycastOriginOffset = 0.33f;
    public float raycastXDistance = 0.1f;
    public float raycastYDistance = 0.021f;
    public float xMaxDistance = 5f;
    float xMaxDistanceSave;
    public float yMaxDistance = 10f;
    public int xWallJump = 5;
    public int yWallJump = 10;
    public Vector2 counterJumpForce;
    public float decendSpeed;
    public float wallSticktime = 0.25f;

    Animator animator;
    int rightMovement = 1;
    int leftMovement = -1;
    float timeToWallUnstick;
    bool jumpingDone = false;
    bool jumpingCloseWall = false;
    bool jumpingFarFromWall = false;
    bool flipped = false;
    bool touchingBottom;
    Rigidbody2D player;
    float currentGravityScale;
    private void Awake()
    {
        timeToWallUnstick = wallSticktime;
        xMaxDistanceSave = xMaxDistance;
    }
    private void Start()
    {
        player = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
        currentGravityScale = player.gravityScale;
    }
    private void Update()
    {
        JumpAnimation();
       //Debug.Log(timeToWallUnstick);
    }

    private void FixedUpdate()
    {
        // if touching side wall slow down the decend
        
        if(CheckFrontCollision(DirectionOfMovement()) && !touchingBottom)
        {
            //Debug.Log("Coming In Decend Function");
            if(jumpingCloseWall && !jumpingFarFromWall)
            {
                SlowDecendCloseWall();
            }
            else if(!jumpingCloseWall && jumpingFarFromWall)
            {
                SlowDecendFarWall();
            }
        }

    }
    public void JumpRight(InputAction.CallbackContext context)
    {
        if (!GameState.GamePaused)
        {
            #region TouchInput
            if (CheckTouchInput())
            {
                if (Touchscreen.current.position.x.ReadValue() > Screen.width / 2)
                {
                    // Wall jump
                    if (context.started && !touchingBottom && (CheckFrontCollision(rightMovement) || CheckFrontCollision(leftMovement)))
                    {
                        //flip and jump
                        //Resetting Time to Unsitck
                        WallJumpAndSlide(rightMovement);
                    }
                    if (context.started)
                    {
                        FlipToRight();
                        timeToWallUnstick = wallSticktime;
                        player.gravityScale = currentGravityScale;
                    }
                    if (CheckFrontCollision(rightMovement))
                    {
                        xMaxDistance = 0f;
                    }
                    else xMaxDistance = xMaxDistanceSave;

                    if (context.started && touchingBottom && CheckFrontCollision(rightMovement))
                    {
                        JumpCloseWall(xMaxDistance, yMaxDistance, rightMovement);
                    }
                    //Normal Jump and Slide
                    if (context.started  && touchingBottom && !CheckFrontCollision(rightMovement))
                    {
                        JumpSildeProcess(xMaxDistance, yMaxDistance, rightMovement);
                    }
                    //Hold to jump higher and longer
                    if (context.canceled && !touchingBottom)
                    {
                        player.AddForce(counterJumpForce * player.mass, ForceMode2D.Impulse);
                    }
                }

            }

            #endregion
            #region NormalInput
            else
            {
                // Wall jump
                if (context.started && !touchingBottom && (CheckFrontCollision(rightMovement) || CheckFrontCollision(leftMovement)))
                {
                    //flip and jump
                    //Resetting Time to Unsitck
                    WallJumpAndSlide(rightMovement);
                }
                if (context.started)
                {
                    FlipToRight();
                    timeToWallUnstick = wallSticktime;
                    player.gravityScale = currentGravityScale;
                }
                if (CheckFrontCollision(rightMovement))
                {
                    xMaxDistance = 0f;
                }
                else xMaxDistance = xMaxDistanceSave;

                if (context.started && touchingBottom && CheckFrontCollision(rightMovement))
                {
                    Debug.Log("Coming in JumpClose to Wall");
                    JumpCloseWall(xMaxDistance, yMaxDistance, rightMovement);
                }
                //Normal Jump and Slide
                if (context.started  && touchingBottom && !CheckFrontCollision(rightMovement))
                {
                    Debug.Log("JumpAnd Slide Process");
                    JumpSildeProcess(xMaxDistance, yMaxDistance, rightMovement);
                }
                //Hold to jump higher and longer
                if (context.canceled && !touchingBottom)
                {
                    player.AddForce(counterJumpForce * player.mass, ForceMode2D.Impulse);
                }
            }
            #endregion
        }
    }

    public void JumpLeft(InputAction.CallbackContext context)
    {
       
        if (!GameState.GamePaused)
        {
            #region TouchInput
            if (CheckTouchInput())
            {
                if (Touchscreen.current.position.x.ReadValue() < Screen.width / 2)
                {
                    // Wall jump
                    if (context.started && !touchingBottom && (CheckFrontCollision(rightMovement) || CheckFrontCollision(leftMovement)))
                    {
                        Debug.Log("left jump");
                        //Resetting Time to Unsitck
                        WallJumpAndSlide(leftMovement);
                    }
                    if (context.started)
                    {
                        FlipToLeft();
                        timeToWallUnstick = wallSticktime;
                        player.gravityScale = currentGravityScale;
                    }
                    if (CheckFrontCollision(leftMovement))
                    {
                        xMaxDistance = 0f;
                    }
                    else xMaxDistance = xMaxDistanceSave;

                    if (context.started && touchingBottom && CheckFrontCollision(leftMovement))
                    {
                        JumpCloseWall(xMaxDistance, yMaxDistance, leftMovement);
                    }
                    //Normal Jump and Slide
                    if (context.started && touchingBottom && !CheckFrontCollision(leftMovement))
                    {
                        JumpSildeProcess(xMaxDistance, yMaxDistance, leftMovement);
                    }
                    //Hold to jump higher and longer
                    if (context.canceled && !touchingBottom)
                    {
                        player.AddForce(counterJumpForce * player.mass, ForceMode2D.Impulse);
                    }
                }

            }

            #endregion
            #region Normal Input
            else
            {
                // Wall jump
                if (context.started && !touchingBottom && (CheckFrontCollision(rightMovement) || CheckFrontCollision(leftMovement)))
                {
                    //Resetting Time to Unsitck
                    WallJumpAndSlide(leftMovement);
                }
                if (context.started)
                {
                    FlipToLeft();
                    timeToWallUnstick = wallSticktime;
                    player.gravityScale = currentGravityScale;
                }
                if (CheckFrontCollision(leftMovement))
                {
                    xMaxDistance = 0f;
                }
                else xMaxDistance = xMaxDistanceSave;

                if (context.started && touchingBottom && CheckFrontCollision(leftMovement))
                {
                    Debug.Log("Coming in JumpClose to Wall");
                    JumpCloseWall(xMaxDistance, yMaxDistance, leftMovement);
                }
                //Normal Jump and Slide
                if (context.started  && touchingBottom && !CheckFrontCollision(leftMovement))
                {
                    Debug.Log("JumpAnd Slide Process");
                    JumpSildeProcess(xMaxDistance, yMaxDistance, leftMovement);
                }
                //Hold to jump higher and longer
                if (context.canceled && !touchingBottom)
                {
                    player.AddForce(counterJumpForce * player.mass, ForceMode2D.Impulse);
                }
            }
            #endregion
        }
    }
    void WallJumpAndSlide(int movementDirection)
    {
        WallJump(movementDirection);
    }
    void JumpSildeProcess(float xDistance, float yDistance, int movementDirection)
    {
        JumpFarFromWall(xDistance, yDistance , movementDirection);
    }

    void JumpCloseWall(float xDistance, float yDistance, int movementDirection)
    {
        if (touchingBottom)
        {
            player.AddForce(new Vector2(xDistance * movementDirection, yDistance) * player.mass, ForceMode2D.Impulse);
            jumpingCloseWall = true;
            jumpingFarFromWall = false;
        }
    }
    void JumpFarFromWall(float xDistance, float yDistance, int movementDirection)
    {
        if (touchingBottom)
        {
            player.AddForce(new Vector2(xDistance * movementDirection, yDistance) * player.mass, ForceMode2D.Impulse);
            jumpingDone = true;
            jumpingFarFromWall = true;
            jumpingCloseWall = false;
        }
    }

    //void Sliding(int movementDirection)
    //{
    //    if (touchingBottom && jumpingDone)
    //    {
    //        player.AddForce(slideDistance * movementDirection, ForceMode2D.Impulse);
    //        jumpingDone = false;
    //        slidingDone = true;
    //    }
    //}
    //void SlidingDone()
    //{
    //    jumpingDone = false;
    //    slidingDone = true;
    //}
    void SlowDecendCloseWall()
    {
        if (player.velocity.y <= 0)
        {
            if (timeToWallUnstick > 0)
            {
                timeToWallUnstick -= Time.deltaTime;
                player.velocity = Vector2.zero;
                player.gravityScale = 0;
            }
            else if (timeToWallUnstick <= 0)
            {
                player.gravityScale = currentGravityScale;
                player.velocity = Vector2.down * decendSpeed * Time.deltaTime ;
            }
        }
    }
    void SlowDecendFarWall()
    {
        if (player.velocity.y <= 0)
        {
            if (timeToWallUnstick > 0)
            {
                timeToWallUnstick -= Time.deltaTime;
                player.velocity = Vector2.zero;
                player.gravityScale = 0;
            }
            else if (timeToWallUnstick <= 0)
            {
                player.gravityScale = currentGravityScale;
                player.velocity = Vector2.down * decendSpeed * Time.deltaTime;
            }
        }
    }
   
    void WallJump(int movementDirection)
    {
        player.AddForce(new Vector2(xWallJump * movementDirection, yWallJump) * player.mass , ForceMode2D.Impulse);
    }

    int DirectionOfMovement()
    {
        int direction;
        if (flipped)
        {
            direction = leftMovement;
        }
        else direction = rightMovement;

        return direction;
    }
    void FlipToRight()
    {
        transform.rotation = Quaternion.identity;
        flipped = false;
    }
    void FlipToLeft()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        flipped = true;
    }
    bool CheckTouchInput()
    {
        if(input.currentControlScheme == "TouchScreen")
        {
            return true;
        }
        return false;
    }
    #region Animationhandler
    void JumpAnimation()
    {
        if(player.velocity.y > 0 && (!CheckFrontCollision(leftMovement) || !CheckFrontCollision(rightMovement)))
        {
            animator.SetBool("WallSlide", false);
            animator.SetBool("JumpDown", false);
            animator.SetBool("JumpUp",true);
        }
        if (player.velocity.y < 0 && (!CheckFrontCollision(leftMovement) || !CheckFrontCollision(rightMovement)))
        {
            animator.SetBool("WallSlide", false);
            animator.SetBool("JumpUp", false);
            animator.SetBool("JumpDown", true);
        }
        if (touchingBottom)
        {
            animator.SetBool("JumpUp", false);
            animator.SetBool("JumpDown", false);
            animator.SetBool("WallSlide", false);
        }
        if((CheckFrontCollision(leftMovement) || CheckFrontCollision(rightMovement)) && !touchingBottom)
        {
            animator.SetBool("WallSlide", true);
        }
    }
    #endregion
    #region CollisionCheck

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            touchingBottom = true;
        }
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            touchingBottom = false;
        }
        if(col.gameObject.HasTag("MovingPlatform"))
        {
            transform.parent.gameObject.transform.SetParent(null);
        }
    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.HasTag ("MovingPlatform"))
        {
            transform.parent.gameObject.transform.SetParent(col.transform);
            //transform.position = new Vector2(col.transform.position.x, transform.position.y);
        }
    }
    bool CheckFrontCollision(int raycastDirection)
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x + raycastOriginOffset * raycastDirection, transform.position.y ), Vector2.right * raycastDirection, raycastXDistance);
        Debug.DrawRay(new Vector2(transform.position.x + raycastOriginOffset * raycastDirection, transform.position.y), Vector2.right * raycastDirection, Color.red); ;
        return hit;
    }
    
    
#endregion
}
