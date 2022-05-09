using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    private int wavepointIndex=0;
    private Enemy enemy;
    public Transform partToRotate;
    void Start()
    {
        enemy=GetComponent<Enemy>();
        target=Waypoints.points[0];
    }
    void Update()
    {
        
        Vector3 dir=target.position-transform.position;
        transform.Translate(dir.normalized*enemy.speed*Time.deltaTime,Space.World);
        Quaternion lookRotation=Quaternion.LookRotation(dir);
        Vector3 rotation=Quaternion.Lerp(partToRotate.rotation, lookRotation, 0.1f).eulerAngles;
        partToRotate.rotation=Quaternion.Euler(0f,rotation.y,0f); 
        if(Vector3.Distance(transform.position, target.position)<=0.1f)
        {
            GetNextWaypoint();
        }
        enemy.speed=enemy.startSpeed;
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
        WaveSpawner.EnemiesAlive--;
        Destroy(gameObject);
    }
}
