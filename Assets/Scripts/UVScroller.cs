using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class UVScroller : MonoBehaviour
{
    public float m_ScrollSpeedX;
    public float m_ScrollSpeedY;

    public float m_OffsetX;
    public float m_OffsetY;

    private Material material;

    private void Awake()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        material = renderer.material;
    }

    void Update()
    {
        m_OffsetX += Time.deltaTime * m_ScrollSpeedX;
        m_OffsetY += Time.deltaTime * m_ScrollSpeedY;

        material.mainTextureOffset = new Vector2(m_OffsetX % 1, m_OffsetY % 1);
    }
}
