using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkEnemy : Enemy
{
    private float speed = 3.5f;
    private Vector3 dir;
    private SpriteRenderer sprite;
    private Animator anim;
    private Collider2D col;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        dir = transform.right;
        lives = 5;
    }
    private void Update()
    {
        if (lives > 0) 
        {
            Move();
        }
    }
    private void Move()
    {
        sprite.flipX = dir.x < 0.0f;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * 0.1f + transform.right * dir.x * 0.38f, 0.1f);
        if (colliders.Length > 0) dir *= -1f;
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
        }
    }
    public override void Die()
    {
        anim.SetTrigger("death");
        gameObject.tag = "enemy_death";
        LevelController.Instance.EnemiesCount();
    }
}
