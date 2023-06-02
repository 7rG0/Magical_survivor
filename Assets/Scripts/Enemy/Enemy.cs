using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageble
{
    private Transform targetDestination;
    private GameObject targetGameObject;
    private Player targetCharacter;
    [SerializeField] private float speed;

    private Rigidbody2D _rigidbody;
    

    [SerializeField] private int hp = 50; // изменил хп
    [SerializeField] private int damage = 5; //изменил урон
    [SerializeField] private int experiance_reward = 400;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    public void SetTarget(GameObject target)
    {
        targetGameObject = target;
        targetDestination = target.transform;
    }

    private void FixedUpdate()
    {
        Vector3 direction = (targetDestination.position - transform.position).normalized;
        _rigidbody.velocity = direction * speed;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject == targetGameObject) 
        {
            Attack();
        }
    }

    private void Attack() 
    {
        if (targetCharacter == null)
        {
            targetCharacter = targetGameObject.GetComponent<Player>();
        }

        targetCharacter.TakeDamagePlayer(damage);
    }

    public void TakeDamage(int damage) 
    {
        //Debug.Log("Enemy HP - " + hp);
        hp -= damage;
        
        if (hp < 1)
        {
            targetGameObject.GetComponent<Level>().AddExperiance(experiance_reward);
            GetComponent<DropOnDestroy>().CheckDrop();
            
            PlayerStatus.playerKills += 1;
                    
            Destroy(gameObject);
        }
    }
}
