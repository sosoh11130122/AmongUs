using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public Drag m_Drag;
    public GameObject m_LeverUI;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_Drag.GetEmptyOn())
        {
            StartCoroutine(WaitForIt());
        }

        if (GetComponent<Text>().enabled)
        {
            StartCoroutine(DestroyAll());

        }
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(3.0f);

        GetComponent<Text>().enabled = true;
    }

    IEnumerator DestroyAll()
    {
        yield return new WaitForSeconds(2.0f);

        Destroy(this);
        Destroy(m_LeverUI);
    }
}
