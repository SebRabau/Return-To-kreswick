using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour {

    public int Hurt = 1;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Vector3 damageDirection = other.transform.position - transform.position;
            damageDirection = damageDirection.normalized;
            FindObjectOfType<PlayerHealth>().DamagePlayer(Hurt, damageDirection);
        }
    }
}
