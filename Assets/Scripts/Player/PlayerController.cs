using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 12f;

    [Header("Jump Settings")]
    public float airSpeedThreshold = 1f;
    public int maxJumps = 2;

    private Rigidbody2D rb;
    private int jumpCount;
    private bool isGrounded;

    [Header("Ground Check Settings")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;

    [SerializeField] private Animator anim;

    float moveInput;

    [Header("Musics")]
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip collectSfx;
    [SerializeField] private AudioClip deathSfx;
    [SerializeField] private AudioClip jumpSfx;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovePlayer();
        HandleJump();


        if (Mathf.Abs(rb.velocity.x)< 0.1f && isGrounded)
        {
            anim.SetBool("IsWalk", false);
        }


        if (!isGrounded)
        {
            if (rb.velocity.y > airSpeedThreshold)
            {
                anim.SetFloat("IsJumping", 1f);
            }
            if (rb.velocity.y < -airSpeedThreshold)
            {
                anim.SetFloat("IsJumping", 2f);
            }
        }
        else
        {
            anim.SetFloat("IsJumping", 0f);
        }
    }
    private void MovePlayer()
    {
        moveInput = Input.GetAxis("Horizontal");
        Vector2 velocity = rb.velocity;
        velocity.x = moveInput * moveSpeed;
        rb.velocity = velocity;
        anim.SetBool("IsWalk", true);

        if (moveInput != 0)
        {
            transform.localScale = new Vector3(Mathf.Sign(moveInput), 1, 1);
        }
    }

    private void HandleJump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (isGrounded)
        {
            jumpCount = 0;
        }

        if (Input.GetButtonDown("Jump") && (isGrounded || jumpCount < maxJumps))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumpCount++;
            anim.SetFloat("IsJumping", 0f);
            audioSource.PlayOneShot(jumpSfx);
        }

        
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Gift"))
        {
            GameManager.Instance.CollectGift();
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(collectSfx);
        }

        if (collision.CompareTag("Enemy") || collision.CompareTag("Sea"))
        {
            audioSource.PlayOneShot(deathSfx);
            StartCoroutine(DeathDelay());

        }

        if (collision.CompareTag("Level1"))
        {
            audioSource.PlayOneShot(collectSfx);
            GameManager.Instance.GoToLevel2();
        }
    }

    IEnumerator DeathDelay()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.RestartLevel();
    }



}
