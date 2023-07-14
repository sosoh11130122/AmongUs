using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float m_MoveSpeed = 5.0f;
    //private bool m_IsMove = false;

    private Rigidbody2D m_Rigidbody;
    private SpriteRenderer m_SpriteRenderer;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
       // if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            //m_IsMove = false;

        Move();
    }

    void Move()
    {
        // m_IsMove = true;
        Vector3 PlayerPos = Vector3.zero;

        float HoritontalInput = Input.GetAxisRaw("Horizontal");
        float VerticalInput = Input.GetAxisRaw("Vertical");

        if (HoritontalInput < 0)
        {
            PlayerPos = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1); // 방향 이동시 스프라이트 방향 변경.
        }

        else if (HoritontalInput > 0)
        {
            PlayerPos = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);
        }

        else if (VerticalInput > 0)
            PlayerPos = Vector3.up;

        else if (VerticalInput < 0)
            PlayerPos = Vector3.down;

        transform.position += PlayerPos * m_MoveSpeed * Time.deltaTime;
    }
}
