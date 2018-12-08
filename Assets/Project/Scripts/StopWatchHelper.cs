

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class StopWatchHelper : MonoBehaviour {

    public Stopwatch sw = new Stopwatch();
	
	// Update is called once per frame
	void Update () {
		
	}

    public TimeSpan ResetAndStartStopWatch()
    {
        var elapsed = sw.Elapsed;
        sw.Stop();
        sw.Reset();
        sw.Start();
        return elapsed;;
    }

    public void StartStopWatch(){
        sw.Start();
    }
}
