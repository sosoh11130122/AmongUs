using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class ImpostorController : MonoBehaviourPunCallbacks
{
    public PhotonView m_PhotonView;

    public bool m_Dead = false;

    bool m_Attack = false;

    public Text m_Nick;

    public float m_MoveSpeed = 4.0f;

    bool m_Spawn = false;
    Collider2D m_Table;

    Vector2 m_ImpostorMove = new Vector2();

    Rigidbody2D m_Rigidbody;
    Animator m_Animator;
    SpriteRenderer m_Sprite;

    GameObject m_ArrowSystem;
    Arrow m_ArrowSystemScript;

    [PunRPC]
    void Start()
    {
        if (m_PhotonView.IsMine)
        {
            m_Nick.text = PhotonNetwork.LocalPlayer.NickName;
            m_Nick.color = Color.red;
        }

        else
        {
            m_Nick.text = m_PhotonView.Owner.NickName;
        }

        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Animator = GetComponent<Animator>();
        m_Sprite = GetComponent<SpriteRenderer>();

        float m_HoritontalInput = Input.GetAxisRaw("Horizontal");
        float m_VerticalInput = Input.GetAxisRaw("Vertical");

        m_ArrowSystem = GameObject.Find("ArrowSystem");
        m_ArrowSystemScript = m_ArrowSystem.GetComponent<Arrow>();

        m_Spawn = GetComponent<GameManager>().m_SpawnButton;
    }

    void Update()
    {
        if (!m_PhotonView.IsMine)
            return;

        if (m_Attack)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                m_Dead = true;
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

        if (m_Spawn)
        {
            transform.position = new Vector2(m_Table.transform.position.x, m_Table.transform.position.y);

            m_Spawn = false;
        }
    }

    private void FixedUpdate()
    {
        if (!m_PhotonView.IsMine)
            return;

        Move();

        //Nick();
        m_PhotonView.RPC("Nick", RpcTarget.All);

    }

    [PunRPC]
    void Move()
    {
        m_ImpostorMove.x = Input.GetAxisRaw("Horizontal");
        m_ImpostorMove.y = Input.GetAxisRaw("Vertical");

        m_ImpostorMove.Normalize(); 

        m_Rigidbody.velocity = m_ImpostorMove * m_MoveSpeed;
    }

    [PunRPC]
    void Nick()
    {
        m_Nick.transform.position = Camera.main.WorldToScreenPoint(new Vector3(this.transform.position.x + 0.8f, this.transform.position.y + 0.02f));
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

    [PunRPC]
    public bool GetDead()
    {
        return m_Dead;
    }
}