using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiControl : MonoBehaviour {

    public Text times;
    public Renderer enemy;
	// Use this for initialization
	public GameObject guiReticle;
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
        if (OVRInput.GetDown(OVRInput.Button.Back))
        {
			if(enemy.enabled){
                enemy.enabled = false;
            }else{
                enemy.enabled = true;
            }
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad))
        {
            if (guiReticle.gameObject.activeSelf)
            {
                guiReticle.gameObject.SetActive(false);
            }
            else
            {
                guiReticle.gameObject.SetActive(true);
            }
        }
    }
}
