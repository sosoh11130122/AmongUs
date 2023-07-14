using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLight : MonoBehaviour
{
    private Animator m_Animator;

    private WaitForSeconds m_Wait = new WaitForSeconds(0.15f);

    private List<WeaponLight> m_Lights = new List<WeaponLight>();

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        
        for(int i = 0; i < transform.childCount; ++i)
        {
            var m_Child = transform.GetChild(i).GetComponent<WeaponLight>();

            if (m_Child)
            {
                m_Lights.Add(m_Child);
            }
        }
    }
    
    public void TurnOnLight()
    {
        m_Animator.SetTrigger("On");
        StartCoroutine(TurnOnLightAtChild());
    }

    private IEnumerator TurnOnLightAtChild()
    {
        yield return m_Wait;

        foreach(var m_Child in m_Lights)
        {
            m_Child.TurnOnLight();
        }
    }
}
