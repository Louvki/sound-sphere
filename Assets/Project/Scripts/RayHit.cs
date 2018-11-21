using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RayHit : MonoBehaviour {


    float currentValue;
    private float speed = 160;
    public Image loadingBar;
    Enemy enemy = new Enemy();


    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;
        if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit)){
            
			if(hit.transform.name.Equals("Enemy")){
				HitCircleAnim(hit.transform.gameObject);
			}
		}else{
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
            enemy.SpawnNewHit(hit.transform.gameObject);
        }


    }

    public void ResetCircleAnim()
    {
        loadingBar.fillAmount = 0f;
        currentValue = 0;
    }

}
