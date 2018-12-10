using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject player;

    public void setDisplay(EnemyDisplay display, bool r)
    {
        switch (display)
        {
            case EnemyDisplay.Complex:
                toggleComplex(r);
                break;
            case EnemyDisplay.Invisible:
                toggleInvisible();
                break;
            case EnemyDisplay.Simple:
                toggleSimple();
                break;
        }
    }

    private void toggleInvisible()
    {
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(false);
        }
    }


    private void toggleComplex(bool r)
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Simple")
            {
                child.gameObject.SetActive(false);
            }

            if (child.name == "Happy")
            {
                child.gameObject.SetActive(r);
                child.transform.LookAt(player.transform);
            }
            if (child.name == "Angry")
            {
                child.gameObject.SetActive(!r);
                child.transform.LookAt(player.transform);
            }
        }
    }

    private void toggleSimple()
    {
        foreach (Transform child in transform)
        {
            if (child.name == "Happy" || child.name == "Angry")
            {
                child.gameObject.SetActive(false);
            };
            if (child.name == "Simple")
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}

public enum EnemyDisplay
{
    Invisible = 1,
    Simple = 2,
    Complex = 3,
}
