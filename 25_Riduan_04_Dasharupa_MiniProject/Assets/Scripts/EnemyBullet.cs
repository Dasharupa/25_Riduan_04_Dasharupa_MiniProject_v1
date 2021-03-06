﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    GameObject target;
    public float speed;
    Rigidbody2D bulletRB;

    [Tooltip("Damage on player on touch")]
    public int ContactDamage;

    // Start is called before the first frame update
    void Start()
    {
        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(this.gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
