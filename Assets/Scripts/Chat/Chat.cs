using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Chat : MonoBehaviour
{
    public InputField m_InputField; // 내가 메시지 입력하는 곳.
    public GameObject m_Message;
    public GameObject m_Content; // 채팅창에 띄워지는 말풍선.

    public void SendMessage()
    {
        GetComponent<PhotonView>().RPC("GetMessage", RpcTarget.All, m_InputField.text); // RpcTarget.All 은 모두에게 보이게 하는 것. 
    }

    [PunRPC]
    public void GetMessage(string ReceiveMessage)
    { 
        GameObject M = Instantiate(m_Message, Vector3.zero, Quaternion.identity, m_Content.transform);
        M.GetComponent<Message>().m_MyMessage.text = ReceiveMessage;

    }

}