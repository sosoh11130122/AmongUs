using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeverUptoDown : MonoBehaviour
{
    Image m_Sprite;
    public Sprite m_NewSprite; // 변경할 새 스프라이트.

    Collider2D m_Collider;

    bool m_DragOn = false;

    void Start()
    {
        m_Sprite = GetComponent<Image>();
        m_Collider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    void ChangeImage()
    {
        m_Sprite.sprite = m_NewSprite; // LeverDown으로 이미지 변경
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ChangeImage();
        //if (collision.gameObject.tag == "Lever")
         


    }

}
