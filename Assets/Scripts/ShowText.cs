using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    public Drag m_Drag;

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
    }

    IEnumerator WaitForIt()
    {
        yield return new WaitForSeconds(3.0f);

        GetComponent<Text>().enabled = true;
    }
}
