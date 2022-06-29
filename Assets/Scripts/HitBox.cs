using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class HitBox : MonoBehaviour, IDamageable
{
    public float health = 100;
    public float max_health = 100;

    public Text HP;
    public Slider HPslider;
    public GameObject FillColorArea;

    public Transform enemy_target;
    Rigidbody rigid;
    NavMeshAgent nav;
    public Animator anim;
    public bool isChase; //nav추적여부
    float range = 10; //nav이동을 위한 범위 설정
    Vector3 point; //nav이동을 위한 랜덤 좌표를 담을 변수
    private float moveRate = 3f; //nav이동 변경 시간 간격
    private float nextMove = 0.0f; //직전 방향 변경 시간 기록

    void Start()
    {
        HP.text = health.ToString()+" / "+max_health.ToString();
        nav = GetComponent<NavMeshAgent>();
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

        Invoke("ChaseStart", 3);
    }

    void ChaseStart()
    {
        isChase = true;
        if(anim != null)
        {
            anim.SetBool("isWalk", true);
        }
    }

    void Update()
    {
        if(isChase)
        {
            NavMove();
        }
    }

    void FixedUpdate()
    {
        FreezeVelocity();
    }

    //플레이어에게 부딪혔을 때 반동으로 튕겨나가서 제대로된 이동을 하지 못하는 것을 방지
    void FreezeVelocity()
    {
        if(isChase)
        {
            rigid.velocity = Vector3.zero;
            rigid.angularVelocity = Vector3.zero;
        }
    }

    //NavMesh 이동을 위한 조건체크
    //구형범위 랜덤 좌표 생성, 해당 위치에 navmesh가 존재하는가
    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
    }

    public void NavMove()
    {
        if(RandomPoint(enemy_target.position, range, out point) && Time.time > nextMove)
        {
            nextMove = Time.time + moveRate;
            enemy_target.position = point;
        }
        nav.SetDestination(enemy_target.position);
    }

    public void OnDamage(float damageAmount)
    {
        health -= damageAmount;

        HP.text = health.ToString()+" / "+max_health.ToString();
        HPslider.value = health/max_health;

        if(health <= 0)
        {
            gameObject.SetActive(false);
            isChase = false;
            nav.enabled = false;
        }
        else if(health <= (max_health/4))
        {
            FillColorArea.GetComponent<Image>().color =  Color.red;
        }
        else if(health <= (max_health/2))
        {
            FillColorArea.GetComponent<Image>().color =  Color.yellow;      
        }
        
    }
}
