using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NickFollow : MonoBehaviour
{
    public GameObject m_Player;
    public GameObject m_Impostor;
    public PhotonView m_View;


    void Start()
    {
        //if (m_View.IsMine)
        //{
        //    PhotonNetwork.LocalPlayer.NickName = PlayerPrefs.GetString("NickName");
        //    GetComponent<Text>().text = PhotonNetwork.LocalPlayer.NickName;
        //}
        //GetComponent<Text>().text = PlayerPrefs.GetString("NickName");


        PhotonNetwork.LocalPlayer.NickName = PlayerPrefs.GetString("NickName");
        GetComponent<Text>().text = PhotonNetwork.LocalPlayer.NickName;

        //m_View.RPC("SetName", RpcTarget.All); <-½ÇÆÐ.
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Player)
            this.transform.position = Camera.main.WorldToScreenPoint(new Vector3(m_Player.transform.position.x + 0.8f, m_Player.transform.position.y + 0.02f));

        else
            this.transform.position = Camera.main.WorldToScreenPoint(new Vector3(m_Impostor.transform.position.x + 0.8f, m_Impostor.transform.position.y + 0.02f));
    }

    [PunRPC]
    void SetName()
    {

        PhotonNetwork.LocalPlayer.NickName = PlayerPrefs.GetString("NickName");
        GetComponent<Text>().text = PhotonNetwork.LocalPlayer.NickName;
    }


}
