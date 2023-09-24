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
    GameObject m_Impostor;

    public GameObject m_NickNameUI;

    public PhotonView m_PlayerPhotonView;
    public PhotonView m_ImpostorPhotonView;

    void Start()
    {
        m_Player = GameObject.FindWithTag("Player");
        m_Impostor = GameObject.FindWithTag("Impostor");

        //PhotonNetwork.NickName = PhotonNetwork.LocalPlayer.NickName;

       // m_NickNameUI.GetComponent<Text>().text = m_ImpostorPhotonView.Owner.NickName;

//        m_ImpostorPhotonView.Owner.NickName = PlayerPrefs.GetString("NickName");
      // PhotonNetwork.LocalPlayer.NickName = PlayerPrefs.GetString("NickName");
       // PhotonNetwork.Instantiate(m_NickNameUI, Vector3.zero, Quaternion.identity);

        
    }

    void Update()
    {
       this.transform.position = Camera.main.WorldToScreenPoint(new Vector3(m_Impostor.transform.position.x + 0.8f, m_Impostor.transform.position.y + 0.02f));
    }
}
