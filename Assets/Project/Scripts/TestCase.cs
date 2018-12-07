using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCase {
    string name;
    public string description { get; set; }
    bool blind;
    bool restricted;
    bool simpleVisual;

    List<TimeSpan> times = new List<TimeSpan>();
    int timesFound = 0;
    int findLimit = 10;

    public TestCase(string name, string description, bool blind, bool restricted, bool simpleVisual)
    {
        this.name = name;
        this.description = description;
        this.blind = blind;
        this.restricted = restricted;
        this.simpleVisual = simpleVisual;
    }

    public void SourceFound(TimeSpan time)
    {
        timesFound++;
        times.Add(time);
    }

    public bool IsFinished()
    {
        return timesFound == findLimit;
    }

}
