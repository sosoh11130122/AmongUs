using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
            var Child = transform.GetChild(i).GetComponent<WeaponLight>();

            if (Child)
            {
                m_Lights.Add(Child);
            }

            StartCoroutine(TurnOnPipeLight());
        }
    }

    private IEnumerator TurnOnPipeLight()
    {
        while(true)
        {
            yield return m_Wait;

            foreach(var Child in m_Lights)
            {
                Child.TurnOnLight();
            }
        }
    }
}
