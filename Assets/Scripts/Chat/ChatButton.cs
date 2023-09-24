using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatButton : MonoBehaviour
{
    public GameObject m_ChatSystem;

    void Start()
    {
        
    }

    void Update()
    {

            
    }

    public void ClickChatButton()
    {
        if (m_ChatSystem.gameObject.activeSelf == false)
            m_ChatSystem.gameObject.SetActive(true);

        else
            m_ChatSystem.gameObject.SetActive(false);
    }
}
