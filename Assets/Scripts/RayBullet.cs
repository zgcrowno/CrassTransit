using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayBullet : MonoBehaviour
{
    public static float M_FLifetime = 0.25f;

    private LineRenderer m_cmpLR;

    // Start is called before the first frame update
    void Awake()
    {
        m_cmpLR = GetComponent<LineRenderer>();
        m_cmpLR.positionCount = 2;
    }

    public void SetUp(Vector3 _startPos, Vector3 _endPos)
    {
        m_cmpLR.SetPosition(0, _startPos);
        m_cmpLR.SetPosition(1, _endPos);
    }
}
