using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject enemy1;
    public GameObject enemy2;

    public Transform enemyPos;
    public float repeatRate = 5.0f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            InvokeRepeating("EnemySpawner", 0.5f, repeatRate);
            GameObject.Destroy(gameObject, 10f);
            gameObject.GetComponent<BoxCollider>().enabled = false;

        }
    }

    void EnemySpawner()
    {
        Instantiate(enemy1, enemyPos.position, enemyPos.rotation);
        Instantiate(enemy2, enemyPos.position, enemyPos.rotation);

    }


}
