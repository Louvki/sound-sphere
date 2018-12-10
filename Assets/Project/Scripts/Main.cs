using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    public GameObject enemy;
    public GameObject restrictedScreen;
    public Image rayHitImage;

    public GameObject menu;
    public GameObject succ;
    public GameObject endScreen;
    public GameObject description;
    public GameObject infoTable1;
    public GameObject infoTable2;
    public GameObject infoTable3;
    public GameObject infoTable4;

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

    private void Update()
    {
        if (swh.getElapsed().Seconds > 40)
        {
            SourceFound();
        };
    }

    private void LoadNextTestCase()
    {
        currentTestCaseIndex++;
        LoadTestCaseStartScreen();
    }

    private void LoadTestCaseStartScreen()
    {
        TestCase curTestCase = testCases[currentTestCaseIndex];
        enemyInitService.showEnemies(false);
        enemyInitService.muteAllEnemies();

        menu.SetActive(true);
        description.GetComponent<TextMesh>().text = curTestCase.description;
    }

    public void SourceFound()
    {
        var timeElapsed = swh.ResetAndStartStopWatch();
        testCases[currentTestCaseIndex].SourceFound(timeElapsed, enemyInitService.getCurrentEnemy().transform.position);
       

        enemyInitService.initializeRandomAudioSource();
        if (testCases[currentTestCaseIndex].IsFinished())
        {
            if (testCases.Count == currentTestCaseIndex + 1)
            {
                StartCoroutine(ShowMessage("Thank you for participating", 2));
                LoadEndScreen();
            }
            else
            {
                StartCoroutine(ShowMessage("Good job! Start the next Test!", 2));
                setRestrictedMode(false);
                LoadNextTestCase();
            }
        }
    }

    public void RestartUseCase()
    {
        endScreen.SetActive(false);
        currentTestCaseIndex = -1;
        LoadNextTestCase();
    }

    public void StartUseCase()
    {
        TestCase currTestCase = testCases[currentTestCaseIndex];

        if (currTestCase.getSimpleVisual())
        {
            enemyInitService.setEnemyDisplay(EnemyDisplay.Simple);
        }
        else
        {
            enemyInitService.setEnemyDisplay(EnemyDisplay.Complex);
        }

        setRestrictedMode(currTestCase.getRestricted());

        if (currTestCase.getBlind())
        {
            enemyInitService.setEnemyDisplay(EnemyDisplay.Invisible);
        }

        swh.StartStopWatch();
        menu.SetActive(false);
        enemyInitService.showEnemies(true);
        enemyInitService.initializeRandomAudioSource();
    }

    private void LoadEndScreen()
    {
        infoTable1.GetComponent<TextMesh>().text = "";
        infoTable1.GetComponent<TextMesh>().text = "";
        infoTable1.GetComponent<TextMesh>().text = "";
        infoTable1.GetComponent<TextMesh>().text = "";
        for (var i = 0; i < testCases.Count; i++)
        {
            if (i == 0)
            {
                infoTable1.GetComponent<TextMesh>().text = testCases[i].ToString();
            }
            if (i == 1)
            {
                infoTable2.GetComponent<TextMesh>().text = testCases[i].ToString();
            }
            if (i == 2)
            {
                infoTable3.GetComponent<TextMesh>().text = testCases[i].ToString();
            }
            if (i == 3)
            {
                infoTable4.GetComponent<TextMesh>().text = testCases[i].ToString();
            }
        }
        testCases.ForEach(x =>
        {

        });
        enemyInitService.showEnemies(false);
        enemyInitService.muteAllEnemies();
        endScreen.SetActive(true);
    }

    private void setRestrictedMode(bool enable)
    {
        restrictedScreen.SetActive(enable);
    }

    IEnumerator ShowMessage(string message, float delay)
    {
        succ.GetComponent<TextMesh>().text = message;
        succ.SetActive(true);
        yield return new WaitForSeconds(delay);
        succ.SetActive(false);
    }

    private void InitTestCases()
    {
        TestCase t1 = new TestCase("Test #1", "Try to locate the source of the sound." + Environment.NewLine + " When the crosshair is over the source of the sound it will start to fill up.", false, false, true);
        TestCase t2 = new TestCase("Test #2", "This time there will be no visuals." + Environment.NewLine + " Focus on the sound to find it's source", true, false, true);
        TestCase t3 = new TestCase("Test #3", "Ups, I think I spilled something on the lens.", false, true, true);
        TestCase t4 = new TestCase("Test #4", "This might count as creepy", false, false, false);
        testCases.Add(t1);
        testCases.Add(t2);
        testCases.Add(t3);
        testCases.Add(t4);
    }
}



