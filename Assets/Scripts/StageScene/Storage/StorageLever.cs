using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorageLever : MonoBehaviour
{
    public Image LeverUp;
    public Image LeverDown;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player")
            LeverUp.gameObject.SetActive(true);
            //LeverUp.GetComponent<Renderer>().enabled = true;
    }
}
