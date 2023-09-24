using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StorageLever : MonoBehaviourPunCallbacks
{
    public Image m_LeverUp;
    public GameObject m_Lever;
    Collider2D m_Box2D;
    public PhotonView m_View;


    void Start()
    {
        m_Box2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && m_View.IsMine == true)
        {
            m_LeverUp.gameObject.SetActive(true);
            m_Lever.GetComponent<Collider2D>().enabled = false;
        }
        

    }

}
