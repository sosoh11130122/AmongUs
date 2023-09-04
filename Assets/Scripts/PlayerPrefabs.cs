using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPrefabs : MonoBehaviour
{
    public InputField m_InputName;
    bool m_InputOn = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
            m_InputOn = true;

        if(Input.GetKeyUp(KeyCode.Return))
            m_InputOn = false;

        if (m_InputOn)
        {
            Save();
            m_InputOn = false;
        }
    }

    public void Save()
    {
        PlayerPrefs.SetString("NickName", m_InputName.text);
    }

    // Update is called once per frame
    public void Load()
    {
        if (PlayerPrefs.HasKey("NickName"))
        {
            m_InputName.text = PlayerPrefs.GetString("NickName");
        }
    }
}
