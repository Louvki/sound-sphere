

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StopWatchHelper : MonoBehaviour {

    public Stopwatch sw = new Stopwatch();
    UiControl uiCtrl = new UiControl();
    void Start () {
        sw.Start();
        UnityEngine.Debug.Log("Stopwatch Start!");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetAndStartStopWatch()
    {
        sw.Stop();
        uiCtrl.addTimeToText(sw.Elapsed);
        sw.Reset();
        sw.Start();
    }

    public void StartStopWatch(){
        sw.Start();
    }
}
