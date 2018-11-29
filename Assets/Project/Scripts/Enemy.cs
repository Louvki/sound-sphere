using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    private float distanceBetweenEnemiesSpawns = 5;
    public int numberOfBoxes = 5;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void SpawnNewHit(GameObject hit)
    {
        List<Vector3> positions = new List<Vector3>();

        deSpawnBoxes();

        while (positions.Count < numberOfBoxes)
        {

            Vector3 newPos = GenerateNewEnemySpawn();

            if (Vector3.Distance(hit.transform.position, newPos) > distanceBetweenEnemiesSpawns)
            {
                positions.Add(newPos);
            }
        }


        int randInt = Random.Range(1, numberOfBoxes);
        positions.ForEach(x =>
        {
            GameObject box = Instantiate(hit, x, Quaternion.identity);
            if(positions.IndexOf(x) == randInt)
            {
                box.transform.name = "Enemy";
            }
        });
    }

    private void deSpawnBoxes()
    {
        List<GameObject> boxList = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        boxList.ForEach(x => Destroy(x));
    }

    Vector3 GenerateNewEnemySpawn()
    {
        return Random.insideUnitSphere * distanceBetweenEnemiesSpawns;
    }
}
