using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BouncingEffect : MonoBehaviour
{
    float m_Time;

    void Update()
    {
        transform.localScale = Vector3.one * (1.5f + m_Time);

        m_Time += Time.deltaTime;

        if (m_Time > 0.2f)
        {
            transform.localScale = Vector3.one * 1.5f;
        }
    }
}
