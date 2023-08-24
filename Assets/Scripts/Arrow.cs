using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Arrow : MonoBehaviour
{
    GameObject m_Impostor;
    GameObject m_DirObj;

    Vector2 m_Dir;

    
    void Start()
    {
        m_Impostor = GameObject.FindWithTag("Impostor");

       // m_DirObj = GameObject.FindWithTag("DirObj"); 
        m_Dir = transform.GetChild(0).position - transform.position;
    }

    void Update()
    {
        Debug.DrawRay(transform.position, m_Dir * 10, new Color(1, 0, 0));

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D[] Hits;
            Hits = Physics2D.RaycastAll(transform.position, m_Dir, 10.0f, LayerMask.GetMask("Vent"));

            if (Hits.Length != null)
            {
                m_Impostor.transform.position = Hits[0].collider.transform.position;
            }

            for (int i = 0; i < Hits.Length; ++i)
            {
                RaycastHit2D Hit = Hits[i];


                Debug.Log(Hit.collider.gameObject.name);
            }
        }
    }
}
