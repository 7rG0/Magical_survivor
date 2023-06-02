using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector3 direction;
    private Rigidbody2D rigid;

    [SerializeField] private float speed;
    [SerializeField] private int damage = 400;

    bool hitDetected = false;


    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        SetDirection();
    }
    private void Update()
    {
        rigid.velocity = direction * speed;
        if (Time.frameCount % 6 == 0) 
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, 0.3f);
            foreach (Collider2D c in hit)
            {
                Enemy enemy = c.GetComponent<Enemy>();
                if (enemy != null)
                {
                    enemy.TakeDamage(damage);
                    hitDetected = true;
                    break;
                }
            }
            if (hitDetected == true)
            {
                Destroy(gameObject);
            }
        }
    }

    public void SetDirection()
    {
       Vector2 destination = GameInput.gameInput.GetCurrentMousePos(); //получаем координаты мышки 
       direction = (destination - (Vector2) transform.position).normalized; // делаем вектор от игрока к мышке
    }
}
