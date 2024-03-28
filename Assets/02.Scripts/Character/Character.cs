using Cinemachine;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterMoveAbility))]
[RequireComponent(typeof(CharacterRotateAbility))]
[RequireComponent(typeof(CharacterAttackAbility))]
[RequireComponent(typeof(CharacterShakeAbility))]

public class Character : MonoBehaviour, IPunObservable, IDamaged   // 인터페이스: 약속, 접점
{
    public PhotonView PhotonView { get; private set; }
    public Stat Stat;

    private Vector3 _receivedPosition;
    private Quaternion _receivedRotation;

    private CinemachineImpulseSource _impulseSource;

    private float ui_DamageImage_Coroutine = 0.5f;

    

    private void Awake()
    {
        Stat.Init();

        PhotonView = GetComponent<PhotonView>();
        _impulseSource = GetComponent<CinemachineImpulseSource>();

        if (PhotonView.IsMine)
        {
            UI_CharacterStat.Instance.MyCharacter = this;
        }
    }

    private void Update()
    {
        if (!PhotonView.IsMine)
        {
            transform.position = Vector3.Lerp(transform.position, _receivedPosition, Time.deltaTime * 20f);
            transform.rotation = Quaternion.Slerp(transform.rotation, _receivedRotation, Time.deltaTime * 20f);
            

        }
    }
    // 데이터 동기화를 위해 데이터 전송 및 수신 기능을 가진 약속
    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        // stream(통로)은 서버에서 주고받을 데이터가 담겨있는 변수
        if (stream.IsWriting)    // 데이터를 전송하는 상황
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
            stream.SendNext(Stat.Health);
            stream.SendNext(Stat.Stamina);
                
        }
        else if (stream.IsReading)  // 데이터를 수신하는 상황
        {
            // 데이터를 전송한 순서와 똑같이 받은 데이터를 캐스팅해야된다.
            _receivedPosition     = (Vector3)stream.ReceiveNext();
            _receivedRotation = (Quaternion)stream.ReceiveNext();

          if (!PhotonView.IsMine)
            {
                Stat.Health = (int)stream.ReceiveNext();
                Stat.Stamina = (float)stream.ReceiveNext();
            }
        }
        // info는 데이터의 송수신 성공/실패 여부에 대한 메시지가 담겨있다. 
    }

    [PunRPC]
    public void Damaged(int damage)
    {
        Stat.Health -= damage;
        GetComponent<CharacterShakeAbility>().Shake();


        if (PhotonView.IsMine)
        {
            // 카메라 흔들기 위해 Impulse를 발생시킨다.
            CinemachineImpulseSource impulseSource;
            if (TryGetComponent<CinemachineImpulseSource>(out impulseSource))
            {
                float strength = 0.4f;
                impulseSource.GenerateImpulseWithVelocity(UnityEngine.Random.insideUnitSphere.normalized * strength);
            }
            UI_DamagedEffect.Instance.Show(0.5f);

            // 재사용성을 높이는 것: 
        }
    }
}
