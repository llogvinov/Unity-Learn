using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnimator;
    private AudioSource playerAudio;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpClip;
    public AudioClip crushClip;

    [SerializeField]
    private float jumpForce = 15;
    [SerializeField]
    private float gravityModifier = 3;
    [SerializeField]
    private bool isOnGround = true;

    private float score = 0;

    public bool gameOver = false;
    public bool canDoubleJump = false;

    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) & !gameOver)
        {
            if (isOnGround)
            {
                playerAudio.PlayOneShot(jumpClip, 1);
                isOnGround = false;
                playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                playerAnimator.SetTrigger("Jump_trig");
                dirtParticle.Stop();
                canDoubleJump = true;
            }
            else if (canDoubleJump)
            {
                canDoubleJump = false;
                playerAudio.PlayOneShot(jumpClip, 1);
                playerRb.AddForce(Vector3.up * jumpForce / 1.5f, ForceMode.Impulse);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) & !gameOver)
        {
            MoveLeft.speed *= 2.5f;
            score += 0.04f;
            Debug.Log(score);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) & !gameOver)
        {
            MoveLeft.speed /= 2.5f;
            score += 0.02f;
            Debug.Log(score);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if (!gameOver)
            {
                isOnGround = true;
                dirtParticle.Play();
            }
        }
        else
        {
            playerAudio.PlayOneShot(crushClip, 1);
            gameOver = true;
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 2);
            dirtParticle.Stop();
            explosionParticle.Play();
        }
    }
}
