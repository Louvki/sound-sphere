using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ray_Hit : MonoBehaviour {


    float timer = 0;
    public Image LoadingBar;
    float currentValue;
    public float speed;
    SphereCollider GameRoom;

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
        SphereCollider GameRoom = GameObject.FindGameObjectWithTag("GameRoom").GetComponent<SphereCollider>();

        Vector3 spawn = new Vector3((Random.value * 2 - 1) * GameRoom.radius,
              (Random.value * 2 - 1) * GameRoom.radius,
             (Random.value * 2 - 1) * GameRoom.radius);

        hit.transform.position = spawn;

	}
}
