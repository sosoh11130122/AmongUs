using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson.PunDemos;

public class ShakeMove : MonoBehaviour
{
    //public GameObject m_GameObject;
    //public Canvas m_Canvas;
    Vector3 m_Pos;

    [SerializeField][Range(0f, 1f)] float m_ShakeRange = 10f;
    [SerializeField][Range(0f, 1f)] float m_Duration = 10f;

    public void Shake()
    {
        m_Pos = transform.position;
        InvokeRepeating("StartShake", 0f, 50f);
        Invoke("StopShake", m_Duration);
    }

    void StartShake()
    {
        float PosX = Random.Range(-0.01f, 1f) * m_ShakeRange * 2 - m_ShakeRange;
        float PosY = Random.Range(-0.01f, 1f) * m_ShakeRange * 2 - m_ShakeRange;

        m_Pos.x += PosX;
        m_Pos.y += PosY;

        transform.position = m_Pos;
    }

    void StopShake()
    {
        CancelInvoke("StartShake");
    }

    private void Update()
    {
        Shake();
    }

    ///////////////////////////////////////////////////////////////////////
    //private void Start()
    //{
    //    m_Pos = transform.position;
    //}

    //private void Update()
    //{
    //    float PosX = Random.value * m_ShakeRange * 2 - m_ShakeRange;
    //    float PosY = Random.value * m_ShakeRange * 2 - m_ShakeRange;

    //    m_Pos.x += PosX;
    //    m_Pos.y += PosY;

    //   //m_Pos.x += Time.deltaTime * 50f;

    //    transform.position = m_Pos;
    //}

}
