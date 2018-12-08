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
    public GameObject endScreen;
    public GameObject description;
    public GameObject infoTable;

    RayHit rayhit;
    EnemyInitializer enemyInitService = new EnemyInitializer();
    List<TestCase> testCases = new List<TestCase>();
    int currentTestCaseIndex = -1;
    StopWatchHelper swh;

    // Use this for initialization
    void Start()
    {
        this.swh = new StopWatchHelper();

        // Initializing Rayhit and registering the event listeners.
        // FIXME: Needs to fixed, it registers the hit too fast. Should be simple
        rayhit = gameObject.AddComponent(typeof(RayHit)) as RayHit;
        rayhit.StartHitEvent += StartUseCase;
        rayhit.EnemyHitEvent += SourceFound;
        rayhit.RestartHitEvent += RestartUseCase;

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

        testCases[currentTestCaseIndex].SourceFound(swh.ResetAndStartStopWatch(), enemyInitService.getCurrentEnemy().transform.position);
        swh.ResetAndStartStopWatch();
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

    public void RestartUseCase(){
        this.endScreen.SetActive(false);
        LoadTestCaseStartScreen();
    }

    public void StartUseCase()
    {
        swh.StartStopWatch();
        menu.SetActive(false);
        enemyInitService.showEnemies(true);
        enemyInitService.initializeRandomAudioSource();
    }

    private void LoadEndScreen()
    {
        testCases.ForEach(x =>
        {
            infoTable.GetComponent<TextMesh>().text += x.ToString() + "\n";
        });
        enemyInitService.showEnemies(false);
        enemyInitService.muteAllEnemies();
        endScreen.SetActive(true);
    }

    private void InitTestCases()
    {
        TestCase t1 = new TestCase("Regular", "The default use case", false, false, true);
        TestCase t2 = new TestCase("Blind", "This test case is meant to use no visuals", true, false, true);
        testCases.Add(t1);
        testCases.Add(t2);
    }
}



