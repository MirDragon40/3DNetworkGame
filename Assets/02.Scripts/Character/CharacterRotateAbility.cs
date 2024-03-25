using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotateAbility : MonoBehaviour
{
    // 목표: 마우스 이동에 따라 카메라와 플레이어를 회전하고 싶다. 

    public float RotationSpeed = 200;
    private float _mx = 0;
    private float _my = 0;

    private void Start()
    {
    }

    private void Update()
    {
        // 순서
        // 1. 마우스 입력 값을 받는다. 
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        // 2. 회전 값을 마우스 입력에 따라 미리 누적한다.
        _mx += mouseX * RotationSpeed * Time.deltaTime;
        _my += mouseY * RotationSpeed * Time.deltaTime;

        // 3. 카메라(3인칭)와 캐릭터를 회전 방향으로 회전시킨다. 
        transform.eulerAngles = new Vector3(0f, _mx, 0);
        transform.eulerAngles = new Vector3(0f, _my, 0);
        // 4. 시네머신
    }
}
