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

    private PhotonView m_PhotonView;

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
        //if (m_PhotonView.IsMine)
        //{
        //    if ((string)PhotonNetwork.LocalPlayer.TagObject == m_Player.tag)
        //    {
        //        this.transform.position = Camera.main.WorldToScreenPoint(new Vector3(m_Player.transform.position.x + 0.8f, m_Player.transform.position.y + 0.02f));
        //    }

        //    else
        //    {
        //        this.transform.position = Camera.main.WorldToScreenPoint(new Vector3(m_Impostor.transform.position.x + 0.8f, m_Impostor.transform.position.y + 0.02f));

        //    }

        //    //this.transform.position = Camera.main.WorldToScreenPoint(new Vector3(m_Impostor.transform.position.x + 0.8f, m_Impostor.transform.position.y + 0.02f));
        //}

        if (m_PlayerPhotonView.IsMine)
        {
          //  this.transform.position = Camera.main.WorldToScreenPoint(new Vector3(PhotonNetwork.LocalPlayerposition.x + 0.8f, m_Player.transform.position.y + 0.02f));
        }

        if (m_ImpostorPhotonView.IsMine)
        {
            this.transform.position = Camera.main.WorldToScreenPoint(new Vector3(m_Impostor.transform.position.x + 0.8f, m_Impostor.transform.position.y + 0.02f));
        }
    }
}
