using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    protected int lives;

    public virtual void GetDamage()
    {
        lives--;
        if (lives < 1)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(this.gameObject);
    }

    public IEnumerator EnemyOnAttack(Collider2D enemy)
    {
        SpriteRenderer enemyColor = enemy.GetComponentInChildren<SpriteRenderer>();
        enemyColor.color = new Color(1f, 0.27734375f, 0.328125f);
        yield return new WaitForSeconds(0.2f);
        enemyColor.color = new Color(1, 1, 1);
    }
}

