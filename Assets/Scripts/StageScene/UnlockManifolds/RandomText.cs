using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RandomText : MonoBehaviour
{
    public Text m_RandomNumText;

    private int m_Num;
    private string m_Text;

    void Start()
    {
        m_Num = Random.Range(0, 9999);

        m_Text = m_Num.ToString();
        m_RandomNumText.text = "ют╥б :  " + m_Text;

    }

    void Update()
    {
    }

    public string GetRandomNum()
    {
        return m_Text;
    }

}
