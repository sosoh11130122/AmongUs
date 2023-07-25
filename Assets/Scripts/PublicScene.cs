using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PublicScene : MonoBehaviour
{
    GameObject ParticleOBJ;

    private void Start()
    {
        ParticleOBJ.GetComponent<Renderer>().sortingOrder = -500;
    }
}
