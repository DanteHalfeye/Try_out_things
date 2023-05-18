using System;
using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private SpriteRenderer spRenderer;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private bool isWallsliding, isFacingRight, isJumping;
    [Space]
    [SerializeField] private float speed = 8f, jumpForce = 16f, jumpForcePressed = 0.5f, desireJumpHigh = 4f, wallSlideSpeed= 2f, jumpBufferTime = 0.2f,jumpBufferCounter, coyoteTime = 0.2f, coyoteTimeCounter;
    [Header("Checkers")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform rightCheck;
    [Space]
    [SerializeField] private LayerMask groudLayer;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private Animator anim;

    //UTILIDAD
    private Vector2 axis = Vector2.zero;
    private byte zero = 0;
    private float groundCollRad = 0.2f, timer = 0;
    private bool canSound = true;

    private void Awake()
    {
        isFacingRight = true;
    }

    void Update()
    {    
        jumpForce = Mathf.Sqrt(desireJumpHigh * Physics2D.gravity.y * -2) * rb.mass;
        Flip();
        InputDetection();
        
        Jump();
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (timer > 0 && !canSound)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                canSound = true; 
            }
        }
    }

    #region Methods

    private void FixedUpdate()
    {
        //Modifica la velocidad del cuerpo rigido del jugador para moverlo respectivamente
        rb.velocity = new Vector2(axis.x * speed, rb.velocity.y );
        Wallslide();
    }
    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f && !isJumping)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            jumpBufferCounter = 0f;

            StartCoroutine(JumpCooldown());
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);

            coyoteTimeCounter = 0f;
        }
    }
    void InputDetection()
    {
        //Se asigna el valor de respectivo eje dependiendo del input en los ejes X y Y del jugador.
        axis.x = Input.GetAxisRaw("Horizontal");
        anim.SetBool("run", axis.x != 0f);
        axis.y = Input.GetAxisRaw("Vertical");
        
    }
    private void Flip()
    {
        //Se gira la escala del personaje para solo usar un check
        if (isFacingRight && axis.x < 0f || !isFacingRight && axis.x > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    bool IsWalled()
    {
        //Se comprueba si est[a tocando una pared en un radio especifico y si esta pared tiene el layer ground
        return Physics2D.OverlapCircle(rightCheck.position, 0.2f, groudLayer);
    }

    void Wallslide()
    {
        //Se evalua que est� tocando una pared, no est� en el suelo y que haya input horizontal para empezar el slide
        if (IsWalled() && !IsGrounded() && axis.x != 0f)
        {
            isWallsliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y + -1f, -wallSlideSpeed, float.MaxValue));
            
        }
        else
        {
            isWallsliding = false;
        }
    }
    bool IsGrounded()
    {
        //Revisa la permanencia del jugador 
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groudLayer);
    }

    private IEnumerator JumpCooldown()
    {
        isJumping = true;
        yield return new WaitForSeconds(0.4f);
        isJumping = false;
    }
    #endregion

    #region Editor

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(groundCheck.position, 0.2f);
        Gizmos.DrawSphere(rightCheck.position, 0.2f);
       
    }

    #endregion
}
