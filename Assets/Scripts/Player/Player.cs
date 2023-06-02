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
    public PlayerState playerState;

    private int maxHp = 70; // я изменил максимальное количество хп
    private int currentHp = 70;
    private float speed = 3f;

    [SerializeField] private StatusBar hpBar;
    [SerializeField] private Animator animator;

    public Level level;
    public Gems gems;
    public Timer timer;

    private PlayerMovement playerMovement;
    private Rigidbody2D rigid;
    private SpriteRenderer _spriteRenderer;
    private CharacterGameOver characterGameOver;

    private Vector2 lastMovingDir = Vector2.right; // вот тут исправлен баг со снарядами, летающими на месте

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
        UpdateAnimation(); // постоянно обновляет анимацию персонажа  
    }

    public void TakeDamagePlayer(int damage) 
    {
        if (playerState == PlayerState.dead) return; //new
        
        currentHp -= damage;
        if (currentHp <= 0)
        {
            characterGameOver.GameOver(); 
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
}
