using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HostButton : MonoBehaviour
{
    public void LoadScene()
    {
        SceneManager.LoadScene("HostScene");
    }
}
