using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StorageLever : MonoBehaviour
{
    public Image m_LeverUp;
    Collider2D m_Box2D;


    void Start()
    {
        m_Box2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
            m_LeverUp.gameObject.SetActive(true);
    }

}
