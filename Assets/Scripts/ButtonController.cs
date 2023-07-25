using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Button m_Btn1, m_Btn2, m_Btn3, m_Btn4, m_Btn5, m_Btn6;
    bool m_Enable = false;
    void Start()
    {
        m_Btn1 = GetComponent<Button>();
        m_Btn2 = GetComponent<Button>(); 
        m_Btn3 = GetComponent<Button>();
        m_Btn4 = GetComponent<Button>();
        m_Btn5 = GetComponent<Button>();
        m_Btn6 = GetComponent<Button>();

        m_Btn1.onClick.AddListener(ActiveOn);
        m_Btn2.onClick.AddListener(ActiveOn);
        m_Btn3.onClick.AddListener(ActiveOn);
        m_Btn4.onClick.AddListener(ActiveOn);
        m_Btn5.onClick.AddListener(ActiveOn);
        m_Btn6.onClick.AddListener(ActiveOn);

    }

    void ActiveOn()
    {
        m_Enable = true;
    }

    void Update()
    {
        if(m_Enable)
        {


        }
    }
}
