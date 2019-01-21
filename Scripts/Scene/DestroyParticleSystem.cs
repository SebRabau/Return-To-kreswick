using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticleSystem : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Destroy(gameObject, GetComponent<ParticleSystem>().duration + 1);
    }
}
