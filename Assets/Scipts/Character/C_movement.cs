using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_movement : MonoBehaviour
{
    public C_MovementData movementData;

    private Rigidbody2D rb;
    private bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float groundCheckRadius = 0.3f;
    private Animator MovimientoAnim;
    private AudioSource walkingAudioSource;
    private AudioSource jumpAudioSource;

    private bool wasMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MovimientoAnim = GetComponent<Animator>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        walkingAudioSource = audioSources[1];
        jumpAudioSource = audioSources[2];
    }

    void Update()
    {
        Move();
        Jump();
        HandleWalkingSound();
    }

    void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        MovimientoAnim.SetFloat("Horizontal", Mathf.Abs(moveInput));

        rb.velocity = new Vector2(moveInput * movementData.moveSpeed, rb.velocity.y);

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void Jump()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        MovimientoAnim.SetBool("EnElSuelo", isGrounded);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, movementData.jumpForce);
            PlayJumpSound();
        }
    }

    void PlayJumpSound()
    {
        if (jumpAudioSource != null && !jumpAudioSource.isPlaying)
        {
            jumpAudioSource.Play();
        }
    }

    void HandleWalkingSound()
    {
        bool isMoving = Mathf.Abs(rb.velocity.x) > 0.1f && isGrounded;

        if (isMoving && !wasMoving)
        {
            walkingAudioSource.loop = true;
            walkingAudioSource.Play();
        }
        else if (!isMoving && wasMoving)
        {
            walkingAudioSource.Stop();
        }

        wasMoving = isMoving;
    }

    private void FixedUpdate()
    {
        Move();
    }
}
