using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState // состояние персонажа
{
    idle,
    running,
    dead
}

public class Player : MonoBehaviour
{
    private int maxHp = 100; // я изменил максимальное количество хп
    private int currentHp = 100;

    [SerializeField] private StatusBar hpBar;
    [SerializeField] private Animator animator;

    [HideInInspector] public Level level;
    [HideInInspector] public Gems gems;
    [HideInInspector] public Timer timer;
    [HideInInspector] public PlayerMovement playerMovement;
    [HideInInspector] public Rigidbody2D rigid;
    [HideInInspector] public SpriteRenderer _spriteRenderer;

    private CharacterGameOver characterGameOver;

    public Vector2 lastMovingDir = Vector2.right; // вот тут исправлен баг со снарядами, летающими на месте

    public PlayerState playerState;

    private float speed = 3f;

    //private bool isDead;    не нужен больше


    private void Awake()
    {
        level = GetComponent<Level>();
        gems = GetComponent<Gems>();
        timer = GetComponent<Timer>();
        playerMovement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        characterGameOver = GetComponent<CharacterGameOver>();
    }

    private void Start()
    {
        hpBar.SetState(currentHp, maxHp); 
    }

    private void FixedUpdate()
    {
        print(GameInput.gameInput.GetCurrentMousePos());
        /*if (playerState != PlayerState.dead) {
            Move();
        }*/
        UpdateAnimation(); // постоянно обновляет анимацию персонажа  
    }

  
   /* private void Move() // Метод движения
    {
        Vector2 moveDir = Vector2.zero;
        moveDir.x = Input.GetAxisRaw("Horizontal");
        moveDir.y = Input.GetAxisRaw("Vertical");
        //вот тут надо сглаживание вставить
        moveDir = moveDir.normalized;

        rigid.velocity = moveDir * speed;

        if (rigid.velocity.x != 0 || rigid.velocity.y != 0) playerState = PlayerState.running; //потом надо будет изменить условие, наверное, другого не придумал
        else playerState = PlayerState.idle;

        //изменение поворота стпрайта игрока
        if (moveDir.x < 0 && !_spriteRenderer.flipX)
        {
            FlipSprite();
            lastMovingDir = moveDir;
        }
        else if (moveDir.x > 0 && _spriteRenderer.flipX){
            FlipSprite();
            lastMovingDir = moveDir;
        }
        

    }*/

    public void TakeDamagePlayer(int damage) 
    {
        if (playerState == PlayerState.dead) return; //new
        
        currentHp -= damage;
        if (currentHp <= 0)
        {
            characterGameOver.GetComponent<CharacterGameOver>().GameOver(); 
            timer.StopTimer();
            playerState = PlayerState.dead;
        }
        hpBar.SetState(currentHp, maxHp);
    }

    public void Heal(int amount)
    {
        if (currentHp <= 0) { return; }

        currentHp += amount;
        if (currentHp > maxHp) 
        {
            currentHp = maxHp;
        }
        hpBar.SetState(currentHp, maxHp);
    }
    public void UpdateAnimation()  //переделал метод, меняющий анимацию. Переместил его в этот класс, вместо PlayerMoving
    {
        animator.SetInteger("state", (int) playerState);      
    }
    private void FlipSprite()
    {
        _spriteRenderer.flipX = !_spriteRenderer.flipX;
    }
}
