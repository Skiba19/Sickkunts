using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed=5f;
    private Transform target;
    private int wavepointIndex=0;
    public int heath=100;
    public int value=50;
    public GameObject deathEffect;
    void Start()
    {
        target=Waypoints.points[0];
    }
    void Update()
    {
        Vector3 dir=target.position-transform.position;
        transform.Translate(dir.normalized*speed*Time.deltaTime,Space.World);
        if(Vector3.Distance(transform.position, target.position)<=0.1f)
        {
            GetNextWaypoint();
        }
    }
    public void TakeDamage(int amount)
    {
        heath-=amount;
        if(heath<=0)
        {
            Die();
        }
    }
    private void Die()
    {
        PlayerStats.Money+=value;

        GameObject effect=(GameObject)Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect,5f);
        
        Destroy(gameObject);
    }
    void GetNextWaypoint()
    {
        if(wavepointIndex>=Waypoints.points.Length-1)
        {
            EndPath();
            return;
        }
        wavepointIndex++;
        target=Waypoints.points[wavepointIndex];
    }
    void EndPath()
    {
        PlayerStats.Lives--;
        Destroy(gameObject);
    }
}
