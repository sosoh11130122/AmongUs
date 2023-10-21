using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    private static DontDestroyOnLoad m_Instance = null;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
