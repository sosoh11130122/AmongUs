using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VentSystem : MonoBehaviour
{
    Collider2D m_Collider;
    Animator m_Animator;

    public Button m_Arrow1;
    public Button m_Arrow2;
    GameObject m_Impostor;

    bool m_Collision = false;


    void Start()
    {
        m_Collider = GetComponent<Collider2D>();
        m_Animator = GetComponent<Animator>();
        m_Impostor = GameObject.FindWithTag("Impostor");
    }

    void Update()
    {
        if(m_Collision)
            GameObject.Find("Impostor").GetComponent<Animator>().SetBool("VentOn", true); // 임포스터 벤트 애니메이션으로 전환.
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Impostor")
        {
            m_Collision = true;

            StartCoroutine("VentIn");

            
            
            m_Animator.SetBool("m_ImposterOn", true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Impostor")
        {
            m_Collision = false;

            m_Arrow1.gameObject.SetActive(false);
            m_Arrow2.gameObject.SetActive(false);

            m_Animator.SetBool("m_ImposterOn", false);
            GameObject.Find("Impostor").GetComponent<Animator>().SetBool("VentOn", false);
            m_Impostor.GetComponent<SpriteRenderer>().enabled = true;

        }
    }

    IEnumerator VentIn()
    {
        yield return new WaitForSeconds(1);
        m_Impostor.GetComponent<SpriteRenderer>().enabled = false;

        m_Arrow1.gameObject.SetActive(true);
        m_Arrow2.gameObject.SetActive(true);
    }
}