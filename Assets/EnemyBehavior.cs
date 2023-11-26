using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    public Transform player;
    public Transform patrolRoute;
    public List<Transform> locations;

    private int locationIndex = 0;
    private NavMeshAgent agent;

    private int _lives = 3;
    public int EnemyLives
    {
        get
        {
            return _lives;
        }
        set
        {
            _lives = value;
            if (_lives <= 0)
            {
                Destroy(this.gameObject);
                Debug.Log("EnemyDown");
            }
        }
    }
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InitializePatrolRoute();
        MoveToNextPatrolLocation();

        player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        if (agent.remainingDistance < 0.2f && !agent.pathPending)
        {

            MoveToNextPatrolLocation();
        }
    }
    private void MoveToNextPatrolLocation()
    {
        if (locations.Count == 0)
        {

            return;
        }
        agent.destination = locations[locationIndex].position;
        locationIndex = (locationIndex + 1) % locations.Count;
    }

    void InitializePatrolRoute()
    {
        foreach (Transform child in patrolRoute)
        {
            locations.Add(child);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            agent.destination = player.position;
            Debug.Log("Player detected - attack!");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player out of range - patrol");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Bullet(Clone)")
        {
            EnemyLives -= 1;
            Debug.Log("Critical");
        }
    }
}
