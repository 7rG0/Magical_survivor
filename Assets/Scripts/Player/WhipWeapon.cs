using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WhipWeapon : MonoBehaviour
{
    private float timeToAttack = 2f;
    private float timer;

    [SerializeField] private GameObject leftWhipObject;
    [SerializeField] private GameObject rightWhipObject;

    private Player player; //new
    private PlayerMovement playerMovement;
    [SerializeField] private Vector2 whipAttackSize = new Vector2(4,2f);
    [SerializeField] private int whipDamage = 400;

    private void Awake()
    {
        player = GetComponentInParent<Player>(); //new
        playerMovement = GetComponentInParent<PlayerMovement>();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && timer < 0f) 
        {
            
            Attack();
        }
    }

    private void Attack()
    {
        timer = timeToAttack;

        if (playerMovement.lastMovingDir.x > 0) //new
        {
            rightWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(rightWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
        else if (playerMovement.lastMovingDir.x < 0) // new
        {
            leftWhipObject.SetActive(true);
            Collider2D[] colliders = Physics2D.OverlapBoxAll(leftWhipObject.transform.position, whipAttackSize, 0f);
            ApplyDamage(colliders);
        }
    }

    private void ApplyDamage(Collider2D[] colliders)
    {
        for (int i = 0; i < colliders.Length; i++)
        {
            IDamageble e = colliders[i].GetComponent<IDamageble>();
            if (e != null)
            {
                e.TakeDamage(whipDamage);
            }
        }
    }
}
