/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;


    private UIManager uiManager;

    private void Start()
    {
        uiManager = GameObject.FindObjectOfType<UIManager>();

    }
    public void TakeDamage(float  amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }

        void Die()
        {
            uiManager.skeletons++;
            Destroy(gameObject);
        }
    }
}
*/