using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ClickWhat : MonoBehaviour
{
    GameObject m_ClickObj;
    string m_strClickObj;
    int m_intClickObj;
    bool m_Fail;
    int m_SuccessCount;
    int[] m_arrButton = new int[10];

    void Start()
    {
        m_Fail = false;
        m_SuccessCount = 0;
    }
    void Update()
    {
        if (!m_ClickObj)
            return;

        for (int i = 0; i < m_arrButton.Length; ++i)
        {
            m_arrButton[i] = m_intClickObj;
            if ((m_arrButton[i] + 1) == m_arrButton[i + 1])
                ++m_SuccessCount;

            else
                m_Fail = true;
        }

        if (m_Fail)
            Fail();

        if (m_SuccessCount == 10)
            Success();

    }

    // 클릭한 버튼이 string일 경우 int로 변환.
    public void ChangeButtonType()
    {
        m_ClickObj = EventSystem.current.currentSelectedGameObject;

        m_strClickObj = m_ClickObj.GetComponentInChildren<Text>().text;

        m_intClickObj = int.Parse(m_strClickObj);
    }

    public int GetintClickObject()
    {
        if (!m_ClickObj)
            return 0;

        return m_intClickObj;
    }

    void Success()
    {
        Debug.Log("성공!");
    }

    void Fail()
    {
        Debug.Log("실패!");
    }
}