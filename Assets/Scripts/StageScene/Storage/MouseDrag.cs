using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; // 마우스 드래그용.

public class MouseDrag : MonoBehaviour, IDragHandler
{
    public Image m_LeverUp;
    public Image m_LeverDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        m_LeverDown.gameObject.SetActive(true);
        m_LeverUp.gameObject.SetActive(false);
    }
}
