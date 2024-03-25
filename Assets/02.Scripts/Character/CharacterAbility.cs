using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스크립트의 Ability라는 속성을 하나로 묶는다. 모든 캐릭터의 능력은 owner를 가지고 있다. 
public class CharacterAbility : MonoBehaviour
{
    protected Character Owner { get; private set; }

    protected void Awake()
    {
        Owner = GetComponent<Character>();
    }
}
