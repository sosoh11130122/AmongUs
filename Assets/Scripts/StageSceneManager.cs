using ExitGames.Client.Photon.StructWrapping;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Realtime;
using TMPro;
using Photon.Pun.UtilityScripts;
using static UnityEngine.Rendering.DebugUI;

public class StageSceneManager : MonoBehaviourPunCallbacks
{
    // 외부에서 싱글톤 오브젝트를 가져올때 사용할 프로퍼티
    public static StageSceneManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<StageSceneManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static StageSceneManager m_instance; // 싱글톤이 할당될 static 변수

    // 해당 캐릭터 리스폰 용도
    // public GameObject m_Crew;
    // public bool m_SpawnButton = false;
    // public Collider2D m_Table;

    public GameObject m_ImpostorScene;
    public GameObject m_CrewScene;
    public Image m_BlackScene;

    public bool m_SpawnButton = false;
    public Collider2D m_Table;

    public GameObject m_Impo;
    public GameObject m_Crew;

    private int m_ImpoKey;

    private int score = 0; // 현재 게임 점수
    public bool isGameover { get; private set; } // 게임 오버 상태

    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }

        m_ImpoKey = GameManager.FindAnyObjectByType<GameManager>().m_Random;
    }

    private void Start()
    {
        StartCoroutine("FadeIn");

        if (PlayerPrefs.HasKey("Impostor" + m_ImpoKey.ToString()))
        {
            StartCoroutine("ImpostorScene");
        }

        else
        {
            StartCoroutine("CrewScene");
        }

        // m_Crew = FindObjectOfType<GameManager>().playerPrefab;
        //m_CrewPhotonView.StartCoroutine("CrewScene");

        //if (PhotonNetwork.LocalPlayer)
        //{
        //    StartCoroutine("CrewScene");
        //}

        //if (m_Crew.GetPhotonView().IsMine)
        //{
        //    StartCoroutine("CrewScene");
        //}

        //else if (m_Impo.GetPhotonView().IsMine)
        //{
        //    StartCoroutine("ImpostorScene");
        //}
    }

    public void EndGame()
    {
        // 게임 오버 상태를 참으로 변경
        isGameover = true;
        // 게임 오버 UI를 활성화
    }

    // 키보드 입력을 감지하고 룸을 나가게 함
    private void Update()
    {
        if (m_SpawnButton)
        {
            //photonView.RPC("SpawnPlayer", RpcTarget.All);
            SpawnPlayer();
        }
    }

    IEnumerator ImpostorScene()
    {
        m_ImpostorScene.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        StartCoroutine("FadeOut");

    }

    IEnumerator CrewScene()
    {
        m_CrewScene.gameObject.SetActive(true);

        yield return new WaitForSeconds(3f);

        StartCoroutine("FadeOut");
    }

    IEnumerator FadeIn()
    {
        m_BlackScene.gameObject.SetActive(true);

        m_BlackScene.color = new Color(0, 0, 0, 1);

        float FadeCount = 1;

        while (FadeCount > 0f)
        {
            FadeCount -= 0.01f;

            yield return new WaitForSeconds(0.01f);

            m_BlackScene.color = new Color(0, 0, 0, FadeCount);
        }
    }

    IEnumerator FadeOut()
    {
        m_BlackScene.color = new Color(0, 0, 0, 0);

        float FadeCount = 0;

        while (FadeCount <= 1f)
        {
            FadeCount += 0.01f;

            yield return new WaitForSeconds(0.01f);

            m_BlackScene.color = new Color(0, 0, 0, FadeCount);
        }

        if (FadeCount >= 1f)
        {
            m_BlackScene.gameObject.SetActive(false);
            m_ImpostorScene.gameObject.SetActive(false);
            m_CrewScene.gameObject.SetActive(false);
        }
    }

    // 플레이어 리스폰 위치
    // (cos(플레이어 리스트/360) * 반지름 + 원점에서부터 식탁까지 x, sin(플레이어 리스트/360)*반지름 원점에서부터 식탁까지 y)
    public void SpawnPlayer()
    {
        //playerPrefab.transform.position = new Vector2(m_Table.transform.position.x, m_Table.transform.position.y);//new Vector2(Mathf.Cos(30f) * 0.002f + m_Table.transform.position.x, Mathf.Sin(30f) * 0.002f + m_Table.transform.position.y);
        //m_Crew.transform.position = new Vector2(m_Table.transform.position.x, m_Table.transform.position.y);

        for (int i = 0; i < PhotonNetwork.PlayerList.Length; ++i)
        {

            if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[i])
            {
                if (PlayerPrefs.HasKey("Impostor1"))
                {
                    GameObject Impo = GameObject.FindGameObjectWithTag("Impostor");
                    Impo.transform.position = new Vector3(Mathf.Cos(30f * i) * 0.001f + m_Table.transform.position.x, Mathf.Sin(30f * i) * 0.001f + m_Table.transform.position.y);
                }

                else
                {
                    GameObject Crew = GameObject.FindGameObjectWithTag("Player");
                    Crew.transform.position = new Vector2(Mathf.Cos(30f * i) * 0.001f + m_Table.transform.position.x, Mathf.Sin(30f * i) * 0.001f + m_Table.transform.position.y);
                }
            }
        }

        m_SpawnButton = false;
    }

    public void Spawn()
    {
        m_SpawnButton = true;
    }
}
