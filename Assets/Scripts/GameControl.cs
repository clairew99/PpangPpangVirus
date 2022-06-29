using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameControl : MonoBehaviour
{   
    public Text Results;
    public GameObject Timer;
    Timer timer;

    //public float LimitTime;

    // Start is called before the first frame update
    void Start()
    {   
        timer=GameObject.Find("Timer").GetComponent<Timer>();
       // LimitTime= Timer.GetComponent<Timer>().LimitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer.LimitTime<=0){
            Results.text="Stage 1 Clear";
            SceneManager.LoadScene("main");
            
        }
        else{

            Results.text="";
        }
        
    }

    

}
