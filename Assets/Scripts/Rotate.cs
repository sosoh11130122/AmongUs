using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField]
    float m_RotSpeed = 15f;

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, m_RotSpeed * Time.deltaTime));
    }
}
