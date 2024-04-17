using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UI_Room : MonoBehaviour
{
    private RoomInfo _roomInfo;

    public Text RoomNameTextUI;
    public Text NicknameTextUI;
    public Text PlayerCountTextUI;

    public void Set(RoomInfo room)
    {
        _roomInfo = room;

        RoomNameTextUI.text = room.Name;
        NicknameTextUI.text = room.CustomProperties["MasterNickname"].ToString();
        PlayerCountTextUI.text = $"{room.PlayerCount} / {room.MaxPlayers}";  // PlayerCount 대신 Players.Count
    }

    // 룸 UI를 클릭했을떄 호출되는 함수
    public void OnClickRoom()
    {
        PhotonNetwork.JoinRoom(_roomInfo.Name);
    }
}

