using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpostorController : MonoBehaviour
{
    public GameObject m_Player;
    public Animator m_PlayerAnimation;

    bool m_Attack = false;

    public float m_MoveSpeed = 4.0f;

    Vector2 m_ImpostorMove = new Vector2();

    Rigidbody2D m_Rigidbody;
    Animator m_Animator;
    SpriteRenderer m_Sprite;

    GameObject m_ArrowSystem;
    Arrow m_ArrowSystemScript;

    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_Sprite = GetComponent<SpriteRenderer>();

        m_PlayerAnimation = m_Player.GetComponent<Animator>();

        float m_HoritontalInput = Input.GetAxisRaw("Horizontal");
        float m_VerticalInput = Input.GetAxisRaw("Vertical");

        m_ArrowSystem = GameObject.Find("ArrowSystem");
        m_ArrowSystemScript = m_ArrowSystem.GetComponent<Arrow>();

    }

    void Update()
    {
        if (m_Attack)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                m_PlayerAnimation.SetBool("Dead", true);
            }
        }

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
            m_Animator.SetBool("Move", false); 

        else
        {
            m_Animator.SetBool("Move", true);

            // ???? ??.
            if (Input.GetAxisRaw("Horizontal") == -1)
                m_Sprite.flipX = true;

            else
                m_Sprite.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        m_ImpostorMove.x = Input.GetAxisRaw("Horizontal");
        m_ImpostorMove.y = Input.GetAxisRaw("Vertical");

        m_ImpostorMove.Normalize(); 

        m_Rigidbody.velocity = m_ImpostorMove * m_MoveSpeed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            m_Attack = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            m_Attack = false;
        }

    }
}