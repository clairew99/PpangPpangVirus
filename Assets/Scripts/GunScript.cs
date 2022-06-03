using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunScript : MonoBehaviour
{
    public Animator m_Animator; //총의 애니메이터
    public Transform m_FireTransform; //총구 위치
    public GameObject m_MuzzleFlashEffect; //총구 화염

    public AudioSource m_GunAdudioPlayer; //총 소리 재생기
    public AudioClip m_ShotClip; //발사 소리
    public AudioClip m_ReloadClip; //재장전 소리

    public LineRenderer m_BulletLineRenderer; //총알 궤적 랜더러

    public GameObject m_ImpactPrefab; //총알 맞은 장소에 효과

    public Text m_AmmoText1; //남은 탄환 수1
    public Text m_AmmoText2; //남은 탄환 수2

    public int m_MaxAmmo = 13; //탄창 최대 탄약 수
    public float m_TimeBetFire = 0.3f; //발사와 발사 사이의 시간 간격
    public float m_Damage = 25;
    public float m_ReloadTime = 2.0f; //재장전 시간
    public float m_FireDistance = 100f; //사정거리

    private enum State { Ready, Empty, Reloading }
    private State m_CurrentState = State.Empty; //초기 상태

    private float m_LastFireTime; //총을 마지막으로 발사한 시점
    private int m_CurrentAmmo = 0; //탄창에 남은 현재 탄약
    
    // Start is called before the first frame update
    void Start()
    {
        m_CurrentState = State.Ready;
        m_CurrentAmmo = m_MaxAmmo;
        m_LastFireTime = 0;

        m_BulletLineRenderer.positionCount = 2; //라인렌더러의 점 두개로 설정(직선)
        m_BulletLineRenderer.enabled = false; //처음에는 총알 궤적 없음

        m_GunAdudioPlayer.enabled = true;

        UpdateUI(); //UI갱신
    }

    //발사 처리 시도
    public void Fire()
    {
        //레디 상태 AND 마지막 발사시점 + 연사 간격 고려
        if(m_CurrentState == State.Ready && Time.time >= m_LastFireTime + m_TimeBetFire)
        {
            m_LastFireTime = Time.time; //마지막으로 총을 쏜 시점 갱신

            Shot();
            UpdateUI();
        }
    }

    //발사 처리
    private void Shot()
    {
        RaycastHit hit; //레이캐스트 정보 저장하는 충돌정보 컨테이너

        //총을 쏴서 총알이 맞은 곳: 처음값으로는 총구 위치+사정거리(앞방향)
        Vector3 hitPosition = m_FireTransform.position + m_FireTransform.forward * m_FireDistance;
        //레이캐스트(시작지점, 방향, 충돌정보 컨테이너, 사정거리)
        if(Physics.Raycast(m_FireTransform.position, m_FireTransform.forward, out hit, m_FireDistance))
        {
            //맞은게 IDamageable이면
            IDamageable target = hit.collider.GetComponent<IDamageable>();

            if(target != null)
            {
                //OnDamage함수를 실행시켜 대미지 계산
                target.OnDamage(m_Damage);
            }

            //충돌 위치
            hitPosition = hit.point;
            //피탄 효과 생성(충돌지점에, 충돌한 표면의 방향으로)
            GameObject decal = Instantiate(m_ImpactPrefab, hitPosition, Quaternion.LookRotation(hit.normal));
            decal.transform.SetParent(hit.collider.transform); //맞은 물체의 자식오브젝트로 위치
        }
        //발사 이펙트 재생 시작
        StartCoroutine(ShotEffect(hitPosition));
        //남은 탄환 수 -1
        m_CurrentAmmo--;

        if(m_CurrentAmmo <= 0)
        {
            m_CurrentState = State.Empty;
        }
    }

    //발사 이펙트 재상하고 총알 궤적을 그렸다가 끄기
    private IEnumerator ShotEffect(Vector3 hitPosition)
    {
        m_Animator.SetTrigger("Fire");

        //총알 궤적 랜더러 키기
        m_BulletLineRenderer.enabled = true;
        //선분의 첫 점은 총구위치, 두번째 점은 피탄 위치
        m_BulletLineRenderer.SetPosition(0, m_FireTransform.position);
        m_BulletLineRenderer.SetPosition(1, hitPosition);

        //이펙트 재생
        GameObject muzzle = Instantiate(m_MuzzleFlashEffect, m_FireTransform.position, m_FireTransform.rotation);
        muzzle.transform.SetParent(m_FireTransform); //맞은 물체의 자식오브젝트로 위치
        muzzle.SetActive(true);
        

         //소리 다른 게 들어가있으면 총격소리로
        if(m_GunAdudioPlayer.clip != m_ShotClip)
        {
            m_GunAdudioPlayer.clip = m_ShotClip;
        }
       
        //총격 소리 재생
        m_GunAdudioPlayer.Play();

        yield return new WaitForSeconds(0.07f); //잠시 처리를 쉬는 시간

        m_BulletLineRenderer.enabled = false; //쉬고 총알궤적 꺼줌
        muzzle.SetActive(false);
    }

    //탄약 UI에 남은 탄약수 띄우기
    private void UpdateUI()
    {
        if(m_CurrentState == State.Empty)
        {
            m_AmmoText1.text = "□□□";
            m_AmmoText2.text = "□□□";
        }
        else if(m_CurrentState == State.Reloading)
        {
            m_AmmoText1.text = "■■■";
            m_AmmoText2.text = "■■■";
        }
        else
        {
            m_AmmoText1.text = m_CurrentAmmo.ToString();
            m_AmmoText2.text = m_CurrentAmmo.ToString();
        }
    }

    //재장전 처리 시도
    public void Reload()
    {
        if(m_CurrentState != State.Reloading)
        {
            StartCoroutine(ReloadRoutin());
        }
    }

    //재장전 처리
    private IEnumerator ReloadRoutin()
    {
        m_CurrentState = State.Reloading;

        m_GunAdudioPlayer.clip = m_ReloadClip;
        m_GunAdudioPlayer.Play();

        UpdateUI();

        yield return new WaitForSeconds(m_ReloadTime);

        m_CurrentAmmo = m_MaxAmmo;
        m_CurrentState = State.Ready;
        UpdateUI();
    }
}
