using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeButtonColor : MonoBehaviour
{
    Button m_Button;
    void Start()
    {
        m_Button = GetComponent<Button>();
        m_Button.onClick.AddListener(ChangeColor);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ChangeColor()
    {
        m_Button.GetComponent<Image>().color = Color.green;
    }
}
