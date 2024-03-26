using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class CharacterMoveAbility : CharacterAbility
{

    public float MoveSpeed;
    public float RunSpeed = 12;
    public float Stamina;
    public float MaxStamina = 100f;
    public float StaminaConsumeSpeed = 10f; // 초당 스태미나 소모량
    public float StaminaChargeSpeed = 5f;   // 초당 스태미나 충전량


    private float _gravity = -20f;  // 중력 변수
    private float _yVelocity = 0f;

    private CharacterController _characterController;
    private Animator _animator;
    
    // 목표: [W],[A],[S],[D] 및 방향키를 누르면 캐릭터를 그 방향으로 이동시키고 싶다.
    private Character _owner;

    
    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponentInChildren<Animator>();
        _owner = GetComponent<Character>();
    }

    private void Start()
    {
        Stamina = MaxStamina;
    }

    private void Update()
    {

        // 순서
        // 1. 사용자의 키보드 입력을 받는다.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 2. '캐릭터가 바라보는 방향'을 기준으로 방향을 설정한다.
        Vector3 dir = new Vector3(h, 0, v);
        _animator.SetFloat("Move", dir.magnitude);

        dir.Normalize();
        dir = Camera.main.transform.TransformDirection(dir); // 글로벌 좌표계 (세상의 동서남북)



        // 과제 5. 스테미나 구현하기 
        float speed = MoveSpeed;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Stamina -= StaminaConsumeSpeed * Time.deltaTime;

            if (Stamina > 0 )
            {
                speed = RunSpeed;
                Debug.Log(speed);
            }
        }
        else
        {
            Stamina += StaminaChargeSpeed * Time.deltaTime;
        }


        Stamina = Mathf.Clamp(Stamina, 0, 100);
        //StaminaSliderUI.value = Stamina / MaxStamina; 

        // 3. 이동속도에 따라 그 방향으로 이동한다.
        _characterController.Move(dir * speed * Time.deltaTime);

        // 4. 중력 적용하세요.
        // 4. 중력 적용하세요.
        dir.y = -1f;


    }


}
