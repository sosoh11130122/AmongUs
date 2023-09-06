using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Arrow : MonoBehaviour
{
    GameObject m_Impostor;

    GameObject m_VentToC; // To Cafeteria
    GameObject m_VentToE; // To Electric
    GameObject m_VentToM; // To Medi

    [SerializeField]
    public bool m_ImpMove = false;

    void Start()
    {
        //gameObject.SetActive(false);

        m_Impostor = GameObject.FindWithTag("Impostor");

        m_VentToC = GameObject.Find("Vent - cafeteria");
        m_VentToE = GameObject.Find("Vent - electric");
        m_VentToM = GameObject.Find("Vent - medi");
    }

    void Update()
    {

    }

    public void ArrowToC()
    {
        m_Impostor.transform.position = m_VentToC.transform.position + new Vector3(0.5f,0f,0f);

        m_ImpMove = true; // true가 되면 임포스터 sprite 가 enabled로 바뀐다.
    }
    public void ArrowToE()
    {
        m_Impostor.transform.position = m_VentToE.transform.position;

        m_ImpMove = true;
    }

    public void ArrowToM()
    {
        m_Impostor.transform.position = m_VentToM.transform.position;

        m_ImpMove = true;
    }

    public bool GetImpMove()
    {
        return m_ImpMove;
    }

    public void SetImpMove(bool ImpMove)
    { 
        m_ImpMove = ImpMove;
    }

}
