

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class StopWatchHelper : MonoBehaviour {

    public Stopwatch sw = new Stopwatch();
    public List<TimeSpan> reactionTimes = new List<TimeSpan>();
	void Start () {
        sw.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetAndStartStopWatch()
    {
        sw.Stop();
		UnityEngine.Debug.Log(sw.Elapsed);
        sw.Reset();
        sw.Start();
    }

    public void StartStopWatch(){
        sw.Start();
    }
}
