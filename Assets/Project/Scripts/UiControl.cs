using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiControl : MonoBehaviour {

    public Text times;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)){
            times.gameObject.SetActive(true);
		}
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
            times.gameObject.SetActive(false);
        }
    }
}
