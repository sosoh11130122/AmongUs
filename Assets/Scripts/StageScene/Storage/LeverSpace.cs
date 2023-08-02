using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LeverSpace : MonoBehaviour
{
    public LeverUptoDown Lever;
    Image m_Sprite;
    public Sprite m_NewSprite;
    // Start is called before the first frame update

    Collider2D m_Collider;
    void Start()
    {
        m_Sprite = Lever.GetComponent<Image>();
        m_Collider = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Lever")
            m_Sprite.sprite = m_NewSprite;
    }

}
