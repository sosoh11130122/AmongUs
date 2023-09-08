using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager_B : MonoBehaviour
{
    public InputField m_Input;
    public Text m_Text;
    public Button m_Button;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {
        m_Text.text = m_Input.text;
        m_Input.text = "";
    }
}
