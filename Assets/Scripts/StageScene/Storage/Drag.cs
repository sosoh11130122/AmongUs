using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // 마우스 드래그 위해 필요.
using UnityEngine.UI;


public class Drag : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public static Vector2 m_DefaultPos;

    public LeverUptoDown Lever;
    public Sprite m_DownSprite;
    public Sprite m_EmptySprite;
    
    public bool m_EmptyOn;

    public Slider m_MissionProgressBar;

    Image m_Sprite;

    public bool GetEmptyOn() 
    { 
        return m_EmptyOn; 
    }

    void Start()
    {
        m_EmptyOn = false;

    }

    void Update()
    {
        if (!m_EmptyOn)
        {
            if (this.transform.position.y <= 410f)
            {
                Lever.GetComponent<Image>().sprite = m_DownSprite; // 드래그 한 창의 y값이 410보다 작으면 레버다운 이미지로 교체.        
                StartCoroutine(WaitForIt());
            }
        }
    }

    void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
        m_DefaultPos = this.transform.position; // 클릭 시 현재 위치를 m_DefaultPos 로 정한다.
    }

    void IDragHandler.OnDrag(PointerEventData eventData)
    {
        Vector2 CurrentPos = eventData.position; // 드래그 중인 위치를 지금 오브젝트의 위치로 정한다.
        this.transform.position = CurrentPos;
    }

    void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
        Vector2 MousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    IEnumerator WaitForIt()
    {
        m_EmptyOn = true;

        yield return new WaitForSeconds(2.0f);
        Lever.GetComponent<Image>().sprite = m_EmptySprite;

        yield return new WaitForSeconds(2.0f);
        m_MissionProgressBar.value += 25f;
    }

}
