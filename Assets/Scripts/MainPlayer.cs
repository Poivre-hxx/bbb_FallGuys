using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainPlayer : MonoBehaviour
{
    public float speed = 10;
    public float rotateSpeed = 10;
    public float jumpPower = 5;

    private Camera currentCamera;
    public bool UseCameraRotation = true;

    public ParticleSystem dust;

    public GameObject bar;

    public string playerTag;
    public float bounceForce;
    public ParticleSystem bounce;

    public AudioSource mysfx;
    public AudioClip jumpfx;
    public AudioClip bouncefx;

    Animator anim;
    Rigidbody rigid;

    // 动作全局变量
    bool isJump;
    bool jDown;
    bool isDie;
    float hAxis;
    float vAxis;

    Vector3 moveVec;


    void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();

        bar.SetActive(true);
        bar.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 2.2f, 0));
    }

    // Start is called before the first frame update
    void Start()
    {
        currentCamera = FindObjectOfType<Camera>();
    }

    private void FixedUpdate()
    {
        FreezeRotation();
        GetInput();
        Move();
        Turn();
        Jump();
        Die();
        Expression();
    }

    void FreezeRotation()
    {
        rigid.angularVelocity = Vector3.zero;
    }
    void GetInput()
    {
        hAxis = Input.GetAxis("Horizontal");
        vAxis = Input.GetAxis("Vertical");
        jDown = Input.GetButton("Jump");
    }
    void Move()
    {
        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        if (UseCameraRotation)
        {
            Quaternion v3Rotation = Quaternion.Euler(0f, currentCamera.transform.eulerAngles.y, 0f);
            moveVec = v3Rotation * moveVec;
        }
        transform.position += moveVec * speed * Time.deltaTime;
        anim.SetBool("isMove", moveVec != Vector3.zero);
    }
    void Turn()
    {
        if (hAxis == 0 && vAxis == 0)
            return;

        Quaternion newRotation = Quaternion.LookRotation(moveVec);
        rigid.rotation = Quaternion.Slerp(rigid.rotation, newRotation, rotateSpeed * Time.deltaTime);
    }
    void Jump()
    {
        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isJump = true;

            //anim.SetBool("isJump", true);
            anim.SetTrigger("doJump");
            mysfx.PlayOneShot(jumpfx);
            dust.Play();
        }
    }
    void Die()
    {
        if (isDie)
        {
            anim.SetTrigger("doDie");
            isDie = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            // anim.SetBool("isGround", false);
            //isGround = false;
            anim.SetBool("isJump", false);

            isJump = false;
        }
        else if (collision.gameObject.tag == "Platform")
        {
            anim.SetBool("isJump", false);

            isJump = false;
        }
        else if (collision.collider.tag == "Wall")
        {
            Debug.Log("Wall");
            anim.SetTrigger("doDie");
            isDie = false;

            rigid.velocity = new Vector3(0, 0, 0);
            rigid.AddForce(Vector3.back * bounceForce, ForceMode.Impulse);

            mysfx.PlayOneShot(bouncefx);
            bounce.Play();

            bounce.transform.position = transform.position;
        }
    }

    void Expression()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("doDance01");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("doDance02");
        }

        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetTrigger("doVictory");
        }
    }


}
