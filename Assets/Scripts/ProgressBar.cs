using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    // ���α׷��� ��
    public Image m_LoadingBar;

    float m_CurrentValue;

    public float m_Speed;

    // Ÿ�̸�
    public Text m_Timer;

    float m_Time = 6f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (m_CurrentValue < 100)
        {
            m_CurrentValue += m_Speed * Time.deltaTime;
        }

        m_LoadingBar.fillAmount = m_CurrentValue / 100;

        m_Time -= Time.deltaTime;

        m_Timer.text = "�˻� �Ϸ���� " + ((int)m_Time % 60).ToString() + " ��";

        if (m_Time <= 0f)
            m_Time = 0f;
    }
}
