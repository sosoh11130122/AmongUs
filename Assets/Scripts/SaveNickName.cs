using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveNickName : MonoBehaviourPunCallbacks
{
    public InputField m_InputNickName;
    // Start is called before the first frame update

    private void Update()
    {
        if (Input.GetKey("return"))
            Save();

    }

    public void Save()
    {
        PlayerPrefs.SetString("NickName", m_InputNickName.text);
        PhotonNetwork.NickName = m_InputNickName.text;
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("NickName"))
        {
            m_InputNickName.text = PlayerPrefs.GetString("NickName");
        }
    }
}

