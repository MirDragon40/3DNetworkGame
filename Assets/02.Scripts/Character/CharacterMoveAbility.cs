using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMoveAbility : MonoBehaviour
{
    public float MoveSpeed = 7;

    private float _gravity = -20f;  // 중력 변수
    private float _yVelocity = 0f;

    private CharacterController _characterController;


    // 목표: [W],[A],[S],[D] 및 방향키를 누르면 캐릭터를 그 방향으로 이동시키고 싶다.

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }


    private void Update()
    {
        // 순서
        // 1. 사용자의 키보드 입력을 받는다.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        // 2. '캐릭터가 바라보는 방향'을 기준으로 방향을 설정한다.
        Vector3 dir = new Vector3(h, 0, v);
        dir.Normalize();
        dir = Camera.main.transform.TransformDirection(dir); // 글로벌 좌표계 (세상의 동서남북)


        // 3. 이동속도에 따라 그 방향으로 이동한다.
        _characterController.Move(dir * MoveSpeed * Time.deltaTime);


        // 4. 중력 적용하세요.
        dir.y = -1f;
    }


}
