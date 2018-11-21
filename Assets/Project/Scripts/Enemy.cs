using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    private float distanceBetweenEnemiesSpawns = 5;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    public void SpawnNewHit(GameObject hit)
    {
        Vector3 newPos = GenerateNewEnemySpawn();

        while (Vector3.Distance(hit.transform.position, newPos) < distanceBetweenEnemiesSpawns)
        {
            newPos = GenerateNewEnemySpawn();
        }

        hit.transform.position = newPos;

    }

    Vector3 GenerateNewEnemySpawn()
    {
        return Random.insideUnitSphere * distanceBetweenEnemiesSpawns;
    }
}
