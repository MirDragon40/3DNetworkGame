using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class CharacterMoveAbility : CharacterAbility
{


    private float _gravity = -20f;  // 중력 변수
    private float _yVelocity = 0f;

    private CharacterController _characterController;
    private Animator _animator;

    [Header("스태미나 슬라이더 UI")]
    public Slider StaminaSliderUI;

    // 목표: [W],[A],[S],[D] 및 방향키를 누르면 캐릭터를 그 방향으로 이동시키고 싶다.
  


    private void Start()
    {
        _owner.Stat.Stamina = _owner.Stat.MaxStamina;
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!_owner.PhotonView.IsMine)
        {
            return;
        }

        // 순서
        // 1. 사용자의 키보드 입력을 받는다.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 2. '캐릭터가 바라보는 방향'을 기준으로 방향을 설정한다.
        Vector3 dir = new Vector3(h, 0, v);
        _animator.SetFloat("Move", dir.magnitude);

        dir.Normalize();
        dir = Camera.main.transform.TransformDirection(dir); // 글로벌 좌표계 (세상의 동서남북)

        // 3. 중력 적용하세요.
        dir.y = -1f;


        // 과제 5. 스테미나 구현하기 
        float moveSpeed = _owner.Stat.MoveSpeed;
        if (Input.GetKey(KeyCode.LeftShift) && _owner.Stat.Stamina > 0)
        {
            moveSpeed = _owner.Stat.RunSpeed;
            _owner.Stat.Stamina -= Time.deltaTime * _owner.Stat.RunConsumeStamina;
        }
        else
        {
            _owner.Stat.Stamina += Time.deltaTime * _owner.Stat.RunRecoveryStamina;

            if (_owner.Stat.Stamina >= _owner.Stat.MaxStamina)
            {
                _owner.Stat.Stamina = _owner.Stat.MaxStamina;
            }
        }


        _owner.Stat.Stamina = Mathf.Clamp(_owner.Stat.Stamina, 0, 100);
        StaminaSliderUI.value = _owner.Stat.Stamina / _owner.Stat.MaxStamina;

        // 4. 이동속도에 따라 그 방향으로 이동한다.
        _characterController.Move(dir * (moveSpeed * Time.deltaTime));



    }


}
