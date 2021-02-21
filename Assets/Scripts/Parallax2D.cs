using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax2D : MonoBehaviour
{
    public GameObject m_Prefab;

    public float m_SpawnX;

    public MinMax m_SpawnYRange;

    public float m_VelocityX;

    public float m_SpawnDistance;

    public Vector2 m_DesignResolution;

    private List<GameObject> m_Objects;

    private float TargetAspect { get => m_DesignResolution.x / m_DesignResolution.y; }

    private float AspectMultiplier { get => Camera.main.aspect / TargetAspect; }

    private float SpawnXTimesAspect { get => m_SpawnX * AspectMultiplier; }

    private void Start()
    {
        m_Objects = new List<GameObject>();
    }

    public void ClearAll()
    {
        foreach (GameObject obj in m_Objects)
        {
            Destroy(obj);
        }

        m_Objects.Clear();
    }

    private void Update()
    {
        Shift();

        if (m_Objects.Count == 0)
        {
            Spawn();
        } else
        {
            float lastX = m_Objects[m_Objects.Count - 1].transform.position.x;
            if (Mathf.Max(lastX, SpawnXTimesAspect) - Mathf.Min(lastX, SpawnXTimesAspect) >= m_SpawnDistance)
            {
                Spawn();
            }
        }
    }

    private void Shift()
    {
        foreach (GameObject obj in m_Objects)
        {
            obj.transform.localPosition += Vector3.right * m_VelocityX * Time.deltaTime;
        }

        if (m_Objects.Count > 0 && m_Objects[0].transform.localPosition.x < -SpawnXTimesAspect)
        {
            Destroy(m_Objects[0]);
            m_Objects.RemoveAt(0);
        }
    }

    private void Spawn()
    {
        GameObject go = Instantiate(m_Prefab, Vector3.zero, Quaternion.identity) as GameObject;
        go.transform.parent = this.transform;
        Vector3 pos = Vector3.zero;
        pos.x = SpawnXTimesAspect;
        pos.y = Random.Range(m_SpawnYRange.min, m_SpawnYRange.max);
        go.transform.localPosition = pos;
        m_Objects.Add(go);
    }

    [System.Serializable]
    public struct MinMax
    {
        public float min;
        public float max;
    }
}
