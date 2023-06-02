using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerMovement : MonoBehaviour
{
    private Player player;

    private Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float _speed;
    [HideInInspector] public Vector2 moveDir; // переиеновал переменую
    [HideInInspector] public Vector2 lastMovingDir; //починить надо
    
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
        Move();
        CheckState();
    }

    private void Move()
    {     
        smoothedMovementInput = Vector2.SmoothDamp(smoothedMovementInput,moveDir,ref _movementInputSmoothedVelocity,0.1f);
        rigidbody.velocity = smoothedMovementInput * _speed;
        Flip();
    }

    private void CheckState()
    {
        if (moveDir.x != 0 || moveDir.y != 0)
        {
            player.playerState = PlayerState.running;
            lastMovingDir = moveDir;
        }
        else
        {
            player.playerState = PlayerState.idle; 
        }
    }

    private void OnMove(InputValue inputValue)
    {
        moveDir = inputValue.Get<Vector2>();
    }

    private void Flip()
    {
        if (moveDir.x < 0 && !spriteRenderer.flipX)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }

        else if (moveDir.x > 0 && spriteRenderer.flipX)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
        }
    }

}
