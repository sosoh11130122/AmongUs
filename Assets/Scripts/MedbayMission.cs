using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MedbayMission : MonoBehaviour
{
    public GameObject m_Mission;
    public GameObject m_Trigger;
    public GameObject m_Player;
    public GameObject m_MissionUI;
    public Slider m_MissionProgressBar;

    float m_Timer;

    bool m_MissionOn = false;

    Vector2 m_MissionPosition = new Vector2(-1.59f, 0.77f);

    // Start is called before the first frame update
    void Start()
    {
        //m_Mission = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (m_MissionOn)
        {
            if (m_Player.GetComponent<SpriteRenderer>().flipX == false)
                m_Player.GetComponent<SpriteRenderer>().flipX = true;

            m_Player.transform.position = m_MissionPosition;

            m_Timer += Time.deltaTime;

            if (m_Timer >= 6.5f)
            {
                Destroy(m_Trigger);
                m_MissionProgressBar.value += 25f;
            }

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            m_Mission.SetActive(true);
            m_MissionUI.SetActive(true);

            m_MissionOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            m_Mission.SetActive(false);

            m_MissionUI.SetActive(false);

            m_MissionOn = false;
        }
           
    }
}
