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

    List<FoundObject> objects = new List<FoundObject>();
    int timesFound = 0;
    int findLimit = 2;

    public TestCase(string name, string description, bool blind, bool restricted, bool simpleVisual)
    {
        this.name = name;
        this.description = description;
        this.blind = blind;
        this.restricted = restricted;
        this.simpleVisual = simpleVisual;
    }

    public void SourceFound(TimeSpan time, Vector3 position)
    {
        timesFound++;
        objects.Add(new FoundObject(position, time));
        objects.ForEach(x => Debug.Log(x.ToString()));
    }

    public bool IsFinished()
    {
        return timesFound == findLimit;
    }

    class FoundObject{
        Vector3 position;
        TimeSpan time;

        public FoundObject(Vector3 position, TimeSpan time){
            this.position = position;
            this.time = time;
        }

        public override string ToString()
        {
            return "Time: " + this.time + "/n" + "Position: " + this.position;
        }
    }
}
