

using System;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class StopWatch : MonoBehaviour {

    public Stopwatch sw = new Stopwatch();
    public List<TimeSpan> reactionTimes = new List<TimeSpan>();
	void Start () {
        sw.Start();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ResetStopWatch()
    {
        sw.Stop();
        reactionTimes.Add(sw.Elapsed);
		UnityEngine.Debug.Log(sw.Elapsed);
        sw.Reset();
        sw.Start();
    }
}
