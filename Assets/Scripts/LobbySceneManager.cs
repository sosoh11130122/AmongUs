using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LobbySceneManager : MonoBehaviourPunCallbacks
{
    public PhotonView m_PlayerPhotonView;

    public int m_PlayerCount = 0;

    public Text m_PlayerCountUI;

    // 외부에서 싱글톤 오브젝트를 가져올때 사용할 프로퍼티
    public static LobbySceneManager instance
    {
        get
        {
            // 만약 싱글톤 변수에 아직 오브젝트가 할당되지 않았다면
            if (m_instance == null)
            {
                // 씬에서 GameManager 오브젝트를 찾아 할당
                m_instance = FindObjectOfType<LobbySceneManager>();
            }

            // 싱글톤 오브젝트를 반환
            return m_instance;
        }
    }

    private static LobbySceneManager m_instance; // 싱글톤이 할당될 static 변수

    public GameObject playerPrefab; // 생성할 플레이어 캐릭터 프리팹

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

        PhotonNetwork.AutomaticallySyncScene = true;
    }

    // 게임 시작과 동시에 플레이어가 될 게임 오브젝트를 생성
    private void Start()
    {
        // 생성할 랜덤 위치 지정
        //Vector3 randomSpawnPos = new Vector3(0, 0, 0);

        //PhotonNetwork.Instantiate(playerPrefab.name, randomSpawnPos, Quaternion.identity);

      //  m_PlayerPhotonView.RPC("SetPlayerRandomColor", RpcTarget.All);
       
        //playerPrefab.GetComponent<SpriteRenderer>().material.SetColor("_PlayerColor", PlayerColor.GetColor((EPlayerColor)Random.Range(0, 12)));
    }


    // 게임 오버 처리
    public void EndGame()
    {
        // 게임 오버 상태를 참으로 변경
        isGameover = true;
        // 게임 오버 UI를 활성화
        //UIManager.instance.SetActiveGameoverUI(true);
    }

    // 키보드 입력을 감지하고 룸을 나가게 함
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PhotonNetwork.LeaveRoom();
        }

        m_PlayerCountUI.text = PhotonNetwork.CurrentRoom.PlayerCount.ToString();
       // m_PlayerCount = PhotonNetwork.CurrentRoom.PlayerCount;
    }
    
    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            PhotonNetwork.LoadLevel("Stage");
        }
    }

    // 룸을 나갈때 자동 실행되는 메서드
    public override void OnLeftRoom()
    {
        // 룸을 나가면 로비 씬으로 돌아감
        SceneManager.LoadScene("LobbyScene");
    }

    [PunRPC]
    void SetPlayerRandomColor()
    {
        playerPrefab.GetComponent<SpriteRenderer>().material.SetColor("_PlayerColor", PlayerColor.GetColor((EPlayerColor)Random.Range(0, 12)));
    }

}
