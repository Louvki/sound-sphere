using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_Hit : MonoBehaviour {


    float holdTime = 1.0f;
    float timer = 0;

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;

		if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)){

			timer += Time.deltaTime;

			if(hit.transform.name.Equals("Enemy")){
				Debug.Log("Enemy was hit");
                if (timer > holdTime){
                    Destroy(hit.transform.gameObject);
                    Debug.Log("Enemy was destroyed");
                }
			};
		};

	}
}
