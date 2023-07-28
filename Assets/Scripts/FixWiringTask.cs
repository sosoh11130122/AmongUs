using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnEnable()
    {
        List<int> NumberPool = new List<int>();

        for (int i = 0; i < 4; ++i)
        {
            NumberPool.Add(i);
        }

        int Index = 0;

        while(NumberPool.Count != 0)
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
                        m_SelectedWire.SetTarget(Hit.transform.position, -50f);
                        m_SelectedWire = null;

                        return;
                    }
                }
            }

            m_SelectedWire.ResetTarget();
            m_SelectedWire = null;
        }

        if (m_SelectedWire != null)
        {
            m_SelectedWire.SetTarget(Input.mousePosition, -15f);
        }
    }
}
