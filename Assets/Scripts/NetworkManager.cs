using Photon.Pun; // 유니티용 포톤 컴포넌트들
using Photon.Realtime; // 포톤 서비스 관련 라이브러리
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using Unity.VisualScripting;
using Photon.Pun.Demo.PunBasics;
using UnityEngine.SocialPlatforms.Impl;

// 마스터(매치 메이킹) 서버와 룸 접속을 담당
public class NetworkManager : MonoBehaviourPunCallbacks
{
    private string gameVersion = "1"; // 게임 버전

    public Text connectionInfoText; // 네트워크 정보를 표시할 텍스트
    public Button joinButton; // 룸 접속 버튼

    public static int m_ImpostorCount = 1;

    public Text m_CitizenCountUI;

    [SerializeField]
    private Button m_ImpostorButton;


    // 외부에서 싱글톤 오브젝트를 가져올때 사용할 프로퍼티
    public static NetworkManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 NetworkManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<NetworkManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static NetworkManager m_instance; // 싱글톤이 할당될 static 변수

    private void Awake()
    {
        // 씬에 싱글톤 오브젝트가 된 다른 NetworkManager 오브젝트가 있다면
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

    // 게임 실행과 동시에 마스터 서버 접속 시도
    private void Start()
    {
        PhotonNetwork.GameVersion = gameVersion;
        PhotonNetwork.ConnectUsingSettings();

        joinButton.interactable = false;
        connectionInfoText.text = "1.마스터 서버에 접속 중...";
    }

    // 마스터 서버 접속 성공시 자동 실행
    public override void OnConnectedToMaster()
    {
        // PublicScene->LobbyScene
        joinButton.interactable = true;

        connectionInfoText.text = "2.온라인 : 마스터 서버와 연결됨";
    }

    // 마스터 서버 접속 실패시 자동 실행
    public override void OnDisconnected(DisconnectCause cause)
    {
        joinButton.interactable = false;

        connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n접속 재시도 중...";

        PhotonNetwork.ConnectUsingSettings();

    }

    // 룸 접속 시도
    public void Connect()
    {
        joinButton.interactable = false;

        if (PhotonNetwork.IsConnected)
        {
            connectionInfoText.text = "3.룸에 접속...";
            PhotonNetwork.JoinRandomRoom();
        }

        else
        {
            connectionInfoText.text = "오프라인 : 마스터 서버와 연결되지 않음\n접속 재시도 중...";

            PhotonNetwork.ConnectUsingSettings();
        }

    }

    // (빈 방이 없어)랜덤 룸 참가에 실패한 경우 자동 실행
    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        connectionInfoText.text = "빈 장이 없음, 새로운 방 생성...";

        PhotonNetwork.CreateRoom(null, new RoomOptions { MaxPlayers = 6 });
    }

    // 룸에 참가 완료된 경우 자동 실행
    public override void OnJoinedRoom()
    {
        // LobbyScene->Game
        connectionInfoText.text = "4. 방 참가 성공";

        PhotonNetwork.LoadLevel("LobbyScene");
    }

    private void Update()
    {
        //m_CitizenCountUI.text = m_LobbySceneManager.m_PlayerCount.ToString();
    }

}