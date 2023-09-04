using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_MoveSpeed = 4.0f;

    Vector2 m_PlayerMove = new Vector2();

    Rigidbody2D    m_Rigidbody;
    Animator       m_Animator;
    SpriteRenderer m_Sprite;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_Sprite = GetComponent<SpriteRenderer>();

        float m_HoritontalInput = Input.GetAxisRaw("Horizontal");
        float m_VerticalInput = Input.GetAxisRaw("Vertical");
    }

    void Update() 
    {
        //if(m_IsDead) 
        //    return;

        if (m_Animator.GetBool("Dead"))
        {
            m_MoveSpeed = 0f;
            m_PlayerMove = new Vector2(0f, 0f);
            
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            m_Animator.SetBool("Move", false); // �ִϸ����� �Ķ���Ϳ� ����.

        else
        {
            m_Animator.SetBool("Move", true);

            // ���� üũ.
            if (Input.GetAxisRaw("Horizontal") == -1)
                m_Sprite.flipX = true;

            else
                m_Sprite.flipX = false;
        }
    }

    private void FixedUpdate() // ��Ģ���� ȣ��� ���� ��� � ����.
    {
        Move();
    }

    void Move()
    {
        m_PlayerMove.x = Input.GetAxisRaw("Horizontal");

        m_PlayerMove.y = Input.GetAxisRaw("Vertical");

        m_PlayerMove.Normalize(); // �밢�� ���� �̵� �� �ӵ� �������� �ʵ���.

        m_Rigidbody.velocity = m_PlayerMove * m_MoveSpeed;

    }
}
