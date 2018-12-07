using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInitializer : MonoBehaviour
{

    List<Enemy> enemies = new List<Enemy>();


    public List<Enemy> InitializeEnemyList(GameObject enemy)
    {
        enemies = new List<Enemy>();
        Enemy wow = new Enemy(enemy, 0, 0, 0);
        enemies.Add(wow);
        return enemies;
    }

    public void toggleSimpleDisplay()
    {
        enemies.ForEach(enemy =>
        {
            enemy.toggleSimple();
        });
    }

    public void toggleComplexDisplay()
    {
        enemies.ForEach(enemy =>
        {
            enemy.toggleComplex();
        });
    }

    public void disableAllEnemies()
    {
        enemies.ForEach(enemy =>
        {
            enemy.gameObject.SetActive(false);
        });
    }

    public void enableAllEnemies()
    {
        enemies.ForEach(enemy =>
        {
            enemy.gameObject.SetActive(true);
        });
    }




}
