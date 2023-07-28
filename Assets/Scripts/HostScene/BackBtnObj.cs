using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackBtnObj : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("InputScene");
    }
}
