using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiControl : MonoBehaviour {

    private Text times;
    private List<ScoreBoardEntry> timeList;
    public Renderer enemy;
	// Use this for initialization
	public GameObject guiReticle;
	void Start () {
        this.times = GameObject.Find("TimeText").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        if(OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.Tab)){
            times.enabled = true;
        }
        if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyUp(KeyCode.Tab))
        {
            times.enabled = false;
        }
        if (OVRInput.GetDown(OVRInput.Button.Back) || Input.GetKeyUp(KeyCode.B))
        {
			if(enemy.enabled){
                enemy.enabled = false;
            }else{
                enemy.enabled = true;
            }
        }
        if (OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad) || Input.GetKeyUp(KeyCode.V))
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
        this.times = GameObject.Find("TimeText").GetComponent<Text>();
        ScoreBoardEntry entry = buildScoreBoardEntry(time);
        this.times.text = this.times.text + "\n" + entry.ToString();
        Debug.Log(timeList.ToString());
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

    private ScoreBoardEntry buildScoreBoardEntry(TimeSpan time){
        return new ScoreBoardEntry(time, enemy, guiReticle);
    }
}
