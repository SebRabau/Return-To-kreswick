using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushback : MonoBehaviour {

    public float force = 1;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Vector3 pushDirection = other.transform.position - transform.position;
            pushDirection = -pushDirection.normalized;
            GetComponent<Rigidbody>().AddForce(pushDirection * force * 100);
        }
    }


}
