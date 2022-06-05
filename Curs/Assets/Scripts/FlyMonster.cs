using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class FlyMonster : Enemy
{
    private SpriteRenderer sprite;
    private Animator anim;
    private Collider2D col;
    [SerializeField] private AIPath aiPath;

    private void Awake()
    {
        sprite = GetComponentInChildren<SpriteRenderer>();
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        aiPath = GetComponent<AIPath>();
        lives = 2;
    }

    private void Update()
    {
        sprite.flipX = aiPath.desiredVelocity.x <= 0.01f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject == Hero.Instance.gameObject)
        {
            Hero.Instance.GetDamage();
        }
    }

    public override void Die()
    {
        col.isTrigger = true;
        aiPath.enabled = false;
        anim.SetTrigger("death");
        gameObject.tag = "enemy_death";
        LevelController.Instance.EnemiesCount();
    }
}
