using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{   public float startTime=120f;
    public Text txtTimer;
    void Start()
    {   
        txtTimer.text=ShootableBox.score.ToString();
        
    }

    void Update()
    {
        startTime-=Time.deltaTime;
        txtTimer.text=Mathf.Round(startTime).ToString();
    }
}
