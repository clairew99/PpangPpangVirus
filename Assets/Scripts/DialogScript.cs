using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogScript : MonoBehaviour
{

    public float m_TimeBetFire = 0.3f;
    private float m_LastFireTime;

    public GameObject talkPanel;
    public Text text;
    public int clickCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_LastFireTime = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        

        if (Input.GetButton("Fire1") && Time.time >= m_LastFireTime + m_TimeBetFire) {
            m_LastFireTime = Time.time; //마지막으로 총을 쏜 시점 갱신
            
            clickcnt(clickCount);

            Debug.Log(clickCount);
        }

        
        
    }

    private void clickcnt(int clickcount)
    {
        if (clickCount == 0)
            {
                text.text = "\t[Report]\n\t-------------------------------------------------\n\t날짜 : 30XX년 X월 XX일";
                clickCount++;
            }

            else if (clickCount == 1) {
                text.text = "\t상황 보고 :\n\t 예상대로 지구 우주선이 우리 행성에 착륙을 시도하는 것으로 보인다.\n\t정보원들에 따르면 지구인들은 자신들의 파괴된 행성 대신\n\t 우리 행성에서 새로운 시작을 꿈꾸고 있다.";
                clickCount++;
            }

            else if (clickCount == 2)
            {
                text.text = "\t지구인들의 착륙을 막기 위해 대기권에 제작한 바이러스를 살포했지만, \n\t지구인에게도 대항할 무기가 있는 것으로 확인되었다.";
                clickCount++;
            }
            else if (clickCount == 3)
            {
                text.text = "\t현재 지표면까지 바이러스를 살포해 놓았으며\n\t우리 연구원들은 바이러스 연구소에서 끝까지 상황을 모니터링 하며\n\t지구인들을 막기 위해 사력을 다할 것이다.";
                clickCount++;
            }
            else if (clickCount == 4)
            {
                text.text = "\t\"이게 다 이 행성 외계인들의 짓이었다니...\n\t 절대로 용서하지 않겠어.\"";
                clickCount++;
            }
            else if (clickCount == 5)
            {
                text.text = "\t\t\"다음 목적지는 연구소다!\"";
                clickCount++;
            }
    }
}
