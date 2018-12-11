using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCase
{
    string name;
    public string description { get; set; }
    bool blind;
    bool restricted;
    bool simpleVisual;

    public List<FoundObject> objects = new List<FoundObject>();
    public int timesFound = 0;
    int findLimit = 12;

    public TestCase(string name, string description, bool blind, bool restricted, bool simpleVisual)
    {
        this.name = name;
        this.description = description;
        this.blind = blind;
        this.restricted = restricted;
        this.simpleVisual = simpleVisual;
    }

    public void Reset()
    {
        timesFound = 0;
        objects = new List<FoundObject>();
    }

    public void SourceFound(FoundObject foundObject)
    {
        timesFound++;
        objects.Add(foundObject);
    }

    public bool IsFinished()
    {
        return timesFound >= findLimit;
    }

    public bool getBlind()
    {
        return this.blind;
    }

    public bool getRestricted()
    {
        return this.restricted;
    }

    public bool getSimpleVisual()
    {
        return this.simpleVisual;
    }

    public override string ToString()
    {
        string settings = "";
        if (this.blind) { settings += "Blind"; }
        if (this.restricted) { settings += ", Restricted"; }
        if (!this.simpleVisual) { settings += ", Complex Visuals"; }
        if (settings.Length > 0) { settings += System.Environment.NewLine; }

        string str =
        this.name + System.Environment.NewLine +
        this.description + System.Environment.NewLine +
        settings;
        objects.ForEach(x =>
        {
            str += " " + string.Format("{0:00}:{1:00}", x.getTime().Seconds, x.getTime().Milliseconds) +" " + x.getPosition().ToString() + System.Environment.NewLine;
        });

        return str;
    }

    public class FoundObject
    {
        Vector3 position;
        TimeSpan time;

        public FoundObject(Vector3 position, TimeSpan time)
        {
            this.position = position;
            this.time = time;
        }

        public override string ToString()
        {
            return "Time: " + this.time.TotalSeconds + "seconds. Position: " + this.position;
        }

        public TimeSpan getTime()
        {
            return this.time;
        }

        public Vector3 getPosition()
        {
            return this.position;
        }
    }
}
