using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BirdMovement : MonoBehaviour
{
    public float m_TiltSpeed;

    private Quaternion m_UpRotation = Quaternion.Euler(0, 0, 35);
    private Quaternion m_DownRotation = Quaternion.Euler(0, 0, -70);

    private Rigidbody2D m_Rigidbody;

    void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (m_Rigidbody.simulated)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, m_DownRotation, m_TiltSpeed * Time.deltaTime);
        }
    }

    public void Flap(float force)
    {
        transform.rotation = m_UpRotation;
        m_Rigidbody.velocity = Vector2.zero;
        m_Rigidbody.AddForce(Vector2.up * force, ForceMode2D.Force);
    }

    public void Stop()
    {
        m_Rigidbody.velocity = Vector2.zero;
    }

    public void SetSimulated(bool value)
    {
        m_Rigidbody.simulated = value;
    }
}
