using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NickName : MonoBehaviourPunCallbacks
{
    GameObject m_Player;

    void Start()
    {
        m_Player = GameObject.FindWithTag("Player");

        PhotonNetwork.NickName = PlayerPrefs.GetString("NickName");

    }

    void Update()
    {
        this.transform.position = Camera.main.WorldToScreenPoint(new Vector3(m_Player.transform.position.x + 0.8f, m_Player.transform.position.y + 0.02f));

       
    }
}
