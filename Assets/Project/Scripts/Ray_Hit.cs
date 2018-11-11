using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ray_Hit : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;

		if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)){
			Debug.Log(hit.transform.name + " was hit!");
		};

	}
}
