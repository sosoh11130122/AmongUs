using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedbayMission : MonoBehaviour
{
    public GameObject m_Mission;

    // Start is called before the first frame update
    void Start()
    {
        //m_Mission = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            m_Mission.SetActive(true);
        }
    }
}
