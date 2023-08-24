using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionProgressBar : MonoBehaviour
{
    public Slider m_ProgressBar;
    
    public float m_MaxValue;
    public float m_MissionValue;

    public bool m_Complete;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        m_ProgressBar.maxValue = m_MaxValue;

        if (m_Complete)
        {
            m_ProgressBar.value += m_MissionValue;
            m_Complete = false;
        }
    }

}
