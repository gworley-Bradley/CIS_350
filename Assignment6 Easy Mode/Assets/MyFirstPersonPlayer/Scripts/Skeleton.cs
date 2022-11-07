using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Skeleton : Enemy
{

    protected int damage;

    // Start is called before the first frame update
    protected override void Awake()
    {

        base.Awake();
        health = 50f;
        damage = 10;
    }

    public override void TakeDamage(float amount)
    {
        health -= amount;
        Debug.Log(health);
        if (health <= 0f)
        {
            Die();
        }

        void Die()
        {
            if (SceneManager.GetActiveScene().name == "Introduction")
            {
                Destroy(this.gameObject);
                uiManager.tutEnemies++;
            }
            else
            {
                Destroy(this.gameObject);
                uiManager.mainEnemies++;
            }
        }
    }

    protected override void Attack(int amount)
    {
        Debug.Log("Skeleton Attacks!");
    }
}