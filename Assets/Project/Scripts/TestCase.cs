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

    public List<FoundObject> objects = new List<FoundObject>();
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

    public class FoundObject{
        Vector3 position;
        TimeSpan time;

        public FoundObject(Vector3 position, TimeSpan time){
            this.position = position;
            this.time = time;
        }

        public override string ToString()
        {
            return "Time: " + this.time + " Position: " + this.position;
        }

        public TimeSpan getTime(){
            return this.time;
        }

        public Vector3 getPosition(){
            return this.position;
        }
    }

    public override string ToString()
    {
        string str = 
        this.name + System.Environment.NewLine + 
        this.description + System.Environment.NewLine + 
        "Blind: " + this.blind + System.Environment.NewLine + 
        "Restricted: " + this.restricted + System.Environment.NewLine + 
        "SimpleVisual: " + this.simpleVisual + System.Environment.NewLine;
        objects.ForEach(x => {
            str += " " + x.getTime().ToString() + " " + x.getPosition().ToString() + System.Environment.NewLine;
        });

        return str;
    }
}
