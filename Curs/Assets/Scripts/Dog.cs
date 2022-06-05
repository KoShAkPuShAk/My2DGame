using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : Enemy
{
    private Animator anim;
    private Collider2D col;

    private void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        lives = 3;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (lives > 0 && collision.gameObject == Hero.Instance.gameObject) 
        {
            Hero.Instance.GetDamage();
            lives--;
        }

        if (lives < 1) 
        {
            Die();
        }
    }

    public override void Die()
    {
        col.isTrigger = true;
        anim.SetTrigger("death");
        gameObject.tag = "enemy_death";
        LevelController.Instance.EnemiesCount();
    }
}
