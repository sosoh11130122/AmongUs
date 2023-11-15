using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    Camera m_Camara;
    Vector3 m_CameraOriginalPos;
    Vector3 zvalue = new Vector3(0f, 0f, -5f);

    // Start is called before the first frame update
    void Start()
    {
        m_Camara = Camera.main;
        m_CameraOriginalPos = m_Camara.transform.position + zvalue;
    }
    
    IEnumerator Shake(float duration, float magnitude)
    {
        float Timer = 0f;

        while (Timer <= duration)
        {
            m_Camara.transform.localPosition = Random.insideUnitSphere * magnitude + m_CameraOriginalPos;

            Timer += Time.deltaTime;

            yield return null;
        }

        m_Camara.transform.localPosition = m_CameraOriginalPos;
    }

    private void Update()
    {
        StartCoroutine(Shake(500f, 0.05f));
    }
}
