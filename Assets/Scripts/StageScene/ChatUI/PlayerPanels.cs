using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPanels : MonoBehaviour
{
    public GameObject m_NickNameUI;
    public GameObject m_PlayerPanel;
    public GameObject m_voteIconImg;
    public GameObject m_PlayerIcon;



    int m_CountPlayer = 0; // 플레이어 수 
    List<GameObject>m_voteIcon = new List<GameObject>(); // 아이콘 리스트. select, cancel 키에 따라서 다르게 기능 구현.
    //Text m_NickName = m_NickNameUI; // 닉네임 받아오는 것
    bool m_VoteEnd = false;

    


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
