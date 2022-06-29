using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class S3EndingScript : MonoBehaviour
{
    public Text panel1_txt;
    public Text title;
    public Text content;

    private float m_LastFireTime; //마지막으로 클릭한 시간
    public float m_TimeBetFire = 0.3f; //클릭 사이의 시간 간격

    public int cnt = 0; //클릭 횟수
    public float m_Speed = 0.1f;
    public Text m_TypingText; 
    public string m_Message;
    
    // Start is called before the first frame update
    void Start()
    {
        //title.enabled = false;
        //content.enabled = false;
        //panel1_txt.enabled = true;
        m_LastFireTime = 0;
        //cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Dialog();
    }

    void Dialog()
    {
        if (Input.GetButton("Fire1") && Time.time >= m_LastFireTime + m_TimeBetFire)
        //if (Input.GetKeyDown("z") && Time.time >= m_LastFireTime + m_TimeBetFire)
        {
            m_LastFireTime = Time.time;
            cnt++;

            NextDialog(cnt);
        }
    }

    void NextDialog(int cnt)
    {
        if(cnt>=5)
        {
            SceneManager.LoadScene("main");
        }
        else
        {
            if(cnt==1)
            {
                title.text = "L̷̳̬̲͙̭̎̊̽̈͗̐̏̓̓̀̚͘o̷̡̡̘̘̩͍͖͇͍̙̟̾̍̒͘a̵̡͔͎̤̩̻̕d̷̨̛͕̮̰͔͕͓̘̤͖̣̩̱̞̉͆͗͋̍̔̐̓̋̀͋̄͠͠ͅí̶̩͍̭̼̌̒̈́̍̄̂̈́͑͠n̶̨̩͐̒̃̿̀͘͝g̶̨̅̓̋̉ ̷̡̧̨͓̝̫̲͈̰̙̻̭̹̙͈̽̐r̷͓̹͍̣͎̖̺̖̘̽ȩ̵̖̦͎͌͒͛̈́̓̑̓̀͑̏͑̈́͝͠c̴̛̈̉̐̏͆͗͗̒̓̿̕̚͝ͅò̴͔̰̟͗̋̈́̿̽̾̕r̷͓̹̱̦̦͛̈̈͑͐̏͗̒͌́̎̐̄͜͝d̶̮̹͍̩̲̣͚̣̼͓̋͛̀̃ṣ̷̗̮̙̎̓͒͒͋̈́̓̇̀̂̓̚͘͠͝.̶̛͓̠͉̭̬̂.̵̘̪́̍͗͋͐̄̃̈́̈́͝.̴̨͓̗͖̤͔̝̘͕̜̫͚̹̓̂̍̾̎̀̌̍͘̚͝";
                
                content.text = "기록을 불러오는 중...\n번역을 시작합니다.";
                
            }
            else if(cnt==2)
            {
                title.enabled = false;
                content.enabled = false;
                m_Message = "23XX.X.XX\n새로운 바이러스 발견.\n최초 발견지는 지구.\n무분별한 환경 파괴로 인한 기후 변화 속에서\n탄생한 것으로 추정.";
                //panel1_txt.text = "3033.XX.XX\n지구를 둘러싸던 오존층이 다 파괴돼서\n오염물질이 빠져나온다.";
            }
            else if(cnt==3)
            {
                m_Message = "23XX.X.XX\n연구 결과,\n지구에서 발견된 바이러스를 개량 시\n생화학무기로 사용할 수 있는 것으로 결론.";
            }
            else if(cnt==4)
            {
                m_Message = "23XX.X.XX\n지구 바이러스 개량 프로젝트 허가.\n바이러스 연구센터 설립.";
            }
            StartCoroutine(Typing(m_TypingText, m_Message, m_Speed));
        }
    }

    IEnumerator Typing(Text typingText, string message, float speed) 
    { 
        for (int i = 0; i < message.Length; i++) 
        { 
            typingText.text = message.Substring(0, i + 1); 
            yield return new WaitForSeconds(speed); 
        } 
    } 
}
