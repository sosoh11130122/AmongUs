using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNickName : MonoBehaviour
{
    public GameObject m_PlayerNickName;
    Text m_NickNameText;
    public GameObject m_Player;
    
    void Start()
    {
        m_NickNameText = m_PlayerNickName.GetComponent<Text>();
        m_NickNameText.text = PlayerPrefs.GetString("NickName");

        Vector3 Pos = Camera.main.WorldToScreenPoint(m_Player.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
