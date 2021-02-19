using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdMovement))]
public class BirdController : MonoBehaviour
{
    public delegate void BirdDelegate();
    public static event BirdDelegate BirdScores;
    public static event BirdDelegate BirdHit;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            m_BirdMovement.SetSimulated(false);
            BirdHit();
        } else if (collision.CompareTag("Score"))
        {
            BirdScores();
        }
    }
}
