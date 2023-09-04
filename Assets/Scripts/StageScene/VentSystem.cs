using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentSystem : MonoBehaviour
{
    Collider2D m_Collider;
    Animator m_Animator;

    public GameObject m_Arrow;

    void Start()
    {
        m_Collider = GetComponent<Collider2D>();
        m_Animator = GetComponent<Animator>();
    }

    void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Impostor")
        {

            Debug.Log("Ãæµ¹");
            m_Arrow.SetActive(true);
            m_Animator.SetBool("m_ImposterOn", true);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Impostor")
        {
            m_Arrow.SetActive(false);
            m_Animator.SetBool("m_ImposterOn", false);


        }
    }
}