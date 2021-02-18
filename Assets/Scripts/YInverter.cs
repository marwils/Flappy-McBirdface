using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YInverter : MonoBehaviour
{
    public Transform m_LowerObject;
    public Transform m_UpperObject;

    public float m_Distance;

    void Update()
    {
        m_LowerObject.localPosition = Vector2.up * -m_Distance;
        m_UpperObject.localPosition = Vector2.up * m_Distance;
    }
}
