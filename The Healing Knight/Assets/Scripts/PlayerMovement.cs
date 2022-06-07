using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private TrailRenderer tr;
    private Animator anim;
    private Rigidbody2D body;

    private float moveSpeed;
    private float jumpForce = 6f;
    private bool grounded;
    private bool moveLeft;
    private bool moveRight;

    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 6f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 10f;
    bool jump = false;
    int jumpInt = 0;
    public static bool left;


    private void Awake()
    {
        Time.timeScale = 1f;
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }//Awake

    private void Start()
    {
        moveSpeed = 4f;
        moveLeft = false;
        moveRight = false;
        grounded = true;
    }

    public void MoveLeft()
    {
        left = true;
        if (jump == true && jumpInt == 0)
        {
            jumpInt++;
            moveLeft = true;
            transform.localScale = new Vector3(-1, 1, 1);
            StartCoroutine(Wait());

        }
        else if (jump == false)
        {
            moveLeft = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void MoveRight()
    {
        left = false;
        if (jump == true && jumpInt == 0)
        {
            jumpInt++;
            moveRight = true;
            transform.localScale = Vector3.one;
            StartCoroutine(Wait());
        }
        else if (jump == false)
        {
            moveRight = true;
            transform.localScale = Vector3.one;
        }
    }

    public void Jump()
    {
        if (body.velocity.x == 0 && grounded)
        {
            // gameObject.GetComponent<Rigidbody2D> ().AddForce (new Vector2 (0, jumpForce),ForceMode2D.Impulse);
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            grounded = false;
            jump = true;
        }
    }

    public void StopMoving()
    {
        moveLeft = false;
        moveRight = false;
        body.velocity = Vector2.zero;
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        anim.SetBool("run", horizontalInput != 0);
        anim.SetBool("grounded", grounded != false);

        if (isDashing)
        {
            return;
        }

        if (moveLeft)
        {
            body.velocity = new Vector2(-moveSpeed, 0f);
            anim.SetTrigger("run");
        }

        if (moveRight)
        {
            body.velocity = new Vector2(moveSpeed, 0f);
            anim.SetTrigger("run");
        }

        if (grounded == false)
        {
            anim.SetTrigger("jump");
        }
    }

    public IEnumerator Dash1()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = body.gravityScale;
        body.gravityScale = 0f;
        body.velocity = new Vector2(transform.localScale.x * dashingPower, 0f);
        tr.emitting = true;
        yield return new WaitForSeconds(dashingTime);
        tr.emitting = false;
        body.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    public void Dash()
    {
        if (grounded == true)
        {
            StartCoroutine(Dash1());
        }
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            grounded = true;
            jump = false;
            jumpInt = 0;
        }
    }
    public void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.3f);
        StopMoving();
    }
} //Public Class


