using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour
{
    //public int playerSpeed = 1;
    //public int speedForward = 12; //전진 속도
    //public int speedSide = 6;  //옆걸음 속도

    public GameObject Gun;
    //public GameObject bullet;  //발사할 총알
    //public Transform firePos;  //발사되는 위치

    private Transform tr;  //플레이어 트랜스폼
    private Rigidbody rb; //플레이어 리지드바디
    public float force = 200.0f;
    public bool isJumping;
    //private float dirX = 0;
    //private float dirZ = 0;

    float MovSpeed = 5f;
    //CharacterController cc;
    
    
    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
        isJumping = false;
        //cc = GetComponent<CharacterController>();
        force = 200.0f;
    }

    // Update is called once per frame
    void Update()
    {
        BulletFire();
        Reload();
        MovePlayer();
        JumpPlayer();
    }

    //총알 발사
    void BulletFire()
    {
        //트리거 당겼을 때(총알 발사)
        //if (OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        if (Input.GetButton("Fire1"))
        {
            Gun.GetComponent<GunScript>().Fire();
            //Debug.Log("Fired");
            //Instantiate(bullet, firePos.position, firePos.rotation);
        }
    }

    //재장전
    void Reload()
    {
        if (Input.GetButton("Fire2"))
        {
            Gun.GetComponent<GunScript>().Reload();
            //Debug.Log("Reloaded");
            //Instantiate(bullet, firePos.position, firePos.rotation);
        }
    }

    //플레이어 이동
    void MovePlayer()
    {
        //dirX = 0; //좌우 이동방향(왼쪽:-1, 오른쪽:1)
        //dirZ = 0; //앞뒤 이동방향(후진:-1, 전진:1)

        //transform.position = transform.position + Camera.main.transform.forward * playerSpeed * Time.deltaTime;
        

        
        if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick))
        {
            Vector2 coord = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);

            var absX = Mathf.Abs(coord.x);
        }

        /*
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(-zMove, 0, xMove) * MovSpeed;
        rb.velocity = mov;*/

        //Vector2 mov2d = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick);
        //Vector3 mov = new Vector3(mov2d.x * Time.deltaTime * MovSpeed, 0f, mov2d.y * Time.deltaTime * MovSpeed);
        //cc.Move(mov);
    }

    void JumpPlayer()
    {
        if (Input.GetKeyDown("z"))
        {
            if(!isJumping)
            {
                isJumping = true;
                //rb.AddForce(new Vector3(0, 2.5f, 0) * force, ForceMode.Impulse);
                rb.AddForce(new Vector3(0, 2.5f, 0) * force);
                //rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
            else
            {
                return;
            }
            
        }
    }

    //바닥과 닿았는지 체크해서 중복 점프 방지
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("LevelPart"))
        {
            isJumping = false;
        }
    }
}
