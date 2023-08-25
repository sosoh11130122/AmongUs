using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UnlockManifolds : MonoBehaviour
{
    public RandomText m_RandomNumText;
    public Text m_InputUI;

    public GameObject m_MissionWindow; // 미션 창.
    public GameObject m_MissionFinishText;

    public Slider m_MissionProgressBar;

    bool m_Finish = false;
    bool m_Fail = false;

    string m_InputText;

    void Update()
    {
        if (m_Finish || m_Fail)
        {
            StartCoroutine(WaitForIt());
        }
    }

    public void AddList(Button button)
    {
        Text Text = button.GetComponentInChildren<Text>(); // 버튼의 text를 가져옴.

        m_InputUI.text += Text.text;
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(2.0f);

        if (m_Finish)
            m_MissionWindow.SetActive(false);

        else if (m_Fail)
        {
            m_MissionFinishText.GetComponentInChildren<Text>().enabled = false;

            m_InputUI.text = string.Empty;
            m_Fail = false;
        }
    }

    public void ClickCheckButton()
    {
        if (m_InputUI.text != m_RandomNumText.GetRandomNum())
        {
            m_Fail = true;

            m_MissionFinishText.GetComponentInChildren<Text>().enabled = true;
            m_InputUI.text = string.Empty;
        } 

        else
        {
            m_Finish = true;

            m_MissionFinishText.GetComponentInChildren<Text>().enabled = true;
            m_MissionFinishText.GetComponentInChildren<Text>().text = ("임무 성공!");

            m_MissionProgressBar.value += 25f;

            m_InputUI.text = string.Empty;
        }
    }
}
