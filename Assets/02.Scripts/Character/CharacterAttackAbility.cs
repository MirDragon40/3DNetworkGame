using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterAttackAbility : MonoBehaviour
{
    private Animator _animator;

    public float CoolTime = 1f;
    private bool _isCoolDown = false;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        CharacterAttack();

    }

    private void CharacterAttack()
    {
        if (Input.GetMouseButtonDown(0) && !_isCoolDown)
        {
            Debug.Log("플레이어 공격모션 실행!");
            _animator.SetTrigger($"Attack{Random.Range(1,4)}");

            StartCoroutine(CoolDown_Coroutine());
        }

    }

    private IEnumerator CoolDown_Coroutine()
    {
        // 쿨타임 상태로 변경
        _isCoolDown = true;
        // 설정된 쿨타임 동안 대기
        yield return new WaitForSeconds(CoolTime);
        // 쿨타임 종료 후 상태 변경
        _isCoolDown = false;

    }
}
