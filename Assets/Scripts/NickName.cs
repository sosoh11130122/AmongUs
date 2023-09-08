using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NickName : MonoBehaviour
{
    GameObject m_Player;
    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindWithTag("Player");

        if (PlayerPrefs.HasKey("NickName"))
            GetComponent<Text>().text = PlayerPrefs.GetString("NickName");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Camera.main.WorldToScreenPoint(new Vector3(m_Player.transform.position.x + 0.8f, m_Player.transform.position.y + 0.02f));
    }
}
