using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{   
    public float LimitTime;
    public Text test_Timer;

    // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // Update is called once per frame
    void Update()
    {
        LimitTime -=Time.deltaTime;
        test_Timer.text= "시간 : " + Mathf.Round(LimitTime);


      
    }
}
