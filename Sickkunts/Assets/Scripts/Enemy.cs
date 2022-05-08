using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float startSpeed=2f;
    [HideInInspector]
    public float speed;
    public float heath=100f;
    public int value=50;
    public GameObject deathEffect;
    
    void Start()
    {
        speed=startSpeed;
    }
    public void TakeDamage(float amount)
    {
        heath-=amount;
        if(heath<=0)
        {
            Die();
        }
    }
    public void Slow(float pct)
    {
        speed=startSpeed*(1f-pct);
    }
    private void Die()
    {
        PlayerStats.Money+=value;

        GameObject effect=(GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect,5f);
        
        Destroy(gameObject);
    }
}
