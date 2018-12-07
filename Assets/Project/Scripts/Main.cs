using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject enemy;
    public Image rayHitImage;

    RayHit rayhit;
    EnemyInitializer enemyInitService = new EnemyInitializer();
    List<TestCase> testCases = new List<TestCase>();
    int currentTestCaseIndex = -1;

    // Use this for initialization
    void Start()
    {
        rayhit = new RayHit(rayHitImage);
        enemyInitService.InitializeEnemyList(enemy);
        InitTestCases();
        LoadNextTestCase();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void SourceFound(TimeSpan time)
    {
        testCases[currentTestCaseIndex].SourceFound(time);
        if (testCases[currentTestCaseIndex].IsFinished())
        {
            if (testCases.Count == currentTestCaseIndex + 1)
            {
                LoadEndScreen();
            }
            else
            {
                LoadNextTestCase();
            }
        }
    }

    private void LoadNextTestCase()
    {
        currentTestCaseIndex++;
        LoadTestCaseStartScreen();
    }

    private void LoadTestCaseStartScreen()
    {
        GameObject start = GameObject.Find("Start");
        GameObject description = GameObject.Find("Description");
        description.GetComponent<Text>().text = testCases[currentTestCaseIndex].description;

        description.SetActive(true);
        start.SetActive(true);
    }

    public void StartUseCase()
    {
        
    }

    private void LoadEndScreen()
    {

    }

    private void InitTestCases()
    {
        TestCase t1 = new TestCase("Regular", "The default use case", false, false, true);
        TestCase t2 = new TestCase("Blind", "This test case is meant to use no visuals", true, false, true);
        testCases.Add(t1);
        testCases.Add(t2);
    }
}



