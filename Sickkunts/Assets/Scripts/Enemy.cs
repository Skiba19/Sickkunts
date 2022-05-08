using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float startSpeed=2f;
    [HideInInspector]
    public float speed;
    public float startHealth=100f;
    private float health;
    public int value=50;
    public GameObject deathEffect;
    [Header("Unity Stuff")]
    public Image healthBar;
    void Start()
    {
        speed=startSpeed;
        health=startHealth;
    }
    public void TakeDamage(float amount)
    {
        health-=amount;
        healthBar.fillAmount=health/startHealth;
        if(health<=0)
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
