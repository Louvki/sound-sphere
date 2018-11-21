using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayHit : MonoBehaviour {


    float timer = 0;
    public Image LoadingBar;
    float currentValue;
    private float speed = 160;
    private float distanceBetweenEnemiesSpawns = 5;


    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)){
            
			timer += Time.deltaTime;

			if(hit.transform.name.Equals("Enemy")){
				HitCircleAnim(hit.transform.gameObject);
			}
		}else{
            ResetCircleAnim();
        };

	}

	void HitCircleAnim (GameObject hit) {
        if (currentValue <= 100)
        {
            currentValue += speed * Time.deltaTime;
            LoadingBar.fillAmount = currentValue / 100;
		} else {
            ResetCircleAnim();
            SpawnNewHit(hit.transform.gameObject);
        }


    }

	void ResetCircleAnim(){
        timer = 0;
        LoadingBar.fillAmount = 0f;
        currentValue = 0;
	}

    void SpawnNewHit(GameObject hit){
        Vector3 newPos = GenerateNewEnemySpawn();

        while(Vector3.Distance(hit.transform.position, newPos) < distanceBetweenEnemiesSpawns){
            newPos = GenerateNewEnemySpawn();
        }

        hit.transform.position = newPos;

    }

    Vector3 GenerateNewEnemySpawn(){
        return Random.insideUnitSphere * distanceBetweenEnemiesSpawns;
    }
}
