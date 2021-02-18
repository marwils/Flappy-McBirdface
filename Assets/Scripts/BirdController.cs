using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdMovement))]
public class BirdController : MonoBehaviour
{
    public float m_UpForce;

    private BirdMovement m_BirdMovement;

    // Start is called before the first frame update
    void Start()
    {
        m_BirdMovement = GetComponent<BirdMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            m_BirdMovement.Flap(m_UpForce);
        }

    }
}
