using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftWire : MonoBehaviour
{
    public EWireColor m_WireColor { get; private set; }

    public bool m_IsConnected { get; private set; }

    [SerializeField]
    private List<Image> m_WireImages;

    [SerializeField]
    private Image m_LightImage;

    [SerializeField]
    private RightWire m_ConnectedWire;

    [SerializeField]
    private RectTransform m_WireBody;

    [SerializeField]
    private float m_Offset = 15f;

    private Canvas m_GameCanvas;

    // Start is called before the first frame update
    void Start()
    {
        m_GameCanvas = FindObjectOfType<Canvas>();
    }


    public void SetTarget(Vector3 TargetPosition, float Offset)
    {
        float Angle = Vector2.SignedAngle(transform.position + Vector3.right - transform.position,
               TargetPosition - transform.position);

        float Distance = Vector2.Distance(m_WireBody.position, TargetPosition) + Offset;

        m_WireBody.localRotation = Quaternion.Euler(new Vector3(0f, 0f, Angle));
        m_WireBody.sizeDelta = new Vector2(Distance * (1 / m_GameCanvas.transform.localScale.x), m_WireBody.sizeDelta.y);
    }

    public void ResetTarget()
    {
        m_WireBody.localRotation = Quaternion.Euler(Vector3.zero);
        m_WireBody.sizeDelta = new Vector2(0f, m_WireBody.sizeDelta.y);
    }

    public void SetWireColor(EWireColor WireColor)
    {
        m_WireColor = WireColor;

        Color color = Color.black;

        switch (m_WireColor)
        {
            case EWireColor.Red:
                color = Color.red;
                break;

            case EWireColor.Blue:
                color = Color.blue;
                break;

            case EWireColor.Yellow:
                color = Color.yellow;
                break;

            case EWireColor.Magenta:
                color = Color.magenta;
                break;
        }

        foreach(var Image in m_WireImages)
        {
            Image.color = color;
        }
    }

    public void ConnectWire(RightWire rightWire)
    {
        if (m_ConnectedWire != null && m_ConnectedWire != rightWire)
        {
            m_ConnectedWire.DisconnectWire(this);
            m_ConnectedWire = null;
        }

        m_ConnectedWire = rightWire;

        if (m_ConnectedWire.m_WireColor == m_WireColor)
        {
            m_LightImage.color = Color.yellow;

            m_IsConnected = true;
        }
    }

    public void DisconnectWire()
    {
        if (m_ConnectedWire != null)
        {
            m_ConnectedWire.DisconnectWire(this);
            m_ConnectedWire = null;
        }

        m_LightImage.color = Color.gray;

        m_IsConnected = false;
    }
}
