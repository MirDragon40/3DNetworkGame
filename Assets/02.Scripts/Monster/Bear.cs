using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public enum MonsterState
{
    Idle,
    Trace,
    Attack,
    Comeback,
    Damaged,
    Die,
    Patrol
}

public class Bear : MonoBehaviour
{
    [Range(0, 100)]
    public int Health;
    public int MaxHealth = 100;


    /***********************************************************/
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;

    private Transform _target;
    public float FindDistance = 5f;    // 감지 범위
    public float AttackDistance = 2f;  // 공격 범위
    public float MoveSpeed = 3f;   // 몬스터의 이동속도
    public Vector3 StartPosition;  // 시작 위치
    public float MoveDistance = 10f;  // 움직일 수 있는 거리
    public const float TOLERANCE = 0.1f;  // 허용 오차 (관용)
    public int Damage = 10;
    public const float AttackDelay = 1f;
    private float _attackTimer = 0f;

    private Vector3 _knockbackStartPosition;
    private Vector3 _knockbackEndPosition;
    private float KNOCKBACK_DURATION = 0.1f;
    private float _knockbackPrograss = 0f;
    public float KnockbackPower = 1.2f;

    private const float IDLE_DURATION = 3f;
    public Transform PatrolTarget;
    private float _idleTimer = 0f;

    private MonsterState _currentState = MonsterState.Idle;


    private void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.speed = MoveSpeed;

        _animator = GetComponent<Animator>();

        _target = GameObject.FindGameObjectWithTag("Player").transform;

        StartPosition = _target.position;


    }

    private void Update()
    {
        switch (_currentState)
        {
            case MonsterState.Idle:
                Idle();
                break;
        }
    }
    

    private void Idle()
    {
        _idleTimer += Time.deltaTime;
        if (PatrolTarget != null && _idleTimer >= IDLE_DURATION)
        {
            _idleTimer = 0f;
            Debug.Log("상태 전환: Idle -> Patrol");
            _animator.SetTrigger("IdleToPatrol");
            _currentState = MonsterState.Patrol;
        }

        if (Vector3.Distance(_target.position, transform.position) < FindDistance)
        {
            Debug.Log("상태 전환: Idle -> trace");
            _animator.SetTrigger("IdleToTrace");
            _currentState = MonsterState.Trace;
        }
    }


    private void Trace()
    {
        Vector3 _dir = _target.transform.position - this.transform.position;
        _dir.y = 0;
        _dir.Normalize();

        if (Vector3.Distance(transform.position, StartPosition) >= MoveDistance )
        {
            Debug.Log("상태전환: Trace -> ComeBack ");
            _animator.SetTrigger("TraceToComeback");
            _currentState = MonsterState.Comeback;
        }

        if (Vector3.Distance(_target.position, transform.position) <= AttackDistance )
        {
            Debug.Log("상태전환: Trace -> Attack");
            _animator.SetTrigger("TraceToAttack");
            _currentState = MonsterState.Attack;

        }


    }
}
