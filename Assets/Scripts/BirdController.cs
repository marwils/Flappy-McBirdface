using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdMovement))]
public class BirdController : MonoBehaviour
{
    public delegate void BirdDelegate();
    public static event BirdDelegate BirdScored;
    public static event BirdDelegate BirdHit;

    public Vector2 m_StartPosition;

    public float m_UpForce;

    private BirdMovement m_BirdMovement;

    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        m_BirdMovement = GetComponent<BirdMovement>();
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            m_BirdMovement.Flap(m_UpForce);
        }
    }

    private void OnEnable()
    {
        GameManager.GameStarted += OnGameStarted;
        GameManager.GameResetted += OnGameResetted;
    }

    private void OnDisable()
    {
        GameManager.GameStarted -= OnGameStarted;
        GameManager.GameResetted -= OnGameResetted;
    }

    private void OnGameStarted()
    {
        m_BirdMovement.Stop();
        m_BirdMovement.SetSimulated(true);
    }

    private void OnGameResetted()
    {
        transform.position = m_StartPosition;
        transform.rotation = Quaternion.identity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Obstacle"))
        {
            m_BirdMovement.SetSimulated(false);
            BirdHit();
        } else if (collision.CompareTag("Score"))
        {
            BirdScored();
        }
    }
}
