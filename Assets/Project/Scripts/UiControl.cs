using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiControl : MonoBehaviour {

    private Text times;
    private List<ScoreBoardEntry> timeList;
    public List<Renderer> enemyList;
	// Use this for initialization
	public GameObject guiReticle;

    void Awake(){}

	void Start () {
        //this.times = GameObject.Find("TimeText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Tab)){
            //times.enabled = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyUp(KeyCode.Tab))
        {
            //times.enabled = false;
        }
        if (OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyUp(KeyCode.B))
        {
			if(enemyList[0].enabled){
                enemyList[0].enabled = false;
            }else{
                enemyList[0].enabled = true;
            }
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyUp(KeyCode.Tab))
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

    public void addTimeToText(TimeSpan time){
        //this.times = GameObject.Find("TimeText").GetComponent<Text>();

        List<Renderer> fuckList = new List<Renderer>();
        new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy")).ForEach(x =>
        {
            fuckList.Add(x.GetComponent<Renderer>());
        });

        GameObject reticle = GameObject.Find("GUIReticle");

        //this.times.text = this.times.text + "\n"
        // + time + "   " 
        // + fuckList[0].enabled 
        // + "   " + reticle.gameObject.activeSelf + "\n";
    }

    public class ScoreBoardEntry{
        TimeSpan time;
        bool boxesEnabled;
        bool reticleEnabled;

        public ScoreBoardEntry(TimeSpan time, bool boxesEnabled, bool reticleEnabled){
            this.time = time;
            this.boxesEnabled = boxesEnabled;
            this.reticleEnabled = reticleEnabled;
        }

        public override string ToString()
        {
            return this.time + "   " + this.boxesEnabled + "   " + this.reticleEnabled + "\n";
        }
    }
}
