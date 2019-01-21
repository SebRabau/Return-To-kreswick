﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class RunnAway : MonoBehaviour {

    private NavMeshAgent _agent;
    public GameObject Player;
    public float EnemyDistanceRun = 4.0f;


    // Use this for initialization
    void Start() {
        _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, Player.transform.position);


        if (distance < EnemyDistanceRun)
        {
            Vector3 disToPlayer = transform.position - Player.transform.position;
            Vector3 newPos = transform.position + disToPlayer;
            _agent.SetDestination(newPos);

        }
    }

        
}
