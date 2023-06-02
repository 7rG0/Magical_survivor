using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileWeapon : MonoBehaviour
{
    [SerializeField] private float timeToAttack;
    private float timer;

    private Player player; //new
    private PlayerMovement playerMovement;

    [SerializeField] private GameObject ProjectileFrefab;

    private void Awake()
    {
        player = GetComponentInParent<Player>(); //new
        playerMovement = GetComponentInParent<PlayerMovement>();
    }
    private void Update()
    {
        if (timer < timeToAttack)
        {
            timer += Time.deltaTime;
            return;
        }

        if (Input.GetMouseButtonDown(1))
        {
            SpawnProjectile();
            timer = 1;
        }
    }

    private void SpawnProjectile()
    {
        GameObject thrownProjectile = Instantiate(ProjectileFrefab);
        thrownProjectile.transform.position = transform.position;
        
    }
}
