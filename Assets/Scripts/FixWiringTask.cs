using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EWireColor
{
    None = -1,
    Red,
    Blue,
    Yellow,
    Magenta
}
public class FixWiringTask : MonoBehaviour
{
    [SerializeField]
    private List<LeftWire> m_LeftWires;

    [SerializeField]
    private List<RightWire> m_RightWires;

    private LeftWire m_SelectedWire;
    // Start is called before the first frame update

    public GameObject m_TaskUI;
    public Slider m_MissionProgressBar;

    private float m_time;

    private void OnEnable()
    {
        for (int i = 0; i < m_LeftWires.Count; ++i)
        {
            m_LeftWires[i].ResetTarget();
            m_LeftWires[i].DisconnectWire();
        }

        List<int> NumberPool = new List<int>();

        for (int i = 0; i < 4; ++i)
        {
            NumberPool.Add(i);
        }

        int Index = 0;

        while (NumberPool.Count != 0)
        {
            var Number = NumberPool[Random.Range(0, NumberPool.Count)];

            m_LeftWires[Index++].SetWireColor((EWireColor)Number);

            NumberPool.Remove(Number);
        }

        for (int i = 0; i < 4; ++i)
        {
            NumberPool.Add(i);
        }

        Index = 0;

        while (NumberPool.Count != 0)
        {
            var Number = NumberPool[Random.Range(0, NumberPool.Count)];

            m_RightWires[Index++].SetWireColor((EWireColor)Number);

            NumberPool.Remove(Number);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D Hit = Physics2D.Raycast(Input.mousePosition, Vector2.right, 1f);
            if (Hit.collider != null)
            {
                var Left = Hit.collider.GetComponentInParent<LeftWire>();
                if (Left != null)
                {
                    m_SelectedWire = Left;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit2D[] Hits = Physics2D.RaycastAll(Input.mousePosition, Vector2.right, 1f);

            foreach (var Hit in Hits)
            {
                if (Hit.collider != null)
                {
                    var Right = Hit.collider.GetComponentInParent<RightWire>();

                    if (Right != null)
                    {
                        m_SelectedWire.SetTarget(Hit.transform.position, -80f);
                        m_SelectedWire.ConnectWire(Right);
                        Right.ConnectWire(m_SelectedWire);
                        m_SelectedWire = null;

                        return;
                    }
                }
            }

            m_SelectedWire.ResetTarget();
            m_SelectedWire.DisconnectWire();
            m_SelectedWire = null;
        }

        if (m_SelectedWire != null)
        {
            m_SelectedWire.SetTarget(Input.mousePosition, -80f);
        }

        int Count = 0;

        foreach (var Wire in m_RightWires)
        {
            var Connected = Wire.m_IsConnected;

            if (Connected)
                ++Count;

            if (Count == 4)
            {
                m_time += Time.deltaTime;

                if (m_time >= 2f)
                {
                    m_MissionProgressBar.value += 25f;

                    Destroy(m_TaskUI);
                }

            }

        }
    }

}
