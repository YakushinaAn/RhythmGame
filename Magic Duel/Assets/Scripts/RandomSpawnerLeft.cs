﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnerLeft : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    float RandY;
    Vector2 whereToSpawn;
    [SerializeField]
    private float spawnRate = 2f;
    [SerializeField]
    float nextSpawn = 0.0f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            RandY = Random.Range(20f, 10f);
            whereToSpawn = new Vector2(-1.53f, RandY);
            Instantiate(obj, whereToSpawn, Quaternion.identity);
        }
    }
}
