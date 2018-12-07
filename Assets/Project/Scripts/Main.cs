using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject enemy;
    public Image rayHitImage;

    public GameObject menu;
    public GameObject description;

    RayHit rayhit;
    EnemyInitializer enemyInitService = new EnemyInitializer();
    List<TestCase> testCases = new List<TestCase>();
    int currentTestCaseIndex = -1;

    // Use this for initialization
    void Start()
    {
        // Initializing Rayhit and registering the event listeners.
        // FIXME: Needs to fixed, it registers the hit too fast. Should be simple
        rayhit = gameObject.AddComponent(typeof(RayHit)) as RayHit;
        rayhit.StartHitEvent += StartUseCase;
        rayhit.EnemyHitEvent += SourceFound;

        // Initialize enemies, testcases and start the program by loading the next case
        enemyInitService.InitializeEnemyList(enemy);
        InitTestCases();
        LoadNextTestCase();
    }

    private void LoadNextTestCase()
    {
        currentTestCaseIndex++;
        LoadTestCaseStartScreen();
    }

    private void LoadTestCaseStartScreen()
    {
        enemyInitService.showEnemies(false);
        enemyInitService.muteAllEnemies();

        menu.SetActive(true);
        description.GetComponent<TextMesh>().text = testCases[currentTestCaseIndex].description;
    }

    public void SourceFound(TimeSpan time)
    {
        testCases[currentTestCaseIndex].SourceFound(time);
        this.enemyInitService.initializeRandomAudioSource();
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

    public void StartUseCase()
    {
        menu.SetActive(false);
        enemyInitService.showEnemies(true);
        enemyInitService.initializeRandomAudioSource();
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



