using System.Collections;
using UnityEngine;
using UnityEditor;
using MyBox;
using UnityEngine.Audio;
public class JumpingEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    public int timeToJump;
    public float yForce;

    [Header("Values Should Be Default If XY Jump Is False")]
    public bool xYJump;

    AudioSource jumpSound;
    public enum JumpDirection
    {
        None,
        Right,
        Left
    };

    [ConditionalField("xYJump", false)] public float xForce = 0;
    [Tooltip("None To Jump Back and Forth")]
    [ConditionalField("xYJump", false)] public JumpDirection ChooseDirection = JumpDirection.None;
    bool direction;
    int directionChange = -1;
    float xForcePri;
    Animator animator;
    Rigidbody2D rb;
    void Awake()
    {
        jumpSound = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        xForcePri = xForce;
    }

    private void Start()
    {

        if (ChooseDirection == JumpDirection.Right)
        {
            directionChange = 1;
        }
        else
            directionChange = -1;


        if (ChooseDirection == JumpDirection.None)
        {
            InvokeRepeating("JumpUpAndResonate", timeToJump, timeToJump);
        }
        else
        {
            InvokeRepeating("JumpInOneDiection", timeToJump, timeToJump);
        }
        
    }
    // Update is called once per frame
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            animator.SetTrigger("OnGround");
        }
    }

    void JumpUpAndResonate()
    {
        float horForce = xForcePri * directionChange;
        xForcePri = horForce;
        animator.SetTrigger("Jumping");
        jumpSound.Play();
        rb.AddForce(new Vector2(horForce, yForce), ForceMode2D.Impulse);
    }
    void JumpInOneDiection()
    {
        animator.SetTrigger("Jumping");
        jumpSound.Play();
        rb.AddForce(new Vector2(xForce * directionChange, yForce), ForceMode2D.Impulse);
    }
}
