using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VoteSelectButton : MonoBehaviour
{
    public GameObject m_Voters;
    public GameObject m_VotedButton;

    void Start()
    {
             
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {
        m_Voters.SetActive(true);
        m_VotedButton.SetActive(true);
    }
}
