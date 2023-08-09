using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson.PunDemos;

public class ShakeMove : MonoBehaviour
{
    public GameObject m_GameObject;
    Vector3 m_Pos;

    [SerializeField][Range(0.01f, 0.1f)] float m_ShakeRange = 0.05f;
    [SerializeField][Range(0.01f, 0.1f)] float m_Duration = 0.05f;

    public void Shake()
    {
        m_Pos = this.transform.position;
        InvokeRepeating("StartShake", 0f, 0.005f);
        Invoke("StopShake", m_Duration);
    }

    void StartShake()
    {
        float PosX = Random.value * m_ShakeRange * 2 - m_ShakeRange;
        float PosY = Random.value * m_ShakeRange * 2 - m_ShakeRange;

        Vector3 m_Pos = this.transform.position;

        m_Pos.x += PosX;
        m_Pos.y += PosY;

        m_GameObject.transform.position = m_Pos;
    }

    void StopShake()
    {
        CancelInvoke("StartShake");
        m_GameObject.transform.position = m_Pos;
    }
}
