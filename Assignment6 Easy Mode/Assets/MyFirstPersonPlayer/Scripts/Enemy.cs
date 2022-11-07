using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{

    protected float speed;
    protected float health;
    protected UIManager uiManager;

    // [SerializeField] protected Weapon weapon;


    protected virtual void Awake()
    {
        //weapon = gameObject.AddComponent<Weapon>();
        uiManager = GameObject.FindObjectOfType<UIManager>();
        speed = 5f;
        health = 100f;
    }

    protected abstract void Attack(int amount);

    public abstract void TakeDamage(float amount);
}
