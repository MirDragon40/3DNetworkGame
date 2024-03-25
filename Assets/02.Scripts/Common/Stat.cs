using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]   // 직렬화가 가능한. 컴퓨터가 이해할 수 있는 언어로 바꾸는 것
public class Stat   // public record Stat
{
    public int Health;  // 처음 한번만 대입할때
    public float MoveSpeed;
    public float RotationSpeed;
    public float AttackCoolTime;

}
