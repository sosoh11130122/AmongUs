using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightWire : MonoBehaviour
{
    public EWireColor m_WireColor { get; private set; }

    public bool m_IsConnected { get; private set; }

    [SerializeField]
    private List<Image> m_WireImages;

    [SerializeField]
    private Image  m_LightImage;

    [SerializeField]
    private List<LeftWire> m_ConnectedWires = new List<LeftWire>();

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

        foreach (var Image in m_WireImages)
        {
            Image.color = color;
        }
    }

    public void ConnectWire(LeftWire leftWire)
    {
        if (m_ConnectedWires.Contains(leftWire))
        {
            return;
        }

        m_ConnectedWires.Add(leftWire);

        if (m_ConnectedWires.Count == 1 && leftWire.m_WireColor == m_WireColor)
        {
            m_LightImage.color = Color.yellow;

            m_IsConnected = true;
        }

        else
        {
            m_LightImage.color = Color.gray;

            m_IsConnected = false;
        }
    }

    public void DisconnectWire(LeftWire leftWire)
    {
        m_ConnectedWires.Remove(leftWire);

        if (m_ConnectedWires.Count == 1 && m_ConnectedWires[0].m_WireColor == m_WireColor)
        {
            m_LightImage.color = Color.yellow;

            m_IsConnected = true;
        }

        else
        {
            m_LightImage.color = Color.gray;

            m_IsConnected = false;
        }
    }
}
