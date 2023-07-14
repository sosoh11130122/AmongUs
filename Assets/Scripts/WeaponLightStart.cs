using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLightStart : MonoBehaviour
{
    private WaitForSeconds m_Wait = new WaitForSeconds(1f);

    private List<WeaponLight> m_Lights = new List<WeaponLight>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; ++i)
        {
            var m_Child = transform.GetChild(i).GetComponent<WeaponLight>();

            if (m_Child)
            {
                m_Lights.Add(m_Child);
            }

            StartCoroutine(TurnOnPipeLight());
        }
    }

    private IEnumerator TurnOnPipeLight()
    {
        while(true)
        {
            yield return m_Wait;

            foreach(var m_Child in m_Lights)
            {
                m_Child.TurnOnLight();
            }
        }
    }
}
