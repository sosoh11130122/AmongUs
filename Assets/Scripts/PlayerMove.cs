using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float m_MoveSpeed = 5.0f;

    Vector2 m_PlayerMove = new Vector2();

    Rigidbody2D m_Rigidbody;


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        FlipCheck(); // 방향 바뀔 때 스프라이트 뒤집기.
    }

    private void FixedUpdate()
    {
        m_PlayerMove.x = Input.GetAxisRaw("Horizontal");

        m_PlayerMove.y = Input.GetAxisRaw("Vertical");

        m_PlayerMove.Normalize(); // 대각선 방향 이동 시 속도 빨라지지 않도록.

        m_Rigidbody.velocity = m_PlayerMove * m_MoveSpeed;

    }

    private void FlipCheck()
    {
        float HoritontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");

        if (HoritontalInput < 0)
        {
            transform.localScale = new Vector3(-0.2f, 0.2f, 0.2f); // 방향 이동시 스프라이트 방향 변경.
        }

        if (HoritontalInput > 0)
        {
            transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }
    }
}
