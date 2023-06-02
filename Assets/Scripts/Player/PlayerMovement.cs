using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Player player;

    private Rigidbody2D rigidbody;
    [HideInInspector] public Vector2 moveDir = Vector3.right; // переиеновал переменую
    [HideInInspector] public float lastMovingDir;
    

    private SpriteRenderer spriteRenderer;
    
    private Vector2 smoothedMovementInput;
    private Vector2 _movementInputSmoothedVelocity;
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        player = GetComponent<Player>();
    }

    private void FixedUpdate()
    {
        if (player.playerState == PlayerState.dead) return;

        smoothedMovementInput = Vector2.SmoothDamp(
            smoothedMovementInput,
            moveDir,
            ref _movementInputSmoothedVelocity,
            0.1f);

        rigidbody.velocity = smoothedMovementInput * _speed;

        if (moveDir.x < 0 && !spriteRenderer.flipX)
        {
            Flip();
        }
           
        else if (moveDir.x > 0 && spriteRenderer.flipX)
        {
            Flip();
        }
    }

    private void OnMove(InputValue inputValue)
    {
        moveDir = inputValue.Get<Vector2>();
    }

    

    //new code
    private void Update()
    {
        
        // gjghfdbnm
        

        

        if (moveDir.x != 0 || moveDir.y != 0)
        {
            player.playerState = PlayerState.running; //new
        }
        else 
        {
            player.playerState = PlayerState.idle; //new
        }

    }

    private void Flip()
    {
        spriteRenderer.flipX = !spriteRenderer.flipX;
    }
}
