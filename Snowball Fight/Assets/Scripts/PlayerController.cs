using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public KeyCode left;
    public KeyCode right;
    public KeyCode jump;
    public KeyCode throwBall;

    private Rigidbody2D theRB;

    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public LayerMask WhatIsGround;

    public bool isGrounded;

    private Animator anim;

    public GameObject snowBall;
    public Transform throwPoint;

    public AudioSource throwSound;

    private bool canThrow = true;
    public float throwCooldown = 1.0f;
    private float throwTimer = 0.0f;

    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, WhatIsGround);

        if (Input.GetKey(left))
        {
            theRB.velocity = new Vector2(-moveSpeed, theRB.velocity.y);
        }
        else if (Input.GetKey(right))
        {
            theRB.velocity = new Vector2(moveSpeed, theRB.velocity.y);
        }
        else
        {
            theRB.velocity = new Vector2(0, theRB.velocity.y);
        }

        if (Input.GetKeyDown(jump) && isGrounded)
        {
            theRB.velocity = new Vector2(theRB.velocity.x, jumpForce);
        }

        // Check if the player can throw a snowball
        if (canThrow && Input.GetKeyDown(throwBall))
        {
            // Instantiate the snowball and set other properties
            GameObject ballClone = Instantiate(snowBall, throwPoint.position, throwPoint.rotation);
            ballClone.transform.localScale = transform.localScale;
            anim.SetTrigger("Throw");
            throwSound.Play();

            // Set a cooldown before the player can throw another snowball
            canThrow = false;
            throwTimer = throwCooldown;
        }

        // Update the throw cooldown timer
        if (!canThrow)
        {
            throwTimer -= Time.deltaTime;
            if (throwTimer <= 0)
            {
                canThrow = true;
            }
        }

        if (theRB.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (theRB.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        anim.SetFloat("Speed", Mathf.Abs(theRB.velocity.x));
        anim.SetBool("Grounded", isGrounded);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "JumpPowerUp")
        {
            Destroy(collision.gameObject);
            jumpForce = 25f;
            GetComponent<SpriteRenderer>().color = Color.blue;
            StartCoroutine(ResetPower());
        }
        if (collision.tag == "SpeedPowerUp")
        {
            Destroy(collision.gameObject);
            moveSpeed = 10f;
            GetComponent<SpriteRenderer>().color = Color.yellow;
            StartCoroutine(ResetPower());
        }
        if (collision.tag == "SlowPowerUp")
        {
            Destroy(collision.gameObject);
            moveSpeed = 5f;
            GetComponent<SpriteRenderer>().color = Color.green;
            StartCoroutine(ResetPower());
        }
    }

    private IEnumerator ResetPower()
    {
        yield return new WaitForSeconds(5);
        jumpForce = 17;
        moveSpeed = 8;
        GetComponent<SpriteRenderer>().color = Color.white;
    }
}
