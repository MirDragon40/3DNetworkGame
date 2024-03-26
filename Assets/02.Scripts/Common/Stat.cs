using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]   // 직렬화가 가능한. 컴퓨터가 이해할 수 있는 언어로 바꾸는 것
public class Stat   // public record Stat
{
    public int Health;  // 처음 한번만 대입할때
    public int MaxHealth;

    public float Stamina;
    public float MaxStamina = 100f;
    public float RunConsumeStamina = 10f; // 초당 스태미나 소모량
    public float RunRecoveryStamina = 5f;   // 초당 스태미나 충전량

    public float MoveSpeed = 7;
    public float RunSpeed = 12;

    public float RotationSpeed;

    public float AttackCoolTime = 1f;
    public float AttackConsumeStamina = 20f;
    public void Init()
    {
        Health  = MaxHealth;
        Stamina = MaxStamina;
    }
}
