using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    public bool m_ClickOn;

    void Start()
    {
        m_ClickOn = false;
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            Ray Ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Ray.origin, Ray.direction * 10f, Color.red, 1f);

            RaycastHit Hit;

            if(Physics.Raycast(Ray, out Hit))
            {
                Debug.Log(Hit.transform.gameObject);
                Debug.Log("클릭했다");
                m_ClickOn = true;
            }
        }
    }

    public bool GetClickOn()
    {
        return m_ClickOn;
    }

    public void SetClickOn(bool ClickOn)
    {
        m_ClickOn = ClickOn;
    }
}
