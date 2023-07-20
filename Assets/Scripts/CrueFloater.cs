using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrueFloater : MonoBehaviour
{
    [SerializeField]
    private GameObject m_Prefab;

    [SerializeField]
    private List<Sprite> m_Sprites;

    private bool[] m_CrewStates = new bool[12];
    private float m_Timer = 0.5f;
    private float m_Distance = 11;

    void Start()
    {
     for (int i = 0; i < 12; ++i)
        {
            SpawnFloatingCrew((EPlayerColor)i, Random.Range(0f, m_Distance));
        }
    }
    // Update is called once per frame
    void Update()
    {
        m_Timer -= Time.deltaTime;

        if (m_Timer <= 0f)
        {
            SpawnFloatingCrew((EPlayerColor)Random.Range(0, 12), m_Distance);
            m_Timer = 1f;
        }
        
    }

    public void SpawnFloatingCrew(EPlayerColor playerColor, float dist)// 카메라 영역을 벗어나서 원형으로 생성되게 해야함
    {
        if (!m_CrewStates[(int)playerColor])
        {
            m_CrewStates[(int)playerColor] = true;

            float Angle = Random.Range(0f, 360f); // 0부터 360도 사이의 랜덤한 각도 생성

            Vector3 CameraPosition = Camera.main.transform.position; // 카메라 위치 가져오기
            float CameraHeight = 2f * Camera.main.orthographicSize; // 카메라 높이 가져오기
            float CameraWidth = CameraHeight * Camera.main.aspect; // 카메라 너비 가져오기

            Vector3 Direction = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 1f);
            float FloatingSpeed = Random.Range(120f, 150f);
            float RotateSpeed = Random.Range(-0.5f, 0.5f);

            // 각도와 거리를 이용하여 소환 위치 계산
            Vector3 SpawnPos = CameraPosition + Quaternion.Euler(0f, 0f, Angle) * Vector3.right * (dist + CameraWidth * 0.35f);

            var Crew = Instantiate(m_Prefab, SpawnPos, Quaternion.identity).GetComponent<FloatingCrew>();
            Crew.SetFloatingCrew(m_Sprites[Random.Range(0, m_Sprites.Count)], playerColor, Direction,
                FloatingSpeed, RotateSpeed, Random.Range(100f, 180f));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var Crew = collision.GetComponent<FloatingCrew>();

        if (Crew != null)
        {
            m_CrewStates[(int)Crew.m_PlayerColor] = false;
            Destroy(Crew.gameObject);
        }
    }
}
