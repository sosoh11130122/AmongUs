using NUnit.Framework;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using Photon.Realtime;
using ExitGames.Client.Photon.StructWrapping;

// 점수와 게임 오버 여부, 게임 UI를 관리하는 게임 매니저
public class GameManager : MonoBehaviourPunCallbacks
{
    // 외부에서 싱글톤 오브젝트를 가져올때 사용할 프로퍼티
    public static GameManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<GameManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static GameManager m_instance; // 싱글톤이 할당될 static 변수

    public GameObject playerPrefab; // 생성할 플레이어 캐릭터 프리팹
    public GameObject ImpostorPrefab;

    // 1021
    private GameObject m_Crew;
    private GameObject m_Impo;


    public GameObject m_ImpostorScene;
    public GameObject m_CrewScene;
    public Image m_BlackScene;

    // m_NickNameUI
    //public GameObject m_NickNameUI; //m_NickNameUI

    public int m_Random;


    //0907
    //public PhotonView m_PhotonView; 
    List<int> m_PlayerList = new List<int>();

    private int ImpostorCount = 0;
    private int ImpostorNum = 1;

    private int score = 0; // 현재 게임 점수
    public bool isGameover { get; private set; } // 게임 오버 상태

    // 주기적으로 자동 실행되는, 동기화 메서드
    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //     로컬 오브젝트라면 쓰기 부분이 실행됨
    //    if (stream.IsWriting)
    //    {
    //         네트워크를 통해 score 값을 보내기
    //        stream.SendNext(score);
    //    }
    //    else
    //    {
    //         리모트 오브젝트라면 읽기 부분이 실행됨         

    //         네트워크를 통해 score 값 받기
    //        score = (int)stream.ReceiveNext();
    //         동기화하여 받은 점수를 UI로 표시
    //        UIManager.instance.UpdateScoreText(score);
    //    }
    //}

    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 GameManager 오브젝트가 있다면
        if (instance != this)
        {
            // 자신을 파괴
            Destroy(gameObject);
        }

        else
        {
            DontDestroyOnLoad(this);
        }
    }

    // 게임 시작과 동시에 플레이어가 될 게임 오브젝트를 생성
    private void Start()
    {
        // 생성할 랜덤 위치 지정
        Vector3 randomSpawnPos = Random.insideUnitSphere * 5f;

        //Vector3 SpawnTablePos = new Vector3(Mathf.Cos(30f) * 0.002f + m_Table.transform.position.x, Mathf.Sin(30f) * 0.002f + m_Table.transform.position.y);

        // 위치 y값은 0으로 변경
        randomSpawnPos.y = 0f;

        int Impo = Random.Range(0, PhotonNetwork.PlayerList.Length - 1);

        for (int i = 0; i < PhotonNetwork.PlayerList.Length; ++i)
        {
            if (PhotonNetwork.LocalPlayer == PhotonNetwork.PlayerList[i])
            {
                if (i == Impo)
                {
                    m_Impo = PhotonNetwork.Instantiate(ImpostorPrefab.name, randomSpawnPos, Quaternion.identity);

                    m_Random = Random.Range(0, 1000);

                    PlayerPrefs.SetString("Impostor" + m_Random.ToString(), "1");
                }

                else
                {
                    m_Crew = PhotonNetwork.Instantiate(playerPrefab.name, randomSpawnPos, Quaternion.identity);
                }
            }
        }

    }


    // 게임 오버 처리
    public void EndGame()
    {
        // 게임 오버 상태를 참으로 변경
        isGameover = true;
        // 게임 오버 UI를 활성화
    }

    // 키보드 입력을 감지하고 룸을 나가게 함
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.LeaveRoom();
        }
    }

    public void LoadScene()
    {
        PhotonNetwork.LoadLevel("Stage");
    }

    // 룸을 나갈때 자동 실행되는 메서드
    public override void OnLeftRoom()
    {
        // 룸을 나가면 로비 씬으로 돌아감
        SceneManager.LoadScene("LobbyScene");
    }
}