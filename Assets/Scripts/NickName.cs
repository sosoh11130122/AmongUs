using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NickName : MonoBehaviour
{
    GameObject m_Player;
    // Start is called before the first frame update
    void Start()
    {
        m_Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Camera.main.WorldToScreenPoint(new Vector3(m_Player.transform.position.x, m_Player.transform.position.y + 0.05f));
    }
}
