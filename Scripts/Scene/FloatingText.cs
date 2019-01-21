﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingText : MonoBehaviour {

    public float DestroyTime = 0.5f;
    public Vector3 Offset = new Vector3(1, 0, 0);
    public Vector3 RandomizeIntensity = new Vector3(1, 0, 0);

	// Use this for initialization
	void Start () {

        Object.Destroy(gameObject, DestroyTime);

        transform.localPosition += Offset;

        transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.x)
            ,Random.Range(-RandomizeIntensity.y, RandomizeIntensity.y),
            Random.Range(-RandomizeIntensity.z, RandomizeIntensity.z));

    }
}