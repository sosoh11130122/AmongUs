using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RightWire : MonoBehaviour
{
    public EWireColor m_WireColor { get; private set; }

    [SerializeField]
    private List<Image> m_WireImages;

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
}
