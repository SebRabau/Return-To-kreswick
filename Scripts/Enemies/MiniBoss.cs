using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBoss : Enemy
{
    public int _mhealth = 10;
    public int _dps = 10;

    // Use this for initialization
    void Start()
    {
        base.InitStats(_mhealth - (Movement.LP * 10), _dps);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Vector3 damageDirection = collision.transform.position - transform.position;
            damageDirection = damageDirection.normalized;
            FindObjectOfType<PlayerHealth>().DamagePlayer(_dps, damageDirection);

        }
    }
}


