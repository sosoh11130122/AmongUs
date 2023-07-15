using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_MoveSpeed = 4.0f;
    private bool m_IsDead = false;

    float m_HoritontalInput = Input.GetAxisRaw("Horizontal");
    float m_VerticalInput = Input.GetAxisRaw("Vertical");

    Vector2 m_PlayerMove = new Vector2();

    Rigidbody2D m_Rigidbody;
    Animator m_Animator;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
    }

    void Update() 
    {
        if(m_IsDead) 
            return;

        FlipCheck(); // 방향 바뀔 때 스프라이트 뒤집기.
    }

    private void FixedUpdate() // 규칙적인 호출로 물리 계산 등에 좋음.
    {
        if (m_IsDead)
            return;

        Move();

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            m_Animator.SetBool("Move", false);

        else
            m_Animator.SetBool("Move", true);
    }

    void Move()
    {
        m_PlayerMove.x = Input.GetAxisRaw("Horizontal");

        m_PlayerMove.y = Input.GetAxisRaw("Vertical");

        m_PlayerMove.Normalize(); // 대각선 방향 이동 시 속도 빨라지지 않도록.

        m_Rigidbody.velocity = m_PlayerMove * m_MoveSpeed;
    }

    private void FlipCheck()
    {
        if (m_HoritontalInput < 0)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f); // 방향 이동시 스프라이트 방향 변경.
        }

        if (m_VerticalInput > 0)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }

    private void Die()
    {
        m_Animator.SetTrigger("Dead");
        m_IsDead = true;
    }
}
