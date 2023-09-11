using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoteSystem : MonoBehaviour
{
    [SerializeField]
    private Image m_CharacterImg; // 캐릭터 이미지 색상 변경

    [SerializeField]
    private Text m_NicknameText; // 닉네임 변경용

    [SerializeField]
    private GameObject m_DeadPlayerBlock; // 죽은 플레이어 표시용

    // [SerializeField]
    // private GameObject m_ReportSign; // 신고자 표시용

    // public IngameCharacterMover m_TargetPlayer; // 어떤 플레이어의 패널인지 구분 용도.

    //public void SetPlayer(IngameCharacterMover Target)
    //{
    //    Material inst = Instantiate(m_CharacterImg.material)
    //    m_CharacterImg.material = inst;

    //    m_TargetPlayer = Target;
    //    m_CharacterImg.material.SetColor("m_PlayerColor", PlayerColor, GetColor(m_CharacterImg, PlayerColor));
    // m_NicknameText.text = Target.nickname;

    // 임포스터가 다른 임포스터 볼 떄 빨간색으로 표시되도록. 
    //}

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
