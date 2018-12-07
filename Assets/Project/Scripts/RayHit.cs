
using UnityEngine;
using UnityEngine.UI;

public class RayHit : MonoBehaviour
{
    float currentValue;
    private float speed = 100;
    public Image loadingBar;
    StopWatchHelper sw = new StopWatchHelper();

    public RayHit(Image loadingBar)
    {
        this.loadingBar = loadingBar;
    }

    void Start()
    {
        sw.StartStopWatch();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit))
        {

            Debug.Log(hit.transform.name);
            if (hit.transform.name.Equals("Enemy") || hit.transform.name.Equals("Start"))
            {
                HitCircleAnim(hit.transform.gameObject);
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

            sw.ResetAndStartStopWatch();
        }


    }

    public void ResetCircleAnim()
    {
        loadingBar.fillAmount = 0f;
        currentValue = 0;
    }

}
