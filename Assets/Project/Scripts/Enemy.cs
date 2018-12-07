using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject enemy;

    public Enemy(GameObject enemy, float x, float y, float z)
    {
        this.enemy = enemy;
        Instantiate(enemy, new Vector3(x, y, z), Quaternion.identity);
    }

    public void toggleComplex()
    {
        foreach (Transform child in enemy.transform)
        {
            if (child.name == "Simple")
            {
                child.gameObject.SetActive(false);
            } else {
                System.Random r = new System.Random();
                int happyOrAngry = r.Next(1);

                if (happyOrAngry == 1)
                {
                    child.gameObject.SetActive(false);
                } else
                {
                    child.gameObject.SetActive(true);
                }
            }
        }
    }

    public void toggleSimple()
    {
        foreach (Transform child in enemy.transform)
        {
            if (child.name == "Happy" || child.name == "Angry" ) {
                child.gameObject.SetActive(false);
            };
            if(child.name == "Simple")
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}

