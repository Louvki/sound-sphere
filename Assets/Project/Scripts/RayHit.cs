using System;
using UnityEngine;
using UnityEngine.UI;

public class RayHit : MonoBehaviour
{
    public delegate void EnemyHit(TimeSpan time);
    public delegate void StartHit();
    public event EnemyHit EnemyHitEvent;
    public event StartHit StartHitEvent;


    float currentValue;
    private float speed = 100;
    public Image loadingBar = GameObject.Find("UISelectionBar").GetComponent<Image>();
    StopWatchHelper sw = new StopWatchHelper();

    public RayHit(Image loadingBar)
    {
        this.loadingBar = loadingBar;
    }

    void Start()
    {
        //sw.StartStopWatch();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {
            if (hit.transform.tag.Equals("Enemy") && hit.transform.GetComponent<AudioSource>().enabled == true)
            {
                if (EnemyHitEvent != null)
                {
                    var ee = new TimeSpan(1);
                    EnemyHitEvent(ee);
                }
            }
            if (hit.transform.name.Equals("Start"))
            {
                if (StartHitEvent != null)
                {
                    StartHitEvent();
                }
            }
        }
        else
        {
            ResetCircleAnim();
        };

    }

    public void HitCircleAnim(GameObject hit)
    {
        if (currentValue <= 100)
        {
            currentValue += speed * Time.deltaTime;
            loadingBar.fillAmount = currentValue / 100;
        }
        else
        {
            ResetCircleAnim();
            if (hit.transform.name.Equals("Enemy"))
            {
                //enemy.SpawnNewHit(hit.transform.gameObject);
            }

            if (hit.transform.name.Equals("Start"))
            {

            }

            //sw.ResetAndStartStopWatch();
        }


    }

    public void ResetCircleAnim()
    {
        if (loadingBar)
        {

        loadingBar.fillAmount = 0f;
        }
        currentValue = 0;
    }

}
