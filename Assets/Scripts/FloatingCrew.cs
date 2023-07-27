using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class FloatingCrew : MonoBehaviour
{
    public EPlayerColor m_PlayerColor;

    private SpriteRenderer m_SpriteRenderer;
    private Vector3 m_Direction;
    private float m_FloatingSpeed;
    private float m_RotateSpeed;

    private void Awake()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetFloatingCrew(Sprite sprite, EPlayerColor playerColor, Vector3 direction,
        float floatingSpeed, float rotateSpeed, float size)
    {
        this.m_PlayerColor = playerColor;
        this.m_Direction = direction;
        this.m_FloatingSpeed = floatingSpeed;
        this.m_RotateSpeed = rotateSpeed;

        m_SpriteRenderer.sprite = sprite;
        m_SpriteRenderer.material.SetColor("_PlayerColor", PlayerColor.GetColor(playerColor));

        transform.localScale = new Vector3(size, size, size);
        m_SpriteRenderer.sortingOrder = (int)Mathf.Lerp(1, 32767, size);
    }
    void Update()
    {
        transform.position += m_Direction * m_FloatingSpeed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, 0f, m_RotateSpeed));
    }
}
