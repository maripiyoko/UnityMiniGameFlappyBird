﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnner : MonoBehaviour
{
    public float queueTime = 1.5F;
    private float time = 0.0F;
    public GameObject obstacle;
    public GameManager gameManager;

    public float height;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameStarted()) {
            if (time > queueTime) {
		        GameObject go = Instantiate(obstacle);
		        go.transform.position = transform.position + new Vector3(0, Random.Range(-height, height), 0);

		        time = 0;
		        Destroy(go, 10);
	        }
	        time += Time.deltaTime;
        }
    }
}
